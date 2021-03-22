using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelData : MonoBehaviour
{
    [Header("Level Prefab")]
    #region Level Prefab
    public GameObject[] Level_Prefab;
    #endregion

    [Header("Level Text/UI")]
    #region Level Text
    public Text Level_Text_Box;
    #endregion

    [Header("Current Level")]
    #region Current Level
    public GameObject[] CurrentLevelPrefab = new GameObject[1];
    #endregion

    [Header("İnt variables")]
    #region  İnt Level Variables
    private int _savedLevel;
    private int _savedLevelForHeader;
    public string LevelSavedKey = "Kayitli Level";
    public string HeaderSavedKey = "Kayırlı Level/Text";

    #endregion

    #region Instance
    public static LevelData Instance;
    #endregion

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        if (PlayerPrefs.HasKey(LevelSavedKey))
        {
            #region Get Level Prefs
            _savedLevel = PlayerPrefs.GetInt(LevelSavedKey);
            Debug.Log("Kayıtlı Olan Level :" + " " + _savedLevel);
            #endregion


            #region Instantiate Saved Level
            GameObject go = Instantiate(Level_Prefab[_savedLevel], Vector3.zero, Quaternion.identity);
            CurrentLevelPrefab[0] = go.gameObject;
            Debug.Log("Kayıtlı olan level yüklendi!" + " " + "Kayıtlı olan level:" + " " + _savedLevel);
            #endregion


            PlayerPrefs.SetInt(LevelSavedKey, _savedLevel);
        }
        else
        {
            #region Instantiate First Level 

            GameObject go = Instantiate(Level_Prefab[0].gameObject, Vector3.zero, Quaternion.identity);
            CurrentLevelPrefab[0] = go.gameObject;

            _savedLevel = 0;

            #endregion


            PlayerPrefs.SetInt(LevelSavedKey, _savedLevel);
        }

        if (PlayerPrefs.HasKey(HeaderSavedKey))
        {
            //Find the saved level index
            #region Get Level Index For Header
            _savedLevelForHeader = PlayerPrefs.GetInt(HeaderSavedKey);
            Level_Text_Box.text = "LEVEL" + " " + _savedLevelForHeader.ToString();
            #endregion

        }
        else
        {
            //Set the saved level index
            #region Set the level ındex for header

            _savedLevelForHeader = 1;
            Level_Text_Box.text = "LEVEL" + " " + _savedLevelForHeader.ToString();
            PlayerPrefs.SetInt(HeaderSavedKey, _savedLevelForHeader);

            #endregion
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentLevelPrefab[0] == null)
        {
            LevelBuilder();
        }
        if (Input.GetMouseButtonDown(1))
        {
            DestroyOldLevel();
        }
    }

    public void LevelBuilder()
    {
        if (GameManager.Instance.IsSucces)
        {
            #region Update the int index
            _savedLevel += 1;
            _savedLevelForHeader += 1;
            Level_Text_Box.text = "LEVEL" + " " + _savedLevelForHeader.ToString();
            #endregion

        }
        else
        {
            //Etc..
            Level_Text_Box.text = "LEVEL" + " " + _savedLevelForHeader.ToString();
        }

        //Player Prefs
        #region Player Prefs Process
        PlayerPrefs.SetInt(HeaderSavedKey, _savedLevelForHeader);
        PlayerPrefs.SetInt(LevelSavedKey, _savedLevel);
        #endregion


        //Instantiate New Level Prefab
        #region Instantiate New Level
        GameObject go = Instantiate(Level_Prefab[_savedLevel], Vector3.zero, Quaternion.identity);
        CurrentLevelPrefab[0] = go.gameObject;
        #endregion


    }

    public void DestroyOldLevel()
    {
        if (CurrentLevelPrefab[0] != null)
        {
            Destroy(CurrentLevelPrefab[0].gameObject);
            CurrentLevelPrefab[0] = null;
            Debug.Log("Sahnedeki Level Kaldırıldı!");
        }
    }
}

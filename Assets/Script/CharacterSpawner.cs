using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
   

    //[HideInInspector]
    #region Instantiate Control
    public bool IsDone = true;
    #endregion

    [Header("Player Prefab")]
    #region Player Prefab
    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;
    #endregion

    [Header("Start Position")]
    #region StartPoints
    public Transform PlayerStartPos;
    private Vector3 _enemyStartPos;
    #endregion

    private GameObject go; //Temp Obj

    public GameObject LevelPrefab;
    void Start()
    {
        IsDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameStart && IsDone)
        {
            SpawnerMethod();
            
        }

    }

    public void SpawnerMethod()
    {
        if (BoostController.Instance.Is_Secc_Player)
        {
           
                GameObject go = Instantiate(PlayerPrefab, PlayerStartPos.transform.position, Quaternion.identity);
            go.transform.SetParent(LevelPrefab.transform);
          
                _enemyStartPos = new Vector3(Random.Range(-11, -1), -10.1f, 50f);
            GameObject go1 = Instantiate(EnemyPrefab, _enemyStartPos, Quaternion.identity);
            go1.transform.SetParent(LevelPrefab.transform);
            
        }
        else
        {
            
                GameObject go = Instantiate(PlayerPrefab, PlayerStartPos.transform.position, Quaternion.identity);
            go.transform.SetParent(LevelPrefab.transform);

        }

        IsDone = false;
        
    }
}

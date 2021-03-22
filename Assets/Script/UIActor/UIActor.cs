using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIActor : MonoBehaviour
{
    [Header("Header Text")]
    #region Panel Header
    public GameObject Panel_Header;
    #endregion

    [Header("Menu_Home")]
    #region Home Panel
    public GameObject Menu_Home_Panel;
    public Button Menu_Home_Start_Button;
    #endregion

    [Header("Menu_SUcces")]
    #region Succes Panel
    public GameObject Menu_Succes_Panel;
    public Button Menu_Succes_Continue_Button;
    #endregion

    [Header("Menu_Fail")]
    #region Fail Panel
    public GameObject Menu_Fail_Panel;
    public Button Menu_Fail_Retry_Button;
    #endregion

    [Header("Particle Confetti")]
    #region Confetti
    public ParticleSystem LeftParticle;
    public ParticleSystem RightParticle;
    public ParticleSystem TopParticle;
    public ParticleSystem BotParticle;
    #endregion

    [Header("Delay for Panel")]
    #region Timer
    public float _timer = 1f;

    #endregion

    #region Instance
    public static UIActor Instance;
    #endregion

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
       
        Panel_Header.SetActive(true);

        #region Button Listenner
        Menu_Home_Start_Button.onClick.AddListener(Menu_Home_StartButton);
        Menu_Succes_Continue_Button.onClick.AddListener(Menu_Succes_ContinueButton);
        Menu_Fail_Retry_Button.onClick.AddListener(Menu_Fail_RestartButton);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.Instance.IsGameStart && !BoostController.Instance.IsFull)
        {
            BoostController.Instance.Boost_Panel.SetActive(true);

           
        }
        else if (BoostController.Instance.IsFull && !GameManager.Instance.IsGameStart)
        {
            BoostController.Instance.Boost_Panel.SetActive(false);
            Menu_Home_Panel.SetActive(true);
        }

        if (Menu_Home_Panel.activeSelf)
        {
            Panel_Header.SetActive(false);
        }
        else if (Menu_Fail_Panel.activeSelf)
        {
            Panel_Header.SetActive(false);
        }
        else if (Menu_Succes_Panel.activeSelf)
        {
            ParticleActive(true);
            Panel_Header.SetActive(false);
            ParticleAnimation(true);
        }
        else
        {
            Panel_Header.SetActive(true);
        }
    }

    #region Panel Methods

    public void Menu_Home()
    {
        if (!Menu_Home_Panel.activeSelf)
        {
            Menu_Home_Panel.SetActive(true);
        }

    }

    public void Menu_Tutorial()
    {
        //Menu Tutorial Buraya Gelecek!
    }

    public void Menu_Fail()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            return;
        }

        if (!Menu_Fail_Panel.activeSelf)
        {
            Menu_Fail_Panel.SetActive(true);
        }
    }
    public void Menu_Succes()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            return;
        }

        if (!Menu_Succes_Panel.activeSelf)
        {
            Menu_Succes_Panel.SetActive(true);
        }
    }
    #endregion

    #region Button Methods
    public void Menu_Home_StartButton()
    {
        GameManager.Instance.IsGameStart = true;
        Menu_Home_Panel.SetActive(false);

        #region Debug Control
        Debug.Log("Start butonuna basıldı.!");
        #endregion
    }

    public void Menu_Succes_ContinueButton()
    {
        LevelData.Instance.DestroyOldLevel();
        LevelData.Instance.LevelBuilder();
        GameManager.Instance.IsGameOver = false;
        GameManager.Instance.IsGameStart = true;        
        ParticleActive(false);
        Menu_Succes_Panel.SetActive(false);
        GameManager.Instance.IsSucces = false;
    }

    public void Menu_Fail_RestartButton()
    {
        BoostController.Instance.ResetMethod();
        LevelData.Instance.DestroyOldLevel();
        LevelData.Instance.LevelBuilder();
        GameManager.Instance.IsGameOver = false;
        GameManager.Instance.IsGameStart = false;
        GameManager.Instance.IsFail = false;
        Menu_Fail_Panel.SetActive(false);
        ParticleActive(false);

    }
    #endregion

    public void ParticleActive(bool succes)
    {
        if (succes)
        {
            LeftParticle.gameObject.SetActive(true);
            RightParticle.gameObject.SetActive(true);
            TopParticle.gameObject.SetActive(true);
            BotParticle.gameObject.SetActive(true);


        }
        else
        {
            LeftParticle.gameObject.SetActive(false);
            RightParticle.gameObject.SetActive(false);
            TopParticle.gameObject.SetActive(false);
            BotParticle.gameObject.SetActive(false);
        }

    }

    public void ParticleAnimation(bool succes)
    {
        if (succes)
        {
            if (!RightParticle.isPlaying && !LeftParticle.isPlaying && !TopParticle.isPlaying && !BotParticle.isPlaying)
            {
                RightParticle.Play();
                LeftParticle.Play();
                TopParticle.Play();
                BotParticle.Play();
            }
        }
    }
}

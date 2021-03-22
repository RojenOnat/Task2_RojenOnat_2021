using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoostController : MonoBehaviour
{
    [Header("+%50 Speed UI")]
    #region Speed Button UI
    public Button Raise_Speed_50;
    public Image Raise_Image;
    public bool Raising_Fifty;
    #endregion

    [Header("2. Player")]
    #region Speed Button UI
    public Button SeccPlayer_Button;
    public Image SeccPlayer_Image;
    public bool Is_Secc_Player;
    #endregion

    [Header("Frequency UI")]
    #region Speed Button UI
    public Button Frequency_Button;
    public Image Frequency_Image;
    public bool Frequency_Shot;
    #endregion

    [Header("Double Shot UI")]
    #region Speed Button UI
    public Button DoubleShot_Button;
    public Image DoubleShot_Button_Image;
    public bool Is_Double_Shot;
    #endregion

    [Header("Projectile Motion UI")]
    #region Speed Button UI
    public Button Projectile_Motion_Button;
    public Image Projectile_Image;
    public bool Is_Projectile_Shot;
    #endregion

    [Header("Counter Text")]
    #region Text
    public Text CounterText;
    public int Counter;
    public bool IsFull;
    #endregion

    [Header("Boost Panel")]
    #region Boost Panel
    public GameObject Boost_Panel;
    #endregion

    #region Instance
    public static BoostController Instance;
    #endregion

    #region Timer
    private float timer = 0.2f;
    #endregion

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        #region Button OnClick
        Raise_Speed_50.onClick.AddListener(FiftyMethod);
        SeccPlayer_Button.onClick.AddListener(HundredMethod);
        Frequency_Button.onClick.AddListener(FrequencyMethod);
        DoubleShot_Button.onClick.AddListener(DoubleShotMethod);
        Projectile_Motion_Button.onClick.AddListener(ProjectileMethod);
        #endregion
    }


    void Update()
    {
        if (Counter == 3 && !GameManager.Instance.IsGameStart)
        {
            
           
           

            if (timer>0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Boost_Panel.SetActive(false);
                IsFull = true;
                
            }

        }
    }

    #region Button Method
    

    public void FiftyMethod()
    {
        if (IsFull) return;

        Raising_Fifty = !Raising_Fifty;
        Debug.Log("Fifty Mod" + " " + Raising_Fifty); //Control

        if (Raising_Fifty)
        {
            

            Raise_Speed_50.transform.localScale = Vector3.one;
            Raise_Image.color = Color.green;
            Counter++;
        }
        else
        {
           

            Raise_Speed_50.transform.localScale = new Vector3(0.835677f, 0.835677f, 0.835677f);
            Raise_Image.color = Color.black;
            Counter--;

        }

        CounterText.text = Counter.ToString() + "/3";

    }
    public void HundredMethod()
    {
        if (IsFull) return;

        Is_Secc_Player = !Is_Secc_Player;
        Debug.Log("Hunred Mod" + " " + Is_Secc_Player); //Control

        if (Is_Secc_Player)
        {


            SeccPlayer_Button.transform.localScale = Vector3.one;
            SeccPlayer_Image.color = Color.green; 
            Counter++;
        }
        else
        {
           
            SeccPlayer_Button.transform.localScale = new Vector3(0.835677f, 0.835677f, 0.835677f);
            SeccPlayer_Image.color = Color.black;
            Counter--;
        }
        CounterText.text = Counter.ToString() + "/3";
    }

    public void ProjectileMethod()
    {
        if (IsFull) return;

        Is_Projectile_Shot = !Is_Projectile_Shot;
        Debug.Log("Projectile Mod" + " " + Is_Projectile_Shot); //Control

        if (Is_Projectile_Shot)
        {
            Projectile_Motion_Button.transform.localScale = Vector3.one;
            Projectile_Image.color = Color.green;
            Counter++;
        }
        else
        {
            Projectile_Motion_Button.transform.localScale = new Vector3(0.835677f, 0.835677f, 0.835677f);
            Projectile_Image.color = Color.black;
            Counter--;
        }
        CounterText.text = Counter.ToString() + "/3";
    }
    
    public void FrequencyMethod()
    {
        if (IsFull) return;

        Frequency_Shot = !Frequency_Shot;
        Debug.Log("Frequency Mod" + " " + Frequency_Shot); //Control

        if (Frequency_Shot)
        {
            Frequency_Button.transform.localScale = Vector3.one;
            Frequency_Image.color = Color.green;
            Counter++;
        }
        else
        {

            Frequency_Button.transform.localScale = new Vector3(0.835677f, 0.835677f, 0.835677f);
            Frequency_Image.color = Color.black;
            Counter--;
        }
        CounterText.text = Counter.ToString() + "/3";
    }

    public void DoubleShotMethod()
    {
        if (IsFull) return;

        Is_Double_Shot = !Is_Double_Shot;
        Debug.Log("Double Shot Mod" + " " + Is_Double_Shot); //Control

        if (Is_Double_Shot)
        {
            DoubleShot_Button.transform.localScale = Vector3.one;
           DoubleShot_Button_Image.color = Color.green;
            Counter++;
        }
        else
        {

            DoubleShot_Button.transform.localScale = new Vector3(0.835677f, 0.835677f, 0.835677f);
            DoubleShot_Button_Image.color = Color.black;
            Counter--;
        }
        CounterText.text = Counter.ToString() + "/3";
    }
    #endregion

    public void ResetMethod()
    {
        Is_Double_Shot = false;
        Frequency_Shot = false;
        Is_Projectile_Shot = false;
        Is_Secc_Player = false;
        Raising_Fifty = false;
        timer = 0.2f;
        IsFull = false;
        Counter = 0;

        ResetButtons();
    }

    public void ResetButtons()
    {
        CounterText.text = Counter.ToString() + "/3";

        DoubleShot_Button.transform.localScale = new Vector3(0.835677f, 0.835677f, 0.835677f);
        DoubleShot_Button_Image.color = Color.black;

        Frequency_Button.transform.localScale = new Vector3(0.835677f, 0.835677f, 0.835677f);
        Frequency_Image.color = Color.black;

        Projectile_Motion_Button.transform.localScale = new Vector3(0.835677f, 0.835677f, 0.835677f);
        Projectile_Image.color = Color.black;

        SeccPlayer_Button.transform.localScale = new Vector3(0.835677f, 0.835677f, 0.835677f);
        SeccPlayer_Image.color = Color.black;

        Raise_Speed_50.transform.localScale = new Vector3(0.835677f, 0.835677f, 0.835677f);
        Raise_Image.color = Color.black;
    }
}

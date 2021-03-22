/*
 Developed by Rojen Onat.
 LinkedIn: https://www.linkedin.com/in/rojen-onat-8ab1b1189/
 Gmail: onatrojen@gmail.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Status")]
    #region Game Status
    public bool IsSucces;
    public bool IsFail;
    public bool IsGameStart;
    public bool IsGameOver;
    #endregion

    #region Instance
    public static GameManager Instance;
    #endregion
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //Fps
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFail)
        {
            IsSucces = false;
        }
        else if (IsSucces)
        {
            IsFail = false;
        }

        if (IsGameOver && !IsFail && IsSucces)
        {
            UIActor.Instance.Menu_Succes();
        }
        else if (IsGameOver && IsFail && !IsSucces)
        {
            UIActor.Instance.Menu_Fail();
        }

    }

    //Create a custom level fail or complete method
    public void LevelCompleted(object[] args)
    {
        IsSucces = (bool)args[0];
        IsGameOver = (bool)args[0];
    }

    public void LevelFail(object[] args)
    {
        IsFail = (bool)args[0];
        IsGameOver = (bool)args[0];
    }
}

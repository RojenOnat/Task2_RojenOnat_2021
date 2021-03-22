using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        #region Game Manager Settings
        GameManager.Instance.IsSucces = false;
        GameManager.Instance.IsFail = false;
        GameManager.Instance.IsGameOver = false;
        #endregion
        
    }
    void Update()
    {
        
    }
}

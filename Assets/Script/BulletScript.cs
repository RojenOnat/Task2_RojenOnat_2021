﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    


    [Header("Bullet Properties")]
    #region Bullet
    public float Speed;
    public Transform BulletPos;
    public float ProjectileSpeed = 2;
    #endregion

    [Header("Bullet Prefab")]
    #region Prefab
    public GameObject BulletPrefab;
    public GameObject ProjectilePrefab;
    #endregion

    #region Instance
    public static BulletScript Instance;
    #endregion

    public int _bulletCount = 2;

    #region Bullet Frequency Timer
    private float timer = 0f;
    #endregion

   
    private GameObject go;      //Player Temp Object
    private GameObject go2;

    //Enemy Temp
    [Header("Particle")]
    #region Particle
    public ParticleSystem ShotParticle;
    private ParticleSystem TempParticle;
    #endregion

    #region Level Prefab
    public GameObject LevelPrefab;
    #endregion
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        LevelPrefab = GameObject.Find("Level 1(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameStart) return;
        

        if (BulletPos != null)
        {
            BulletMovement();
        }
       
    }

    #region Bullet Methods

  public void BulletMovement()
    {
        if (timer>0)
        {
            timer -= Time.deltaTime;
            return;
        }
 

        if (BoostController.Instance.Is_Projectile_Shot)
        {
            BulletPrefab = ProjectilePrefab.gameObject;

           
        }
        if (BoostController.Instance.Raising_Fifty)
        {
            Speed = Speed + (Speed * 0.5f);
            BoostController.Instance.Raising_Fifty = false;
        }

        go = Instantiate(BulletPrefab, BulletPos.transform.position, Quaternion.identity);


        go.transform.SetParent(LevelPrefab.transform);

        if (BoostController.Instance.Is_Double_Shot)
        {
            go2 = Instantiate(BulletPrefab, new Vector3(BulletPos.transform.position.x,
                BulletPos.transform.position.y,
                BulletPos.transform.position.z - 0.75f),
                Quaternion.identity);
            go2.transform.SetParent(LevelPrefab.transform);

        }


        if (BoostController.Instance.Frequency_Shot)
        {
            timer = 1f;
        }
        else
        {
            timer = 2f;
        }

        TempParticle = Instantiate(ShotParticle, BulletPos.position, Quaternion.identity);
        TempParticle.transform.SetParent(LevelPrefab.transform);

    }

   
    #endregion
}

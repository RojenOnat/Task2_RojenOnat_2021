using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;

    [Header("Particle")]
    #region Particle
    public ParticleSystem ShotParticle;
    private ParticleSystem TempParticle;
    #endregion

    private GameObject LevelPrefab;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * BulletScript.Instance.Speed;
        LevelPrefab = GameObject.Find("Level 1(Clone)");

    }

    // Update is called once per frame
    void Update()
    {
       
           
        
       
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Wall") || collision.collider.CompareTag("Bullet"))
        {

           TempParticle =   Instantiate(ShotParticle, transform.position, Quaternion.identity);
            TempParticle.transform.SetParent(LevelPrefab.transform);
        }
    }
}

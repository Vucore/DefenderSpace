using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Genaral")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speedBullet = 10f;
    [SerializeField] float bulletLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.3f;
    [Header("AI - Enemy")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [SerializeField] bool useAI;
    [HideInInspector] public bool isFiring;
    Coroutine fireCoroutine;
    AudioPlayer audioPlayer;
    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }


    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if(isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuosly());
        }
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }
    IEnumerator FireContinuosly()
    {
        while(true)
        {
            CreateBullet();
            audioPlayer.PlayShooterClip();
            float timeToNextBullet = UnityEngine.Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextBullet = Mathf.Clamp(timeToNextBullet, minimumFiringRate, float.MaxValue);
            yield return new WaitForSeconds(timeToNextBullet);
        }
    }
    void CreateBullet()
    {
        GameObject intances = Instantiate(bulletPrefab, 
                                        transform.position, 
                                        Quaternion.identity);
        Rigidbody2D rb = intances.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speedBullet;
        Destroy(intances, bulletLifeTime);                                
    }
}

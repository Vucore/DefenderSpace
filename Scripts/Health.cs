using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int score;
    [SerializeField] int health = 50;
    [SerializeField] bool applyCameraShake;
    Explosion explosion;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    void Awake()
    {
        explosion =FindObjectOfType<Explosion>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer= other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            ShakeCamera();
            audioPlayer.PlayDamageClip();
            if(other.tag == "Enemy")
            {
                //PlayHitEffect(explosion.GetPlayerExplosion());
                explosion.PlayEffectPlayer(transform.position);
            }
            else if(other.tag == "Player")
            {
                //PlayHitEffect(explosion.GetEnemyExplosion());
                explosion.PlayEffectEnemy(transform.position);
            }
            damageDealer.Hit();
        }
    }

    // void PlayHitEffect(ParticleSystem pS)
    // {
    //     ParticleSystem instance = Instantiate(pS, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
    //     Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    // }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }
    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
    public int GetHealth()
    {
        return health;
    }
}

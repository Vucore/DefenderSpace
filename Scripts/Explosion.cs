using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Explosion : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] ParticleSystem enemyExplosion;
    [Header("Enemy")]
    [SerializeField] ParticleSystem playerExplosion;
    // public ParticleSystem GetEnemyExplosion()
    // {
    //     return enemyExplosion;
    // }
    //  public ParticleSystem GetPlayerExplosion()
    // {
    //     return playerExplosion;
    // }
    public void PlayEffectPlayer(Vector3 pos)
    {
        PlayHitEffect(playerExplosion, pos);
    }
    public void PlayEffectEnemy(Vector3 pos)
    {
        PlayHitEffect(enemyExplosion, pos);
    }
    void PlayHitEffect(ParticleSystem pS ,Vector3 pos)
    {
        ParticleSystem instance = Instantiate(pS, pos, Quaternion.identity).GetComponent<ParticleSystem>();
        Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
    }

}

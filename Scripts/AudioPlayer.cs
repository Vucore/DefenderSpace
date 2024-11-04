using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{   
    [SerializeField] AudioClip audioClipShooter;
    [SerializeField] [Range(0f,1f)] float shooterVolume;
    [SerializeField] AudioClip audioClipDamage;
    [SerializeField] [Range(0f,1f)] float damageVolume;
    static AudioPlayer instance;
    // public AudioPlayer GetAudioPlayerInstance()
    // {
    //     return instance;
    // }
    void Awake()
    {
        ManageSingleton();  
    }
    void ManageSingleton()
    {
        // int instancesCount = FindObjectsOfType(GetType()).Length;
        // if(instancesCount > 1)
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayShooterClip()
    {
        PlayClip(audioClipShooter, shooterVolume);
    }
    public void PlayDamageClip()
    {
        PlayClip(audioClipDamage,damageVolume);
    }
    void PlayClip(AudioClip audioClip, float volume)
    {
        if(audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
        }
    }
}

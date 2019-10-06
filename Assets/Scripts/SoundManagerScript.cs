using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip JumpSound;
    public static AudioClip LandSound;
    public static AudioClip CoinSound;
    public static AudioClip DeathSound;
    static AudioSource audioSrc;
    
    void Start()
    {
        JumpSound = Resources.Load<AudioClip>("Jump1");
        LandSound = Resources.Load<AudioClip>("Land1");
        CoinSound = Resources.Load<AudioClip>("Coin1");
        DeathSound = Resources.Load<AudioClip>("Death1");
        


        audioSrc = GetComponent<AudioSource>();
    }
    

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Jump1":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "Land1":
                audioSrc.PlayOneShot(LandSound);
                break;
            case "Coin1":
                audioSrc.PlayOneShot(CoinSound);
                break;
            case "Death1":
                audioSrc.PlayOneShot(DeathSound);
                break;
        }
    }

}

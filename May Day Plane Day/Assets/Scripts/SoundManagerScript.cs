using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip hitSound, scoreSound;
    static AudioSource audioScr;

    private void Start()
    {
        hitSound = Resources.Load<AudioClip>("hitSound");
        scoreSound = Resources.Load<AudioClip>("scoreSound");

        audioScr = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "hitSound":
                audioScr.PlayOneShot(hitSound);
                break;
            case "scoreSound":
                audioScr.PlayOneShot(scoreSound);
                break;
        }
    }
}

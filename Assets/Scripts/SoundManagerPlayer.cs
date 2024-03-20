using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource lightningAudioSource;
    [SerializeField] private AudioClip lightningShot;

    public void LightningShot()
    {
        lightningAudioSource.PlayOneShot(lightningShot);
    }
}

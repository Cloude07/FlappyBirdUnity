using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundComponent : MonoBehaviour
{
    [SerializeField] AudioSource[] _audio;
    [SerializeField] AudioClip[] _clip;

    public void SoundFly()
    {
        _audio[0].clip = _clip[0];
        _audio[0].Play();
    }

    public void SoundHit()
    {
        _audio[1].clip = _clip[1];
        _audio[1].Play();
    }
    public void SoundCountUp()
    {
        _audio[2].clip = _clip[2];
        _audio[2].Play();
    }

}

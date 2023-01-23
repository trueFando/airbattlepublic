using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundFX : MonoBehaviour
{
    [SerializeField] private AudioClip _shot;
    [SerializeField] private AudioClip _coin;
    [SerializeField] private AudioClip _ammo;
    [SerializeField] private AudioClip _fuel;
    [SerializeField] private AudioClip _loss;

    public void ShotSound()
    {
        PlaySound(_shot);
    }

    public void CoinSound()
    {
        PlaySound(_coin);
    }

    public void AmmoSound()
    {
        PlaySound(_ammo);
    }

    public void FuelSound()
    {
        PlaySound(_fuel);
    }

    public void LossSound()
    {
        PlaySound(_loss);
    }

    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, PlayerPrefs.GetFloat("sound"));
    }
}

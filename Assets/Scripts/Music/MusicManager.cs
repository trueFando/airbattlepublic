using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip _storeClip;
    [SerializeField] private AudioClip _menuClip;
    [SerializeField] private AudioClip _desertClip;
    [SerializeField] private AudioClip _jungleClip;

    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        //_audioSource = GetComponent<AudioSource>();
        SetVolume();
    }

    public void SetClip(MusicSceneType type)
    {
        if (type == MusicSceneType.Store) _audioSource.clip = _storeClip;
        else if (type == MusicSceneType.Menu) _audioSource.clip = _menuClip;
        else if (type == MusicSceneType.Desert) _audioSource.clip = _desertClip;
        else if (type == MusicSceneType.Jungle) _audioSource.clip = _jungleClip;

        SetVolume();
        _audioSource.Play();
    }

    public void SetVolume()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("music");
    }
}

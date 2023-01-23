using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
{
    [Header("\"music\" or \"sound\"")]
    [SerializeField] private string _volumeType; // "music" and "sound"
    [SerializeField] private float[] _volumes = { 1f, 0.75f, 0.5f, 0f };
    [SerializeField] private Sprite[] _volumesSprites;

    private float _currentVolume;
    private Sprite _currentSprite;
    private Image _image;

    private MusicManager _musicManager;

    private void Start()
    {
        _musicManager = FindObjectOfType<MusicManager>();

        _image = GetComponent<Image>();
        SetupVolume();
    }

    private void SetupVolume()
    {
        _currentVolume = PlayerPrefs.GetFloat($"{_volumeType}");
        _currentSprite = _volumesSprites[Array.IndexOf(_volumes, _currentVolume)];
        _image.sprite = _currentSprite;
    }

    public void ChangeVolume()
    {
        int currentIndex = Array.IndexOf(_volumes, _currentVolume);

        if (currentIndex == _volumes.Length - 1)
        {
            _currentVolume = _volumes[0];
            _currentSprite = _volumesSprites[0];
        }
        else
        {
            _currentVolume = _volumes[currentIndex + 1];
            _currentSprite = _volumesSprites[currentIndex + 1];
        }

        _image.sprite = _currentSprite;
        PlayerPrefs.SetFloat($"{_volumeType}", _currentVolume);

        _musicManager.SetVolume();
    }
}

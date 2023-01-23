using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _records;
    [SerializeField] private GameObject _store;

    [SerializeField] private MusicManager _musicManager;

    private void Start()
    {
        //_musicManager = FindObjectOfType<MusicManager>();
        _musicManager.SetClip(MusicSceneType.Menu);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void StartGameJungle()
    {
        SceneManager.LoadScene("Game Jungle");
    }

    public void LoadHomeJungle()
    {
        _musicManager.SetClip(MusicSceneType.Menu);
        SceneManager.LoadScene("Home Jungle");
    }

    public void LoadHomeDesert()
    {
        _musicManager.SetClip(MusicSceneType.Menu);
        SceneManager.LoadScene("Home");
    }

    public void OpenHome()
    {
        _musicManager.SetClip(MusicSceneType.Menu);
        _settings.SetActive(false);
        _records.SetActive(false);
        _store.SetActive(false);
    }

    public void OpenSettings()
    {
        _settings.SetActive(true);
        _records.SetActive(false);
        _store.SetActive(false);
    }

    public void OpenRecords()
    {
        _settings.SetActive(false);
        _records.SetActive(true);
        _store.SetActive(false);
    }

    public void OpenStore()
    {
        _musicManager.SetClip(MusicSceneType.Store);
        _settings.SetActive(false);
        _records.SetActive(false);
        _store.SetActive(true);
    }
}

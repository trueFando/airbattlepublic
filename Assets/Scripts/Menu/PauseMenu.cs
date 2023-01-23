using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _pauseCanvas;
    private float _timeScaleBeforePause = 1f;

    [SerializeField] private MusicSceneType _sceneType;
    private MusicManager _musicManager;

    private void Start()
    {
        _musicManager = FindObjectOfType<MusicManager>();
        _musicManager.SetClip(_sceneType);
    }

    public void PauseGame()
    {
        _timeScaleBeforePause = Time.timeScale;
        Time.timeScale = 0f;
        ShowPauseCanvas(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        ShowGameOverCanvas();
    }

    public void UnpauseGame()
    {
        Time.timeScale = _timeScaleBeforePause;
        ShowPauseCanvas(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Home");
    }

    public void LoadMenuJunlge()
    {
        SceneManager.LoadScene("Home Jungle");
    }

    private void ShowPauseCanvas(bool active)
    {
        _pauseCanvas.SetActive(active);
    }

    private void ShowGameOverCanvas()
    {
        _gameOverCanvas.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private float _time;
    private int _score;

    [SerializeField] private Text _scoreGameOver;
    [SerializeField] private Text _highGameOver;

    private void Start()
    {
        _score = 0;
        _time = 0f;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _score = (int) _time;
        _scoreText.text = _score.ToString();
    }

    public void CheckForHigh()
    {
        if (_score > PlayerPrefs.GetInt("high")) PlayerPrefs.SetInt("high", _score);
        _scoreGameOver.text = $"SCORE\n{_score}";
        _highGameOver.text = $"HIGH\n{PlayerPrefs.GetInt("high")}";
    }
}

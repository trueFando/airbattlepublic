using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    private int _hp;
    [SerializeField] private HealthDisplayer _healthDisplayer;
    [SerializeField] private PauseMenu _pauseMenu;

    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _hp = _maxHP;
    }

    private void Start()
    {
        if (GetComponent<PlayerMotor>() != null) _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0) Die();

        if (GetComponent<PlayerMotor>() != null) _healthDisplayer.DisplayHealth(_hp);
    }

    public void AddHP(int hp)
    {
        if (_hp + hp <= _maxHP) _hp += hp;
        else _hp = _maxHP;

        if (GetComponent<PlayerMotor>() != null) _healthDisplayer.DisplayHealth(_hp);
    }

    public void Die()
    {
        if (GetComponent<PlayerMotor>() == null) Destroy(gameObject); // For enemies
        else GameOver();
    }

    private void GameOver()
    {
        GetComponent<PlayerSoundFX>().LossSound();
        Time.timeScale = 0f;
        _scoreKeeper.CheckForHigh();
        _pauseMenu.GameOver();
    }
}

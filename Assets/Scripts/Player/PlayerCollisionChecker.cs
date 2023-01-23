using UnityEngine;

public class PlayerCollisionChecker : MonoBehaviour
{
    private Health _playerHP;
    private PlayerFuel _playerFuel;
    private PlayerShooter _playerShooter;
    private PlayerAcceleration _playerAcceleration;

    private MoneyKeeper _moneyKeeper;
    private PlayerSoundFX _playerSoundFX;

    private void Start()
    {
        _playerSoundFX = GetComponent<PlayerSoundFX>();
        _moneyKeeper = FindObjectOfType<MoneyKeeper>();
        _playerAcceleration = GetComponent<PlayerAcceleration>();
        _playerFuel = GetComponent<PlayerFuel>();
        _playerHP = GetComponent<Health>();
        _playerShooter = GetComponent<PlayerShooter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DamageDealer>() != null)
        {
            _playerHP.TakeDamage(1);
        }

        if (collision.GetComponent<Accelerator>() != null)
        {
            _playerAcceleration.Accelerate();
        }

        if (collision.GetComponent<Ammo>() != null)
        {
            _playerSoundFX.AmmoSound();
            _playerShooter.AccelerateShooting();
        }

        if (collision.GetComponent<Fuel>() != null)
        {
            _playerSoundFX.FuelSound();
            _playerFuel.AddFuel(1);
        }

        if (collision.GetComponent<Coin>() != null)
        {
            _playerSoundFX.CoinSound();
            _moneyKeeper.AddMoney(10);
        }

        if (collision.GetComponent<Heart>() != null)
        {
            _playerHP.AddHP(1);
        }

        Destroy(collision.gameObject);
    }
}
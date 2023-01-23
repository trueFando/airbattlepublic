using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    [Header("Timings")]
    private float _defaultShootCooldown;
    [SerializeField] private float _shootCooldown;
    [SerializeField] private float _accelerationDuration;

    [Header("Bullet")]
    [SerializeField] private GameObject[] _bulletTypes;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    private AmmoType _ammoType;

    [Header("Guns")]
    [SerializeField] private Transform[] _guns;

    private PlayerSoundFX _playerSoundFX;

    private void Start()
    {
        AmmoCounter.GetCountsFromStorage(); // get info from disk
        SetAmmoType(); // check what type is chosen and set prefab
        _defaultShootCooldown = _shootCooldown;
        _playerSoundFX = GetComponent<PlayerSoundFX>();

        StartCoroutine(ShootingRoutine());
    }

    // Bullet from picker
    public void SelectBulletType(GameObject bullet)
    {
        _bulletPrefab = bullet;
    }

    public void AccelerateShooting()
    {
        _shootCooldown = _defaultShootCooldown;
        StopCoroutine(ShootingAcceleration());
        StartCoroutine(ShootingAcceleration());
    }

    private IEnumerator ShootingRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(_shootCooldown);
        }
    }

    private IEnumerator ShootingAcceleration()
    {
        _shootCooldown /= 2;
        yield return new WaitForSeconds(_accelerationDuration);
        _shootCooldown *= 2;
    }

    private void Shoot()
    {
        if (AmmoCounter.HaveAmmo(_ammoType))
        {
            _playerSoundFX.ShotSound();
            foreach (Transform gun in _guns)
            {
                var bullet = Instantiate(_bulletPrefab, gun.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * _bulletSpeed;
            }
            AmmoCounter.ReduceAmmoCount(_ammoType);
        }
    }

    private void SetAmmoType()
    {
        _ammoType = (AmmoType)PlayerPrefs.GetInt("ammo");
        _bulletPrefab = _bulletTypes[(int)_ammoType];
    }
}

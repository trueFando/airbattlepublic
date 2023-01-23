using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuel : MonoBehaviour
{
    [SerializeField] private float _reducingCooldown;
    [SerializeField] private int _maxFuel;
    private int _fuel;
    private bool _hasFuel = true;

    [SerializeField] private FuelDisplayer _fuelDisplayer;

    private void Awake()
    {
        _fuel = _maxFuel;
    }

    private void Start()
    {
        StartCoroutine(ReducingRoutine());
    }

    private IEnumerator ReducingRoutine()
    {
        while (_hasFuel)
        {
            yield return new WaitForSeconds(_reducingCooldown);
            ReduceFuel(1);
        }
    } 

    private void ReduceFuel(int fuel)
    {
        _fuel -= fuel;
        if (_fuel <= 0)
        {
            GetComponent<Health>().Die();
            _hasFuel = false;
        }

        _fuelDisplayer.DisplayFuel(_fuel);
    }

    public void AddFuel(int fuel)
    {
        if (_fuel + fuel <= _maxFuel) _fuel += fuel;
        else _fuel = _maxFuel;

        _fuelDisplayer.DisplayFuel(_fuel);
    }
}

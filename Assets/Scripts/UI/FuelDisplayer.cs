using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject[] _fuelPoints;

    public void DisplayFuel(int fuel)
    {
        if (fuel > _fuelPoints.Length) return;
        for (int i = 0; i < _fuelPoints.Length; i++)
        {
            if (i < fuel) _fuelPoints[i].SetActive(false);
            else _fuelPoints[i].SetActive(true);
        }
    }
}

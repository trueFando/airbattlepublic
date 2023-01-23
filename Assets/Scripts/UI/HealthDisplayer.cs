using UnityEngine;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject[] _healthPoints;

    public void DisplayHealth(int hp)
    {
        if (hp > _healthPoints.Length) return;
        for (int i = 0; i < _healthPoints.Length; i++)
        {
            if (i < hp) _healthPoints[i].SetActive(true);
            else _healthPoints[i].SetActive(false);
        }
    }
}

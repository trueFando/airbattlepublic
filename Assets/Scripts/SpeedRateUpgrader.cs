using UnityEngine;

public class SpeedRateUpgrader : MonoBehaviour
{
    private float _time;

    private void Start()
    {
        Time.timeScale = 1f;
        SpeedRate.ResetRate();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time > 10f)
        {
            SpeedRate.UpdateRate();
            _time = 0f;
        }
    }
}

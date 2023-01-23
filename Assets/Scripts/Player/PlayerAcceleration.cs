using System.Collections;
using UnityEngine;

public class PlayerAcceleration : MonoBehaviour
{
    [SerializeField] private float _accelerationDuration;
    [SerializeField] private float _accelerationTimeScale;

    public void Accelerate()
    {
        StopAllCoroutines();
        StartCoroutine(AccelerationRoutine());
    }

    private IEnumerator AccelerationRoutine()
    {
        Time.timeScale = _accelerationTimeScale;
        yield return new WaitForSecondsRealtime(_accelerationDuration);
        Time.timeScale = 1f;
    }
}

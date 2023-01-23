using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    private float _speed = 5f;

    private void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        transform.position -= new Vector3(0, _speed * Time.deltaTime * SpeedRate.Rate, 0);
    }
}

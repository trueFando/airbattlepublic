using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerInputHandler _inputHandler;
    [SerializeField] private PlayerBoundsChecker _boundsChecker;

    private void Update()
    {
        Move(_inputHandler.GetHorizontalMovement());
    }

    private void Move(float direction)
    {
        if (direction != 0)
        {
            Vector3 delta = new Vector3(direction * _speed * Time.deltaTime, 0f, 0f);
            Vector2 newPosition = new Vector2();
            newPosition.x = Mathf.Clamp(transform.position.x + delta.x, _boundsChecker.MinBounds.x, _boundsChecker.MaxBounds.x);
            newPosition.y = Mathf.Clamp(transform.position.y + delta.y, _boundsChecker.MinBounds.y, _boundsChecker.MaxBounds.y);

            transform.position = newPosition;
        }
    }
}

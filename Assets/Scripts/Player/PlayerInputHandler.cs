using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public float GetHorizontalMovement()
    {
        float direction = 0f;
        if (Input.GetMouseButton(0))
        {
            if (_camera.ScreenToViewportPoint(Input.mousePosition).x > 0.5f)
            {
                direction = 1f;
            }
            else if (_camera.ScreenToViewportPoint(Input.mousePosition).x < 0.5f)
            {
                direction = -1f;
            }
        }
        return direction;
    }
}

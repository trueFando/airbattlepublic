using UnityEngine;

public class CameraSizeScaler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;
    private Camera _cam;

    private void Start()
    {
        _cam = GetComponent<Camera>();
        SetOrthoSize();
    }

    private void SetOrthoSize()
    {
        float size = _backgroundSpriteRenderer.bounds.size.x * Screen.height / Screen.width * 0.5f;
        _cam.orthographicSize = size;
    }
}

using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;

    private void Update()
    {
          _spriteRenderer.material.mainTextureOffset += new Vector2(0f, _speed * Time.deltaTime * SpeedRate.Rate);
    }
}

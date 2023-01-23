using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundsChecker : MonoBehaviour
{
    private Vector2 _minBounds;
    private Vector2 _maxBounds;

    public Vector2 MinBounds => _minBounds;
    public Vector2 MaxBounds => _maxBounds;

    [Header("Paddings (depend on object size)")]
    [SerializeField] private float _leftPadding;
    [SerializeField] private float _rightPadding;

    private void Start()
    {
        SetBounds();
    }

    private void SetBounds()
    {
        Camera mainCamera = Camera.main;

        _minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0)) + new Vector3(_leftPadding, 0f, 0f);
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1)) - new Vector3(_rightPadding, 0f, 0f);
    }
}

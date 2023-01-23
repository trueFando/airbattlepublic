using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour
{
    [SerializeField] private float _lifetime;

    private void Start()
    {
        Invoke("KillMe", _lifetime);
    }

    private void KillMe()
    {
        Destroy(gameObject);
    }
}

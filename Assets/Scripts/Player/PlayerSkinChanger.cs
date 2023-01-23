using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] _skins;
    private Sprite _skin;

    private void Start()
    {
        SetSkin();
    }

    public void SetSkin()
    {
        _skin = _skins[PlayerPrefs.GetInt("currentPlane")];
        GetComponentInChildren<SpriteRenderer>().sprite = _skin;
    }
}

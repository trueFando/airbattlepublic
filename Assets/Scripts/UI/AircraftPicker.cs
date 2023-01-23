using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftPicker : MonoBehaviour
{
    [SerializeField] private Text _boughtPlaneText;
    [SerializeField] private PayButton _payButton;
    [SerializeField] private Button[] _planes;
    [SerializeField] private int[] _prices;

    private Button _pickedAirplane;
    private string[] _planeNames = { "Standard Aircraft", "The Desert Wanderer", "The Forest Hunter" };
    private PlayerSkinChanger _playerSkinChanger;

    private void Start()
    {
        _playerSkinChanger = FindObjectOfType<PlayerSkinChanger>();
        PlayerPrefs.SetInt("havePlane0", 1); // fast bug avoiding
        _pickedAirplane = _planes[PlayerPrefs.GetInt("currentPlane")];
        _boughtPlaneText.text = _planeNames[PlayerPrefs.GetInt("currentPlane")];
        HighlightPlane(PlayerPrefs.GetInt("currentPlane"));
    }

    public void TryPickPlane(Button plane)
    {
        HighlightPlane(Array.IndexOf(_planes, plane));
        _boughtPlaneText.text = _planeNames[Array.IndexOf(_planes, plane)];

        if (PlayerPrefs.GetInt($"havePlane{Array.IndexOf(_planes, plane)}") == 1) // if we have
        {
            _payButton.gameObject.SetActive(false);
            _pickedAirplane = plane;
            PlayerPrefs.SetInt("currentPlane", Array.IndexOf(_planes, plane));

            _playerSkinChanger.SetSkin();
        }
        else
        {
            _payButton.gameObject.SetActive(true);
            _payButton.PPKey = $"havePlane{Array.IndexOf(_planes, plane)}";
            _payButton.Price = _prices[Array.IndexOf(_planes, plane)];
        }
    }

    private void HighlightPlane(int id)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i != id)
            {
                Color tcolor = _planes[i].GetComponent<Image>().color;
                tcolor.a = 0.5f;
                _planes[i].GetComponent<Image>().color = tcolor;
            }
            else
            {
                Color tcolor = _planes[i].GetComponent<Image>().color;
                tcolor.a = 1f;
                _planes[i].GetComponent<Image>().color = tcolor;
            }
        }
    }
}

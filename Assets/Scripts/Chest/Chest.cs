using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField] private Sprite _opened;
    [SerializeField] private GameObject _coins;
    [SerializeField] private GameObject _menuButton;

    public void Open()
    {
        _menuButton.SetActive(true);
        _coins.SetActive(true);
        GetComponent<Image>().sprite = _opened;
        FindObjectOfType<MoneyKeeper>().AddMoney(250);
        GetComponent<Button>().interactable = false;
    }
}

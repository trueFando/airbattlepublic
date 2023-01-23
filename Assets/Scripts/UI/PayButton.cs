using UnityEngine;
using UnityEngine.UI;

public class PayButton : MonoBehaviour
{
    private PlayerSkinChanger _playerSkinChanger;
    [SerializeField] private Text _priceText;
    [SerializeField] private MoneyKeeper _moneyKeeper;
    private int _price;

    private string _ppKey; // "havePlane1" or "haveAmmo1"
    public string PPKey 
    { 
        get { return _ppKey; } 
        set { _ppKey = value; }
    }

    public int Price
    {
        get { return _price; }
        set 
        { 
            _price = value;
            _priceText.text = _price.ToString();
        }
    }

    private void Start()
    {
        _playerSkinChanger = FindObjectOfType<PlayerSkinChanger>();
    }

    public void Pay()
    {
        if (_moneyKeeper.TryBuy(_price))
        {
            PlayerPrefs.SetInt(_ppKey, 1);
            PlayerPrefs.SetInt("currentPlane", int.Parse(PPKey[PPKey.Length - 1].ToString()));
            _playerSkinChanger.SetSkin();
            gameObject.SetActive(false);
        }
    }
}

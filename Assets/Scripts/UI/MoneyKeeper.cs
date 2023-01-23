using UnityEngine;
using UnityEngine.UI;

public class MoneyKeeper : MonoBehaviour
{
    [SerializeField] private Text[] _moneyCounterTexts;
    private int _money;

    private void Start()
    {
        _money = PlayerPrefs.GetInt("money");
        foreach (Text text in _moneyCounterTexts)
        {
            text.text = _money.ToString();
        }
    }

    public void AddMoney(int money)
    {
        _money += money;
        PlayerPrefs.SetInt("money", _money);
        foreach (Text text in _moneyCounterTexts)
        {
            text.text = _money.ToString();
        }
    }

    public bool TryBuy(int price)
    {
        if (price > _money)
        {
            return false;
        }
        else
        {
            Buy(price);
            return true;
        }
    }

    private void Buy(int price)
    {
        _money -= price;
        PlayerPrefs.SetInt("money", _money);
        foreach (Text text in _moneyCounterTexts)
        {
            text.text = _money.ToString();
        }
    }
}

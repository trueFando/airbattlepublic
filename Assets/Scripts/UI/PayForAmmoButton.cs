using UnityEngine;
using UnityEngine.UI;

public class PayForAmmoButton : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private Text _priceText;
    [SerializeField] private AmmoType _ammoType;
    [SerializeField] private MoneyKeeper _moneyKeeper;

    private int _amount = 50; // how many shots we sell

    private AmmoToggle _ammoToggle;

    private void Start()
    {
        _ammoToggle = FindObjectOfType<AmmoToggle>();
        _priceText.text = _price.ToString();
    }

    public void Pay()
    {
        if (_moneyKeeper.TryBuy(_price))
        {
            AmmoCounter.IncreaseAmmoCount(_ammoType, _amount);
            _ammoToggle.SetAmountTexts();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class AmmoToggle : MonoBehaviour
{
    [SerializeField] private Toggle _std;
    [SerializeField] private Toggle _jungle;
    [SerializeField] private Toggle _space;

    [SerializeField] private Text _stdCountText;
    [SerializeField] private Text _jungleCountText;
    [SerializeField] private Text _spaceCountText;

    private void Start()
    {
        AmmoCounter.GetCountsFromStorage();
        SetAmountTexts();
    }

    private void OnEnable()
    {
        GameObject tgl = new GameObject();
        tgl.SetActive(false);
        Toggle toggleComponent = tgl.AddComponent<Toggle>();
        toggleComponent.isOn = true;

        if (PlayerPrefs.GetInt("ammo") == 0) PickStd(toggleComponent);
        else if (PlayerPrefs.GetInt("ammo") == 1) PickJungle(toggleComponent);
        else if (PlayerPrefs.GetInt("ammo") == 2) PickSpace(toggleComponent);

        Destroy(tgl);
    }

    public void PickStd(Toggle tgl)
    {
        if (tgl.isOn)
        {
            _std.isOn = true;
            _jungle.isOn = false;
            _space.isOn = false;
            SavePickedAmmo(0);
        }
    }

    public void PickJungle(Toggle tgl)
    {
        if (tgl.isOn)
        {
            _std.isOn = false;
            _jungle.isOn = true;
            _space.isOn = false;
            SavePickedAmmo(1);
        }
    }

    public void PickSpace(Toggle tgl)
    {
        if (tgl.isOn)
        {
            _std.isOn = false;
            _jungle.isOn = false;
            _space.isOn = true;
            SavePickedAmmo(2);
        }
    }

    // use this ammo type on player plane
    private void SavePickedAmmo(int ind)
    {
        PlayerPrefs.SetInt("ammo", ind);
    }

    public void SetAmountTexts()
    {
        _stdCountText.text = AmmoCounter.Std.ToString();
        _jungleCountText.text = AmmoCounter.Jungle.ToString();
        _spaceCountText.text = AmmoCounter.Space.ToString();
    }
}

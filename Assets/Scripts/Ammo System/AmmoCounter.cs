using UnityEngine;

public static class AmmoCounter
{
    private static int _std;
    private static int _jungle;
    private static int _space;

    public static int Std => _std;
    public static int Jungle => _jungle;
    public static int Space => _space;

    public static void GetCountsFromStorage()
    {
        _std = PlayerPrefs.GetInt("stdAmmo");
        _jungle = PlayerPrefs.GetInt("jungleAmmo");
        _space = PlayerPrefs.GetInt("spaceAmmo");
    }

    private static void SaveCountsInStorage()
    {
        PlayerPrefs.SetInt("stdAmmo", _std);
        PlayerPrefs.SetInt("jungleAmmo", _jungle);
        PlayerPrefs.SetInt("spaceAmmo", _space);
    }

    public static bool HaveAmmo(AmmoType type)
    {
        if (type == AmmoType.Std) return _std > 0;
        else if (type == AmmoType.Jungle) return _jungle > 0;
        else if (type == AmmoType.Space) return _space > 0;

        return false;
    }

    public static void ReduceAmmoCount(AmmoType type)
    {
        if (type == AmmoType.Std) _std--;
        else if (type == AmmoType.Jungle) _jungle--;
        else if (type == AmmoType.Space) _space--;

        SaveCountsInStorage();
    }

    public static void IncreaseAmmoCount(AmmoType type, int count)
    {
        if (type == AmmoType.Std) _std += count;
        else if (type == AmmoType.Jungle) _jungle += count;
        else if (type == AmmoType.Space) _space += count;

        SaveCountsInStorage();
    }
}

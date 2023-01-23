public static class SpeedRate
{
    private static float _rate = 1f;
    public static float Rate => _rate;

    public static void UpdateRate()
    {
        _rate += 0.05f;
    }

    public static void ResetRate()
    {
        _rate = 1f;
    }
}

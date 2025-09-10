using System;

public static class SailedShipEventNotification
{
    public static Action SpeedChanged;

    public static void OnSpeedChanged()
    {
        SpeedChanged?.Invoke();
    }
}
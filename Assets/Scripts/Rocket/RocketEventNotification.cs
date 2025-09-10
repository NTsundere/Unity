using System;

public static class RocketEventNotification
{
    public static event Action ScoreChanged;
    public static event Action HealthChanged;
    public static event Action Died;

    public static void OnScoreChanged()
    {
        ScoreChanged?.Invoke();
    }
    public static void OnHealthChanged()
    {
        HealthChanged?.Invoke();
    }
    public static void OnDied()
    {
        Died?.Invoke();
    }

}
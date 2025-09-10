using System;

public static class BirdEventNotification
{
    public static event Action ScoreChanged;
    public static event Action Died;

    public static void OnScoreChanged()
    {
        ScoreChanged?.Invoke();
    }    
    
    public static void OnDied()
    {
        Died?.Invoke();
    }
}


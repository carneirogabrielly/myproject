using UnityEngine;

public static class GameController
{
    public const int TotalCollectables = 4;
    public const float TimeLimit = 20f;
    public const int InitialHealth = 3;

    public static int score;
    public static int health;
    public static float currentTime;
    public static float finalTime;
    public static bool hasEnded;
    public static bool hasWon;

    public static bool gameOver => hasEnded;
    public static float TimeRemaining => Mathf.Max(0f, TimeLimit - currentTime);

    public static void Init()
    {
        score = 0;
        health = InitialHealth;
        currentTime = 0f;
        finalTime = 0f;
        hasEnded = false;
        hasWon = false;
    }

    public static void Tick(float deltaTime)
    {
        if (hasEnded) return;
        currentTime += deltaTime;
        if (currentTime >= TimeLimit)
        {
            End(won: false);
        }
    }

    public static void Collect()
    {
        if (hasEnded) return;
        score++;
        if (score >= TotalCollectables)
        {
            End(won: true);
        }
    }

    public static void TakeDamage()
    {
        if (hasEnded) return;
        health--;
        if (health <= 0)
        {
            End(won: false);
        }
    }

    private static void End(bool won)
    {
        hasEnded = true;
        hasWon = won;
        finalTime = currentTime;
    }
}

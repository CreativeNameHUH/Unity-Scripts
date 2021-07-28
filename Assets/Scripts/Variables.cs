using UnityEngine;

public class Variables : MonoBehaviour
{
    // @@info Player's variables
    public static float PlayerHealth = 100f;

    public static float PlayerSpeed = 2f;
    public static float PlayerSprint = 4f;
    public static float PlayerJump = 2f;
    public static float PlayerPoints = 500f;

    public static int PlayerTotalKills = 0;
    public static int PlayerKillsInRound = 0;

    public static bool PlayerExtraHealth = false;

    public static float PlayerGunDamage = 35f;
    public static float PlayerGunRange = 100f;
    
    public static int PlayerGunMagSize = 30;

    public static bool PlayerGunUpgrade = false;

    // @@info Enemy's variables
    public static float EnemyHealth = 30f;

    public static float EnemyGunDamage = 2f;
    public static float EnemyGunRange = 100f;

    public static int EnemyAmount = 2;

    // @@info GameArea's variables
    public static float GameAreaSize = 1f;

    public static bool GameNewObjectPool = false;
    public static bool GameNewSpawnTimer = false;
    public static bool GameAreaUpdate = false;
}
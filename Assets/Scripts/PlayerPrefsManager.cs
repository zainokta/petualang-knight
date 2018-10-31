using UnityEngine;

public class PlayerPrefsManager {
    const string masterVolume = "master_volume";
    const string GOLD = "Gold";
    const string MOON_STONE = "Moon Stone";
    const string DAMAGE = "Damage";
    const string HEALTH = "Health";
    const string MAXHEALTH = "Max Health";
    const string UNLOCK = "Unlock";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(masterVolume, volume);
        }
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(masterVolume);
    }

    public static void SetPlayerGold(int gold)
    {
        PlayerPrefs.SetInt(GOLD,gold);
    }
    public static int GetPlayerGold()
    {
        return PlayerPrefs.GetInt(GOLD);
    }

    public static void SetPlayerMoonStone(int moonStone)
    {
        PlayerPrefs.SetInt(MOON_STONE, moonStone);
    }
    public static int GetPlayerMoonStone()
    {
        return PlayerPrefs.GetInt(MOON_STONE);
    }

    public static void SetPlayerDamage(int damage)
    {
        PlayerPrefs.SetInt(DAMAGE, damage);
    }
    public static int GetPlayerDamage()
    {
        return PlayerPrefs.GetInt(DAMAGE);
    }

    public static void SetPlayerMaxHealth(int maxHealth)
    {
        PlayerPrefs.SetInt(MAXHEALTH, maxHealth);
    }
    public static int GetPlayerMaxHealth()
    {
        return PlayerPrefs.GetInt(MAXHEALTH);
    }

    public static void SetPlayerHealth(int health)
    {
        PlayerPrefs.SetInt(HEALTH, health);
    }
    public static int GetPlayerHealth()
    {
        return PlayerPrefs.GetInt(HEALTH);
    }

    public static void SetDashBool(int condition)
    {
        PlayerPrefs.SetInt(UNLOCK, condition);
    }
    public static int GetDashBool()
    {
        return PlayerPrefs.GetInt(UNLOCK);
    }
}
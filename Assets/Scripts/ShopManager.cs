using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
    public int npcMoonStoneOwned;
    public Text playerGoldText;
    public Text playerMoonStoneText;

    private int playerGold;
    private int playerMoonStone;
    private int playerDamage;
    private int playerHealth;

    private void Start()
    {
        playerGold = PlayerPrefsManager.GetPlayerGold();
        playerMoonStone = PlayerPrefsManager.GetPlayerMoonStone();
        playerDamage = PlayerPrefsManager.GetPlayerDamage();
        playerHealth = PlayerPrefsManager.GetPlayerHealth();
    }

    private void Update()
    {
        playerGoldText.text = "Gold : " + playerGold;
        playerMoonStoneText.text = "Moon Stone : " + playerMoonStone;
    }

    public void UpgradeWeaponOne(int price)
    {
        if(playerGold >= price && playerMoonStone > 0)
        {
            playerGold -= price;
            PlayerPrefsManager.SetPlayerGold(playerGold);
            playerDamage += 3;
            PlayerPrefsManager.SetPlayerDamage(playerDamage);
            playerMoonStone--;
            npcMoonStoneOwned++;
        }
    }
    public void UpgradeWeaponTwo(int price)
    {
        if (playerGold >= price && playerMoonStone >= 3)
        {
            playerGold -= price;
            PlayerPrefsManager.SetPlayerGold(playerGold);
            playerDamage += 7;
            PlayerPrefsManager.SetPlayerDamage(playerDamage);
            playerMoonStone -= 3;
            npcMoonStoneOwned += 3;
        }
    }
    public void UpgradeWeaponThree(int price)
    {
        if (playerGold >= price && playerMoonStone >= 7)
        {
            playerGold -= price;
            PlayerPrefsManager.SetPlayerGold(playerGold);
            playerDamage += 15;
            PlayerPrefsManager.SetPlayerDamage(playerDamage);
            playerMoonStone -= 7;
            npcMoonStoneOwned += 7;
        }
    }
    public void UpgradeWeaponFour(int price)
    {
        if (playerGold >= price && playerMoonStone >= 10)
        {
            playerGold -= price;
            PlayerPrefsManager.SetPlayerGold(playerGold);
            playerDamage += 35;
            PlayerPrefsManager.SetPlayerDamage(playerDamage);
            playerMoonStone -= 10;
            npcMoonStoneOwned += 10;
        }
    }
    public void UpgradeHealth(int price)
    {
        if (playerGold >= price)
        {
            playerGold -= price;
            PlayerPrefsManager.SetPlayerGold(playerGold);
            playerHealth += 20;
            PlayerPrefsManager.SetPlayerMaxHealth(playerHealth);
            PlayerPrefsManager.SetPlayerHealth(playerHealth);
        }
    }

    public void TradeGoldForMoonStone(int price)
    {
        if (playerGold >= price && npcMoonStoneOwned > 0)
        {
            playerGold -= price;
            PlayerPrefsManager.SetPlayerGold(playerGold);
            playerMoonStone++;
            PlayerPrefsManager.SetPlayerMoonStone(playerMoonStone);
            npcMoonStoneOwned--;
        }
    }

    public void UnlockDash(int price)
    {
        if(playerGold >= price)
        {
            playerGold -= price;
            PlayerPrefsManager.SetPlayerGold(playerGold);
            PlayerPrefsManager.SetDashBool(1);
        }
    }
}

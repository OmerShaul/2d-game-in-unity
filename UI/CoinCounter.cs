using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public TMP_Text CoinText;
    private string coinCountKey = "CoinCount"; // Key to save and load the coin count in PlayerPrefs

    private void Start()
    {
        int currentCoins = PlayerPrefs.GetInt(coinCountKey, 0);
        UpdateCoinText(currentCoins);
    }

    public void IncreaseCoins(int amount)
    {
        int currentCoins = PlayerPrefs.GetInt(coinCountKey, 0);
        currentCoins += amount;
        UpdateCoinText(currentCoins);

        // Save the updated coin count to PlayerPrefs
        PlayerPrefs.SetInt(coinCountKey, currentCoins);
    }

    private void UpdateCoinText(int coinCount)
    {
        CoinText.text = coinCount.ToString();
    }
}

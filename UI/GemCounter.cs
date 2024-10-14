using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCounter : MonoBehaviour
{
    public TMP_Text GemText;
    private string gemCountKey = "GemCount"; // Key to save and load the coin count in PlayerPrefs

    private void Start()
    {
        int currentGems = PlayerPrefs.GetInt(gemCountKey, 0);
        UpdateGemText(currentGems);
    }

    public void IncreaseGems(int amount)
    {
        int currentGems = PlayerPrefs.GetInt(gemCountKey, 0);
        currentGems += amount;
        UpdateGemText(currentGems);

        // Save the updated coin count to PlayerPrefs
        PlayerPrefs.SetInt(gemCountKey, currentGems);
    }

    private void UpdateGemText(int gemCount)
    {
        GemText.text = gemCount.ToString();
    }
}

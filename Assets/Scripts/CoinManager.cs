using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int coins;
    public static CoinManager instance;


    private void Start()
    {
        LoadCoins();
    }

    public void AddCoin()
    {
        coins++;
        SaveCoins();
    }

    public int GetCoins()
    {
        return coins;
    }

    public void LoadCoins()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }
}

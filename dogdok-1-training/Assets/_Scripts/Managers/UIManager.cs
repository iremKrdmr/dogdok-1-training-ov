using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text CoinText;
    public GameObject DeathScreen;
    public PlayerGatherer PlayerGatherer;
    public CoinManager CoinManager;

    private void Start()
    {
        if (DeathScreen != null) DeathScreen.SetActive(false);
    }

    private void Update()
    {
        if (CoinText != null) CoinText.text = "Coins: " + PlayerGatherer.CoinsCollected + "/" + CoinManager.CoinsToCollect;
    }

    public void BringDeathScreenUp() 
    {
        DeathScreen.SetActive(true);
    }
}

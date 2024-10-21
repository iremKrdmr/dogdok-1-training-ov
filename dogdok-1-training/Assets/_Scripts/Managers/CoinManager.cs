using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public PlayerGatherer PlayerGatherer;
    public GameObject LevelEnder;

    public bool LevelCompleted;
    public int CoinsToCollect;

    private void Start()
    {
        LevelEnder.SetActive(false);
        LevelCompleted = false;
    }

    private void Update()
    {
        if (LevelCompleted) return;

        if (PlayerGatherer.CoinsCollected >= CoinsToCollect)
        {
            LevelEnder.SetActive(true);
            LevelCompleted = true;
        }
    }
}

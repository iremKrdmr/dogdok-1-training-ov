using UnityEngine;

public class PlayerGatherer : MonoBehaviour
{
    public int CoinsCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CoinsCollected++;
            Destroy(other.gameObject);
        }
    }
}

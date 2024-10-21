using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    public GameManager GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.KillPlayer();
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;
    public PlayerMovement PlayerMovement;
    public PlayerCameraController PlayerCameraController;

    private void Start()
    {
        DisableCursor();
    }

    public void KillPlayer()
    {
        EnableCursor();

        UIManager.BringDeathScreenUp();
        PlayerMovement.enabled = false;
        PlayerMovement.Rigidbody.useGravity = false;
        PlayerMovement.Rigidbody.velocity = Vector3.zero;
        PlayerCameraController.enabled = false;
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void DisableCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

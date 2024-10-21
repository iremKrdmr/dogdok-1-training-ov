using UnityEngine;

public class GameOverScreenManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

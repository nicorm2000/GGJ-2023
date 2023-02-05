using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        PauseMenu.isPause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
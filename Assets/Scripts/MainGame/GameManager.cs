using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private float lifes = 100;

    [SerializeField] private Transform player = null;

    [SerializeField] private GameObject endCanvas = null;

    public void LoseLife(int damage)
    {
        lifes -= damage;
        if (lifes<0)
        {
            endCanvas.SetActive(true);
            PauseMenu.isPause = true;
            //lose windows;
        }
    }
    public void RegenAllLife(float maxLife)
    {
        lifes = maxLife;
    }

    public float getLife()
    { 
        return lifes; 
    }

    public Transform GetPlayer()
    {
        return player;
    }
}

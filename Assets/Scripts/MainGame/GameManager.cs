using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private float lifes = 100;

    [SerializeField] private Transform player = null;

    public void LoseLife(int damage)
    {
        lifes -= damage;
        if (lifes<0)
        {
            //lose windows;
        }
    }
    public void winLife(float life)
    {
        lifes += life;
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

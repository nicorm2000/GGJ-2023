using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private int lifes = 100;

    [SerializeField] private Transform player = null;

    public void LoseLife(int damage)
    {
        lifes -= damage;
        if (lifes<0)
        {
            //lose windows;
        }
    }

    public Transform GetPlayer()
    {
        return player;
    }
}

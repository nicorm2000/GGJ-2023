using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int lifes = 100;

    public void LoseLife(int damage)
    {
        lifes -= damage;
        if (lifes<0)
        {
            //lose windows;
        }
    }
}

using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToAtack;
    [SerializeField] private float atackSpeed;
    [SerializeField] private int damage;

    private float DAS = 0; //Delta Atack Speed

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) > distanceToAtack)
            return;

        if (DAS > atackSpeed)
        {
            DAS += Time.deltaTime;
            return;
        }
        DAS = 0;
    }

    private void Atack()
    {
        GameManager.Get().LoseLife(damage);

    }
}

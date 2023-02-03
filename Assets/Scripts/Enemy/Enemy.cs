using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    [SerializeField] private float distanceToAtack;
    [SerializeField] private float atackSpeed;
    [SerializeField] private int damage;

    private Transform target;
    private float DAS = 0; //Delta Atack Speed


    private void Start()
    {
        target = GameManager.Get().GetPlayer();
    }

    private void Update()
    {
        if (target == null)
            return;
        if (PauseMenu.isPause)
            return;
        
        if (Vector3.Distance(target.position, transform.position) > distanceToAtack)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            if (DAS < atackSpeed)
            {
                DAS += Time.deltaTime;
                return;
            }
            else
            {
                DAS = 0;
                Atack();
            }
        }
    }

    private void Atack()
    {
        GameManager.Get().LoseLife(damage);
    }
}

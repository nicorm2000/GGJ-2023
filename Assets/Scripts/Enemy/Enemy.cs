using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    [SerializeField] float speed = 10f;

    [SerializeField] private float distanceToAtack;
    [SerializeField] private float atackSpeed;
    [SerializeField] private int damage;

    [SerializeField] private int lives = 10;
    [SerializeField] private int currencyValue;


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
            transform.LookAt(target);
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

    public void takeDamage(int value)
    {
        lives -= value;
        if (lives > 0)
            return;
        Currency.Get().Income(currencyValue);
        Destroy(gameObject);
    }
}

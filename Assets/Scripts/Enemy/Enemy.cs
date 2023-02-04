using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    [SerializeField] float BaseSpeed = 10f;

    [SerializeField] private float distanceToAtack;
    [SerializeField] private float atackSpeed;
    [SerializeField] private int damage;

    [SerializeField] private float lives = 10;
    [SerializeField] private int currencyValue;

    [SerializeField,Range(0,1)] private float speedPercentaje = 1f;
    [SerializeField] private float speed = 5f;

    [SerializeField]
    private float poisonDamage = 0;

    [SerializeField]
    private float poisonTime = 0;

    [SerializeField]
    private float slowTime = 0;

    [SerializeField]
    private float slowPrc = 1;



    private Transform target;
    private float DAS = 0; //Delta Atack Speed


    private void Start()
    {
        target = GameManager.Get().GetPlayer();
        Debug.Log(target.position);
    }

    public void AffectPoison(float posionDamage,float poisonTime)
    {
        this.poisonTime = poisonTime;
        this.poisonDamage = posionDamage;
    }
    public void AffectedSlow(float slowTime,float prc)
    {
        this.slowPrc = prc;
        this.slowTime = slowTime;
    }


    private void Update()
    {
        if (target == null)
            return;
        if (PauseMenu.isPause)
            return;
        if (poisonTime > 0)
        {
            poisonTime -= Time.deltaTime;
            takeDamage(poisonDamage);
        }
        else if (slowTime > 0)
        {
            slowTime -= Time.deltaTime;
            speedPercentaje = slowPrc;
        }
        else
        {
            speedPercentaje = 1;
        }





        if (Vector3.Distance(target.position, transform.position) > distanceToAtack)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * speedPercentaje * Time.deltaTime, Space.World);
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

    public void takeDamage(float value)
    {
        lives -= value;
        if (lives > 0)
            return;
        Currency.Get().Income(currencyValue);
        Destroy(gameObject);
    }

    public float GetDistanceToCenter()
    {
        return Vector3.Distance(GameManager.Get().GetPlayer().position, transform.position);
        
    }

    public void takeVenom(float damage,float time)
    {
        AffectPoison(damage, time);
    }

    public void takeSlow(float damage, float time,float prc)
    {
        takeDamage(damage);
        AffectedSlow(time, prc);
    }
}

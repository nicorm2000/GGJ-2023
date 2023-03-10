using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField] float speed = 70f;
    [SerializeField] float explosionRadius = 0f;
    [SerializeField] float damage = 1;
    [SerializeField] bool appliedVenom = false;
    [SerializeField] bool appliedSlow = false;
    [SerializeField] float TimeVenom;
    [SerializeField] float TimeSlow;
    [SerializeField] float pctSlow;

    [SerializeField] GameObject impactEffect;

    public void SetExplosive(float area)
    {
        explosionRadius = area;
    }

    public void Seek(Transform _target,float dagame, bool venom = false, bool slow = false, float venomTime = 0, float slowTime=0,float prcSlow=1)
    {
        target = _target;
        this.damage = dagame;
        this.appliedSlow = slow;
        this.appliedVenom = venom;
        this.TimeVenom = venomTime;
        this.TimeSlow = slowTime;
        this.pctSlow = prcSlow;

    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPause)
            return;

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        if (explosionRadius > 0f)
        {
            Explode();
        }

        IDamageable Id = (IDamageable)target.gameObject.GetComponent(typeof(IDamageable));
        if (Id != null)
            if (appliedVenom)
            {
                Id.takeVenom(damage, TimeVenom);
            }
            
            else
            {
                Id.takeDamage(damage);
            }
        
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                IDamageable Id = (IDamageable)collider.gameObject.GetComponent(typeof(IDamageable));

                if (Id != null)
                    if (appliedSlow)
                        Id.takeSlow(damage, TimeSlow, pctSlow);
                
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

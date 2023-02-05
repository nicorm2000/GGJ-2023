using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private enum FOLLOWTO
    {
        CLOSER,
        FIRST,
        LAST
    }

    protected Transform target;

    [Header("Attributes")]
    [Header("NotUpdateables")]

    [SerializeField] protected float range = 10;
    [SerializeField] float fireRate = 10;

    [Header("Updateables")]

    [SerializeField] protected float[] damage;

    private float deltaTimeShoot = 0f;

    [SerializeField] protected int damageLvl = 0;

    [SerializeField] protected int[] priceUpgrade1 = null;
    [SerializeField] protected int[] priceUpgrade2 = null;
    [SerializeField] protected int[] priceUpgrade3 = null;

    [SerializeField]
    FOLLOWTO shootTo = FOLLOWTO.CLOSER;

    [Header("Unity Set Up Fields")]

    [SerializeField] Transform partToRotate =null;
    [SerializeField] float turnSpeed = 10f;

    [SerializeField] protected GameObject bulletPrefab = null;
    [SerializeField] protected Transform firePoint =null;

    void UpdateTarget()
    {
        if (target==null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            
            foreach (Collider collider in colliders)
            {
                
                if (collider.tag == "Enemy")
                {
                    if (target == null)
                    {
                        target = collider.transform;
                    }
                    Enemy e = collider.GetComponent<Enemy>();
                    switch (shootTo)
                    {
                        case FOLLOWTO.CLOSER:
                            if (Vector3.Distance (collider.transform.position,transform.position)< Vector3.Distance(target.position,transform.position))
                                target = collider.transform;
                            break;
                        case FOLLOWTO.FIRST:
                            if (e.GetDistanceToCenter()<target.GetComponent<Enemy>().GetDistanceToCenter())
                                target = collider.transform;
                            break;
                        case FOLLOWTO.LAST:
                            if (e.GetDistanceToCenter() > target.GetComponent<Enemy>().GetDistanceToCenter())
                                target = collider.transform;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        else
            if (Vector3.Distance (target.position,this.transform.position)>range)
                target = null;
    }

    // Update is called once per frame
    protected virtual void Update() //protected virtual void update
    {
        if (PauseMenu.isPause)
            return;
        UpdateTarget();
        if (target ==null)
            return;
        //Target Lock On
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (deltaTimeShoot >= fireRate)
        {
            Shoot();
            deltaTimeShoot = 0;
        }
        else
            deltaTimeShoot += Time.deltaTime;
    }

    public virtual bool BuyUpgrade(int index)
    {
        return false;
    }

    protected virtual void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target,damage[damageLvl]);
        
    }
    public virtual int GetLvlUpgdare(int index) { return 0; }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, range[rangeLvl]);
    }
}

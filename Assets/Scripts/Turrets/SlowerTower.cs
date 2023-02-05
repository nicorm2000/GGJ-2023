using UnityEngine;
public class SlowerTower : Turret
{
    [SerializeField] private float[] damagePrc = null; //mejora 0

    [SerializeField] private float[] slowPrc = null; // mejora 1

    [SerializeField] private float slowDuration = 1;

    [SerializeField] private int slowPrcLvl = 0; //mejora 1

    [SerializeField] private int explotionArea = 0;

    [SerializeField] private int damagePrcLvl = 0; //mejora 0

    public override bool BuyUpgrade(int index)
    {
        switch (index)
        {
            case 0:
                if (Currency.Get().Spend(priceUpgrade1[damagePrcLvl]))
                {
                    damagePrcLvl++;
                    return true;
                }
                return false;
            case 1:
                if (Currency.Get().Spend(priceUpgrade2[slowPrcLvl]))
                {
                    slowPrcLvl++;
                    return true;
                }
                return false;
            default:
                return false;
        }
    }
    protected override void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            float life = target.GetComponent<Enemy>().GetMaxLife();

            bullet.SetExplosive(explotionArea);
            bullet.Seek(target, life * damagePrc[damageLvl],false,true,0,slowDuration,slowPrc[slowPrcLvl]);
        }

    }

    public override int GetLvlUpgdare(int index) 
    {
        switch (index)
        {
            case 0:
                return damagePrcLvl;
            case 1:
                return slowPrcLvl;
            default:
                return 0;
        }
    }

}

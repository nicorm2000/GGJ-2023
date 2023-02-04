using UnityEngine;
public class SlowerTower : Turret
{
    [SerializeField] private float[] slowPrc = null;
    [SerializeField] private float[] slowDuration = null;
    [SerializeField] private float[] explotionRange = null;


    [SerializeField] private int slowPrcLvl = 0;

    [SerializeField] private int slowDurationLvl = 0;

    [SerializeField] private int explotionLvl = 0;

    public override bool BuyUpgrade(int index)
    {
        switch (index)
        {
            case 0:
                if (Currency.Get().Spend(priceUpgrade1[slowPrcLvl]))
                {
                    slowPrcLvl++;
                    return true;
                }
                return false;
            case 1:
                if (Currency.Get().Spend(priceUpgrade2[rangeLvl]))
                {
                    rangeLvl++;
                    return true;
                }
                return false;
            case 2:
                if (Currency.Get().Spend(priceUpgrade1[slowDurationLvl]))
                {
                    slowDurationLvl++;
                    return true;
                }
                return false;
        }
        return false;
    }
    protected override void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.SetExplosive(explotionRange[explotionLvl]);

            bullet.Seek(target, damage[damageLvl],false,true,0,slowDuration[slowDurationLvl],slowPrc[slowPrcLvl]);
        }

    }

}

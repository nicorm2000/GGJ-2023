using UnityEngine;

public class VenomTower : Turret
{
    [SerializeField] private float[] venomDuration = null;

    [SerializeField] private int venomDurationLvl = 0;

    public override bool BuyUpgrade(int index)
    {
        switch (index)
        {
            case 0:
                if (Currency.Get().Spend(priceUpgrade1[damageLvl]))
                {
                    damageLvl++;
                    return true;
                }
                return false;
            case 1:
                if (Currency.Get().Spend(priceUpgrade2[venomDurationLvl]))
                {
                    venomDurationLvl++;
                    return true;
                }
                return false;
            case 2:
                if (Currency.Get().Spend(priceUpgrade1[fireRateLvl]))
                {
                    fireRateLvl++;
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
            bullet.Seek(target, damage[damageLvl], true, false,venomDuration[venomDurationLvl]);

    }
}
    
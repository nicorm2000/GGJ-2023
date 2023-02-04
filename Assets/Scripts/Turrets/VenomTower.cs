using UnityEngine;

public class VenomTower : Turret, IUpdateable
{
    private float[] venomDuration = null;

    private int venomDurationLvl = 0;

    public void BuyUpgrade(int index, int lvl)
    {
        switch (index)
        {
            case 0:
                if (Currency.Get().Spend(priceUpgrade1[damageLvl]))
                    damageLvl++;
                break;
            case 1:
                if (Currency.Get().Spend(priceUpgrade2[venomDurationLvl]))
                    venomDurationLvl++;
                break;
            case 2:
                if (Currency.Get().Spend(priceUpgrade1[fireRateLvl]))
                    fireRateLvl++;
                break;
        }
    }
    protected override void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target, damage[damageLvl], true, false,venomDuration[venomDurationLvl]);

    }
}
    
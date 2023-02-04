using UnityEngine;
public class SlowerTower : Turret, IUpdateable
{
    [SerializeField] private float[] slowPrc = null;
    [SerializeField] private float[] slowDuration = null;

    [SerializeField] private int slowPrcLvl = 0;

    [SerializeField] private int slowDurationLvl = 0;

    public void BuyUpgrade(int index, int lvl)
    {
        switch (index)
        {
            case 0:
                if (Currency.Get().Spend(priceUpgrade1[slowPrcLvl]))
                    slowPrcLvl++;
                break;
            case 1:
                if (Currency.Get().Spend(priceUpgrade2[rangeLvl]))
                    rangeLvl++;
                break;
            case 2:
                if (Currency.Get().Spend(priceUpgrade1[slowDurationLvl]))
                    slowDurationLvl++;
                break;
        }
    }
    protected override void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target, damage[damageLvl],false,true);

    }

}

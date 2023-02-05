using UnityEngine;

public class VenomTower : Turret
{
    [SerializeField] private float venomDuration = 1;

    [SerializeField] private float[] slowPrc = null; // mejora 0

    [SerializeField] private int slowDownLvl = 0; //mejora 0

    [SerializeField] private float slowDuration = 1;

    [SerializeField] private string shootSound;

    public override bool BuyUpgrade(int index)
    {
        switch (index)
        {
            case 0:
                if (slowDownLvl >= 3)
                    return false;
                if (Currency.Get().Spend(priceUpgrade1[slowDownLvl]))
                {
                    slowDownLvl++;
                    return true;
                }
                return false;
            case 1:
                if (damageLvl >= 3)
                    return false;
                if (Currency.Get().Spend(priceUpgrade2[damageLvl]))
                {
                    damageLvl++;
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
            bullet.Seek(target, damage[damageLvl], true, true,venomDuration, slowDuration,slowPrc[slowDownLvl]);
            FindObjectOfType<AudioManager>().Play(shootSound);

        }
    }
    public override int GetLvlUpgdare(int index)
    {
        switch (index)
        {
            case 0:
                return slowDownLvl;
            case 1:
                return damageLvl;
            default:
                return 0;
        }
    }
}
    
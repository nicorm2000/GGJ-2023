using UnityEngine;

public class NormalTurret : Turret
{
    [SerializeField] private float[] explotionRange = null;

    [SerializeField] private int explotionLvl = 0;

    [SerializeField] private string shootSound;

    public override bool BuyUpgrade(int index)
    {
        switch (index)
        {
            case 0:
                if (explotionLvl >= 3)
                    return false;
                if (Currency.Get().Spend(priceUpgrade1[explotionLvl]))
                {
                    explotionLvl++;
                    return true;
                }

                break;
            case 1:
                if (damageLvl >= 3)
                    return false;
                if (Currency.Get().Spend(priceUpgrade2[damageLvl]))
                {
                    damageLvl++;
                    return true;
                }

                break;
            default:
                Debug.LogError("not implemented");
                break;
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
        }

        bullet.Seek(target, damage[damageLvl]);
        FindObjectOfType<AudioManager>().Play(shootSound);
    }

    public override int GetLvlUpgdare(int index)
    {
        switch (index)
        {
            case 0:
                return explotionLvl;
            case 1:
                return damageLvl;
            default:
                return 0;
        }
    }
}
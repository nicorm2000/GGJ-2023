
using UnityEngine;

public class MainTower : Turret
{


    [SerializeField] private float[] maxLife = null;
    [SerializeField] private float[] range = null;

    [SerializeField] private int maxLifeRegenLvl = 0;
    [SerializeField] private int rangeLvl = 0;


    public override bool BuyUpgrade(int index)
    {
        switch (index)
        {
            case 0:
                if (Currency.Get().Spend(priceUpgrade1[maxLifeRegenLvl]))
                {
                    if (maxLifeRegenLvl<2)
                        maxLifeRegenLvl++;
                    Regen();
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
                if (Currency.Get().Spend(priceUpgrade1[damageLvl]))
                {
                    damageLvl++;
                    return true;
                }
                return false;
        }
        return false;
    }
    private void Regen()
    {
        GameManager.Get().RegenAllLife(maxLife[maxLifeRegenLvl]);
    }

    protected override void Shoot()
    {

            Collider[] colliders = Physics.OverlapSphere(transform.position, range[rangeLvl]);

            foreach (Collider collider in colliders)
            {

                if (collider.tag == "Enemy")
                {
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Bullet bullet = bulletGO.GetComponent<Bullet>();
                    if (bullet != null)
                    {
                        bullet.Seek(collider.transform, damage[damageLvl]);
                    }
                }
            }
    }
    public override int GetLvlUpgdare(int index)
    {
        switch (index)
        {
            case 0:
                return maxLifeRegenLvl;
            case 1:
                return rangeLvl;
            case 2:
                return damageLvl;
            default:
                return 0;
        }
    }
}



using UnityEngine;

public class MainTower : Turret
{

    private int maxLifeRegenLvl = 0;

    [SerializeField] private float[] maxLife = null;

    [SerializeField] private float[] regen = null;

    [SerializeField] private float regenPer = 1;

    private float DeltaRegen = 0;

    public override bool BuyUpgrade(int index)
    {
        switch (index)
        {
            case 0:
                if (Currency.Get().Spend(priceUpgrade1[rangeLvl]))
                {
                    rangeLvl++;
                    return true;
                }
                return false;
            case 1:
                if (Currency.Get().Spend(priceUpgrade2[maxLifeRegenLvl]))
                {
                    maxLifeRegenLvl++;
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

    protected override void Update()
    {
        base.Update();
        if (PauseMenu.isPause)
            return;

        if (GameManager.Get().getLife() < maxLife[maxLifeRegenLvl])
            Regen();
    }
    private void Regen()
    {
        if (DeltaRegen <regenPer)
        {
            DeltaRegen += Time.deltaTime;
            if (DeltaRegen>=regenPer)
            {
                DeltaRegen = 0;
                GameManager.Get().winLife(regen[maxLifeRegenLvl]);
            }
        }
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
}


using UnityEngine;
public class NormalTurret : Turret, IUpdateable
{

    public void BuyUpgrade(int index,int lvl)
    {
        switch(index)
        {
            case 0:
                if (Currency.Get().Spend(priceUpgrade1[damageLvl]))
                    damageLvl++;
                break;
            case 1:
                if (Currency.Get().Spend(priceUpgrade2[rangeLvl]))
                    rangeLvl++;
                break;
            case 2:
                if (Currency.Get().Spend(priceUpgrade1[fireRateLvl]))
                    fireRateLvl++;
                break;

        }
    }
}

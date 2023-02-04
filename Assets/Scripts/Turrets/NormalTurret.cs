using UnityEngine;
public class NormalTurret : Turret
{

    public override bool BuyUpgrade(int index)
    {
        switch(index)
        {
            case 0:
                if (Currency.Get().Spend(priceUpgrade1[damageLvl]))
                {
                    damageLvl++;
                    return true;
                }
                break;
            case 1:
                if (Currency.Get().Spend(priceUpgrade2[rangeLvl]))
                {
                    rangeLvl++;
                    return true;
                }
                break;
            case 2:
                if (Currency.Get().Spend(priceUpgrade1[fireRateLvl]))
                {
                    fireRateLvl++;
                    return true; 
                }
                break;
        }
        return false;
    }
}

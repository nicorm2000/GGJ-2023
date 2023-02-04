using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomTower : Turret, IUpdateable
{

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
}
    
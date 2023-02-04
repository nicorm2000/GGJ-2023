using UnityEngine;

public class SlowerTower : Turret, IUpdateable
{
    private int slowPrcLvl = 0;

    private int slowDurationLvl = 0;

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
}

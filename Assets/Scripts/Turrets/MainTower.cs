
public class MainTower : Turret, IUpdateable
{
    private int maxLifeRegenLvl = 0;
    public void BuyUpgrade(int index, int lvl)
    {
        switch (index)
        {
            case 0:
                if (Currency.Get().Spend(priceUpgrade1[rangeLvl]))
                    rangeLvl++;
                break;
            case 1:
                if (Currency.Get().Spend(priceUpgrade2[maxLifeRegenLvl]))
                    maxLifeRegenLvl++;
                break;
            case 2:
                if (Currency.Get().Spend(priceUpgrade1[damageLvl]))
                    damageLvl++;
                break;
        }
    }
    private void Update() //protected override void
    {
        
    }
}


using UnityEngine;
[SerializeField]
public class Upgrade
{
	private int level = 0;

	public int[] price = null;

	public int maxLvl = 3;

	public bool BuyLvl()
	{
		if (level>=maxLvl)
			return false;

        if (Currency.Get().Spend(price[level]))
		{
			level++;
			return true;
		}
		return false;
	}
}

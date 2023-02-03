using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public Upgrade[] upgrades = null;

    public Turret targetTurret = null;

    public void SetTurret(Turret turret)
    {
        targetTurret = turret;
    }

    public void CallUpgrade(int index)
    {
        upgrades[index].BuyLvl();
    }
}

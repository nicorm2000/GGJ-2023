using UnityEngine;

public class UpgradeMenu : MonoBehaviourSingleton<UpgradeMenu>
{
    public static bool isOpen = false;

    private Turret  tower = null;

    [SerializeField] GameObject updateCanvas = null;

    public void SetCurrentPlaceToBuid(Turret Towwer)
    {
        tower = Towwer;
        updateCanvas.SetActive(true);
        isOpen = true;
    }

    private void EndSelect()
    {
        tower = null;
        updateCanvas.SetActive(false);
        isOpen = false;
    }
    public void CloseMarket() //use in button.
    {
        EndSelect();
    }

    public void TryBuildUpdate(int index) //repace index whit enum type class. //this was call on buttons.
    {
        if (tower.BuyUpgrade(index))
            EndSelect();
    }
}

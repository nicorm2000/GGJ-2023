using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviourSingleton<UpgradeMenu>
{
    public static bool isOpen = false;

    private Turret  tower = null;

    [SerializeField] GameObject updateCanvas = null;

    [SerializeField] Image[] files1 = null; 
    [SerializeField] Image[] files2 = null; 
    [SerializeField] Image[] files3 = null; 

    public void SetCurrentPlaceToBuid(Turret Towwer)
    {
        tower = Towwer;
        updateCanvas.SetActive(true);
        isOpen = true;

        foreach (var item in files1)
        {
            item.fillCenter = false;
        }
        for (int i = 0; i < tower.GetLvlUpgdare(0); i++)
        {
            files1[i].fillCenter = true;
        }

        foreach (var item in files2)
        {
            item.fillCenter = false;
        }
        for (int i = 0; i < tower.GetLvlUpgdare(1); i++)
        {
            files2[i].fillCenter = true;
        }

        foreach (var item in files3)
        {
            item.fillCenter = false;
        }
        for (int i = 0; i < tower.GetLvlUpgdare(2); i++)
        {
            files3[i].fillCenter = true;
        }

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

using UnityEngine;

public class Market : MonoBehaviourSingleton<Market>
{
    public static bool isOpen = false;

    private PlaceToBuildTorret currentBuildingPlace=null;

    [SerializeField] GameObject buildCanvas = null;

    [SerializeField] GameObject[] towers = null;
    [SerializeField] int[] prices = null;

    public void SetCurrentPlaceToBuid(PlaceToBuildTorret buildTorret)
    {
        currentBuildingPlace = buildTorret;
        buildCanvas.SetActive(true);
        isOpen = true;
    }

    private void EndSelect()
    {
        currentBuildingPlace = null;
        buildCanvas.SetActive(false);
        isOpen = false;
    }
    public void CloseMarket() //use in button.
    {
        EndSelect();
    }

    public void BuidTorret(int index) //repace index whit enum type class. //this was call on buttons.
    {
        switch (index)
        {
            case 0: 
                Debug.Log("ty buid 0, this torret...");
                if (Currency.Get().HasEnought(prices[index]))
                {
                    Currency.Get().Spend(prices[index]);
                    Debug.Log("create new tower");
                    Instantiate(towers[index], currentBuildingPlace.transform.position + Vector3.up, Quaternion.identity, null);
                    //instance tower on point, locker the place//or delet.
                    EndSelect();
                }
                else
                    Debug.Log("not enought money");
                break;
            default:
                Debug.Log("not definition");
                break;
        }
    }
}

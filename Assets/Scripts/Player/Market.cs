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
        if (Currency.Get().Spend(prices[index]))
        {
            Instantiate(towers[index], currentBuildingPlace.transform.position + Vector3.up, Quaternion.identity, null);
            Destroy(currentBuildingPlace.gameObject);
            EndSelect();
        }
    }
}

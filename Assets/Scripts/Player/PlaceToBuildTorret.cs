using UnityEngine;

public class PlaceToBuildTorret : MonoBehaviour
{

    void OnMouseOver()
    {
        if (PauseMenu.isPause)
            return;
        if (Input.GetMouseButtonDown(0) && !Market.isOpen)
        {
            Market.Get().SetCurrentPlaceToBuid(this);
            Debug.Log("get");
        }

    }
}

using UnityEngine;

public class TowerToUpgrade : MonoBehaviour
{
    void OnMouseOver()
    {
        if (PauseMenu.isPause)
            return;
        if (Input.GetMouseButtonDown(0) && !UpgradeMenu.isOpen)
            UpgradeMenu.Get().SetCurrentPlaceToBuid(GetComponent<Turret>());
    }
}

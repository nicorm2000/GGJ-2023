using UnityEngine;

public class Hacks : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] private GameObject hacksMenu = null;
    public void AddCurrency()
    {
        Currency.Get().Income(10);
    }

    public void LessCurrency()
    {
        Currency.Get().Spend(10);
    }
    private void Update()
    {
        if (hacksMenu == null)
            return;
        if (PauseMenu.isPause)
            return;
        if (Input.GetKeyDown(KeyCode.K))
        {
            isActive = !isActive;
            hacksMenu.SetActive(isActive);
        }
    }
}

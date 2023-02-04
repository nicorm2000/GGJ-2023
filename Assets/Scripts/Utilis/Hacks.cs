using UnityEngine;

public class Hacks : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] private GameObject hacksMenu = null;

    [SerializeField] private int currencyToAdd = 100;
    public void AddCurrency()
    {
        Currency.Get().Income(currencyToAdd);
    }

    public void LessCurrency()
    {
        Currency.Get().Spend(currencyToAdd);
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

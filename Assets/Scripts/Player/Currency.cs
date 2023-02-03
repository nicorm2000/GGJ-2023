using TMPro;
using UnityEngine;

public class Currency : MonoBehaviourSingleton<Currency>
{
    [SerializeField] private int fertilizer;

    [SerializeField] private TextMeshProUGUI textCurrency;

    public bool Spend(int price)
    {
        bool enought;
        enought = HasEnought(price);
        if (enought)
        {
            fertilizer -= price;
            textCurrency.text = "fertilizer: "+ fertilizer.ToString();
        }
        return enought;
    }

    public void Income(int value)
    {
        fertilizer += value;
        textCurrency.text = "fertilizer: " + fertilizer.ToString();
    }

    private bool HasEnought(int value)
    {
        if (fertilizer>=value)
            return true;
        return false;
    }
}

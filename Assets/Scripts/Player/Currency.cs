using TMPro;
using UnityEngine;

public class Currency : MonoBehaviourSingleton<Currency>
{
    [SerializeField] private int fertilizer;

    [SerializeField] private TextMeshProUGUI textCurrency;

    public void Spend(int value)
    {
        fertilizer -= value;
        textCurrency.text = "fertilizer: "+ fertilizer.ToString();
    }

    public void Income(int value)
    {
        fertilizer += value;
        textCurrency.text = "fertilizer: " + fertilizer.ToString();
    }

    public bool HasEnought(int value)
    {
        if (fertilizer>=value)
            return true;
        return false;
    }
}

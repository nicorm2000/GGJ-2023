using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayMenu : MonoBehaviour
{
    public GameObject[] GameObjects;
    private int current;
    void Start()
    {
        current = 0;
    }

    public void Next()
    {
        if (current < GameObjects.Length)
        {
            GameObjects[current].SetActive(false);
            current++;
            GameObjects[current].SetActive(true);
            
        }
    }
    
    public void Back()
    {
        if (current > GameObjects.Length)
        {
            GameObjects[current].SetActive(false);
            current--;
            GameObjects[current].SetActive(true);
            
        }
    }
    
}

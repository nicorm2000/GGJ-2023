using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShowNextPanel : MonoBehaviour
{
    public GameObject[] GameObjects;
    private int current;

    private void Start()
    {
        current = 0;
    }

    public void NextPage()
    {
        if (current < GameObjects.GetLength() - 1)
        {
            current++;
        }
    }

}

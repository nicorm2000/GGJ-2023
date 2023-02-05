using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyType")]
public class EnemyType : ScriptableObject
{
    
    public Transform EnemyPrefab;
    public int MaxAmount;
    public int ScalingAmount;
    public int DescalingAmount;
    public float StartTime;
    public int ScalingTime;
    //poner en positivo
    public int DescalingTime;

    [HideInInspector] public float scalingTimer;
    [HideInInspector] public float descalingTimer;
    [HideInInspector] public int Amount;
    [HideInInspector] public bool Started = false;
}

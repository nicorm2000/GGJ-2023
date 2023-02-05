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
    public int StartTime;
    public int ScalingTime;
    public int DescalingTime;

    [HideInInspector] public float scalingTimer;
    [HideInInspector] public float descalingTimer;
    [HideInInspector] public int Amount;
    
}

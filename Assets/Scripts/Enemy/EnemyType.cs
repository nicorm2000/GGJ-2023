using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyType")]
public class EnemyType : ScriptableObject
{
    
    public Transform EnemyPrefab;
    public int MaxAmount;
    public int ScalingAmount;
    public int StartTime;
    public int ScalingTime;

    [HideInInspector] public float scalingTimer;
    [HideInInspector] public int Amount;
    
}

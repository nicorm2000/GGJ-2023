using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/EnemyType")]
public class EnemyType : ScriptableObject
{
    
    public Transform EnemyPrefab;
    public int MaxAmount;
    public int Amount;
    public int SpawnTime;
    public int ScalingTime;
    public int ScalingAmount;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTipes : MonoBehaviour
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

    public EnemyTipes( Transform _EnemyPrefab,int _MaxAmount,int _ScalingAmount,int _DescalingAmount,float _StartTime,int _ScalingTime,int _DescalingTime,float _scalingTimer,float _descalingTimer,int _Amount,bool _Started)
    {
        EnemyPrefab = _EnemyPrefab;
        MaxAmount = _MaxAmount;
        ScalingAmount = _ScalingAmount;
        DescalingAmount = _DescalingAmount;
        StartTime = _StartTime;
        ScalingTime = _ScalingTime;
        DescalingTime = _DescalingTime;
        scalingTimer = _scalingTimer;
        descalingTimer = _descalingTimer;
        Amount = _Amount;
        Started = _Started;
    }
}

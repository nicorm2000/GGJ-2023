using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    
    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
        }

        waypointIndex++;
        target = WayPoints.points[waypointIndex];
    }
}

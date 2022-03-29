using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float distanceToWayPoint = 0.2f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector2.Distance(transform.position, target.position) <= distanceToWayPoint)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(wavepointIndex >= WayPoints.points.Length - 1)
        {
            gameObject.SetActive(false);
            return;
        }
        wavepointIndex++;

        target = WayPoints.points[wavepointIndex];
    }
}

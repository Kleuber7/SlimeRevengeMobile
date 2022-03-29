using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemySO statusEnemy;
    public float distanceToWayPoint = 0.2f;
    

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        GetComponent<Image>().sprite = statusEnemy.art;
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * statusEnemy.speed * Time.deltaTime, Space.World);

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

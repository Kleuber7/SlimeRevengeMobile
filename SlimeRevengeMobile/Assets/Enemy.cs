using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemySO statusEnemy;
    public float distanceToWayPoint = 0.2f;
    public float distanceToTower = 0.2f;

    private Transform target;
    private Transform targetTower;
    private int wavepointIndex = 0;
    private int towerpointIndex = 0;

    public WayPoints waypoints;

    public float RaycastDistance = 5f;

    public LayerMask layer1, layer2, layer3;

    private void Start()
    {
        GetComponent<Image>().sprite = statusEnemy.art;
        target = waypoints.points1[0];

    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, RaycastDistance, layer1);
        if (hit == false)
        {
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * statusEnemy.speed * Time.deltaTime, Space.World);

            if (Vector2.Distance(transform.position, target.position) <= distanceToWayPoint)
            {
                GetNextWayPoint1();
            }
        }
        if (Physics2D.Raycast(transform.position, transform.forward, RaycastDistance, layer2) == false)
        {
            if (Vector2.Distance(transform.position, target.position) <= distanceToWayPoint)
            {
                GetNextWay2();
            }

            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * statusEnemy.speed * Time.deltaTime, Space.World);

        }

    }

    void GetNextWayPoint1()
    {
        if (wavepointIndex >= waypoints.points1.Length - 1)
        {
            gameObject.SetActive(false);
            return;
        }
        wavepointIndex++;

        target = waypoints.points1[wavepointIndex - 1];
    }


    void GetNextWay2()
    {
        if (wavepointIndex >= waypoints.points2.Length - 1)
        {
            gameObject.SetActive(false);
            return;
        }

        target = waypoints.points2[wavepointIndex - 1];
        wavepointIndex++;

    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, transform.position + transform.forward * RaycastDistance);
    }
}

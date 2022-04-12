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
    public bool canGo = true;

    public WayPoints waypoints;

    public float RaycastDistance = 5f;

    public Torre torre;
    public string nameTower;


    public LayerMask layerGo, layer1, layer2, layer3, layer4, layer5;

    public float health, maxHealth;

    private void Start()
    {
        GetComponent<Image>().sprite = statusEnemy.art;
        target = waypoints.points1[0];
        layerGo = layer1;

        maxHealth = statusEnemy.maxHealth;
        statusEnemy.health = maxHealth;
        health = statusEnemy.health;
    }

    private void Update()
    {
        CheckDeath();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, RaycastDistance, layerGo);
        if (hit == false && canGo)
        {
            torre = null;
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * statusEnemy.speed * Time.deltaTime);
        }
        else
        {
            canGo = false;

            if (torre == null)
                torre = hit.collider.GetComponent<Torre>();

            int r = Random.Range(0, torre.nextTarget.Length);

            target = torre.nextTarget[r];
            Vector2 dir = target.position - transform.position;
            transform.Translate(dir.normalized * statusEnemy.speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, target.position) <= 0.1f)
            {
                if (torre.numberOfLayer == 1)
                {
                    layerGo = layer1;
                }
                else if (torre.numberOfLayer == 2)
                {
                    layerGo = layer2;
                }
                else if (torre.numberOfLayer == 3)
                {
                    layerGo = layer3;
                }
                else if (torre.numberOfLayer == 4)
                {
                    layerGo = layer4;
                }

                else if (torre.numberOfLayer == 5)
                {
                    layerGo = layer5;
                }

                if (layerGo == layer1)
                {
                    target = waypoints.points1[0];
                }
                else if (layerGo == layer2)
                {
                    target = waypoints.points2[0];
                }
                else if (layerGo == layer3)
                {
                    target = waypoints.points3[0];
                }
                else if (layerGo == layer4)
                {
                    target = waypoints.points4[0];
                }

                else if (layerGo == layer5)
                {
                    target = waypoints.points5[0];
                }

                canGo = true;
            }
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


    //    Vector2 dir = target.position - transform.position;
    //    transform.Translate(dir.normalized * statusEnemy.speed * Time.deltaTime, Space.World);

    //    if (Vector2.Distance(transform.position, target.position) <= distanceToWayPoint)
    //    {
    //        GetNextWayPoint1();
    //    }
    //}
    //if (Physics2D.Raycast(transform.position, transform.forward, RaycastDistance, layer2) == false)
    //{
    //    if (Vector2.Distance(transform.position, target.position) <= distanceToWayPoint)
    //    {
    //        GetNextWay2();
    //    }

    //    Vector2 dir = target.position - transform.position;
    //    transform.Translate(dir.normalized * statusEnemy.speed * Time.deltaTime, Space.World);

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void CheckDeath()
    {
        if(health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        this.gameObject.SetActive(false);
    }
}

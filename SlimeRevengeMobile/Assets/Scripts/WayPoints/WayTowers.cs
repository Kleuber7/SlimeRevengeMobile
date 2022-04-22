using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayTowers : MonoBehaviour
{
    public static Transform[] towers1;
    public static Transform[] towers2;
    public static Transform[] towers3;

    public Transform towersway1, towersway2, towersway3;

    private void Awake()
    {
        towers1 = new Transform[transform.childCount];
        towers2 = new Transform[transform.childCount];
        towers3 = new Transform[transform.childCount];

        for (int i = 0; i < towers1.Length; i++)
        {
            towers1[i] = towersway1.transform.GetChild(i);
        }

        for (int i = 0; i < towers2.Length; i++)
        {
            towers2[i] = towersway2.transform.GetChild(i);
        }

        for (int i = 0; i < towers3.Length; i++)
        {
            towers3[i] = towersway3.transform.GetChild(i);
        }
    }
}

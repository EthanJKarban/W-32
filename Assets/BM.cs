using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM : MonoBehaviour
{
     List<GameObject> bullets;

    void Start()
    {
        bullets = new List<GameObject>();
    }

    //public static GameObject GetBulletFromPool()
    //{
    //    for (int i = 0; i < bullets.Count; i++)
    //    {
    //        if (!bullets[i].active)
    //        {
    //            bullets[i].GetComponent<Bull>(). = true;
    //            return bullets[i];
    //        }
    //    }
    //}
}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Bull : MonoBehaviour
{
    Bullet bullet;

    private Vector2 spawnPoint;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, bullet.rotation);
    }

    public void Update()
    {
        transform.Translate(bullet.velocity * bullet.speed * Time.deltaTime);

    }
}

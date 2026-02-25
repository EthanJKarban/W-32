using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class Bull : MonoBehaviour
{
    public Bullet bullet;

    public float setDamage;
    public bool rewindNot = true;
    private float perBulletLifeTime = 3;
    private float timer;
    private float direction = 1;

    [SerializeField] private Vector2 spawnPoint;

    private void Awake()
    {
        timer = bullet.lifetime;
    }
    void Start()
    {
        perBulletLifeTime = timer;
        bullet.damage = setDamage;
        transform.rotation = Quaternion.Euler(0, 0, bullet.rotation);
    }

    public void Update()
    {
        transform.Translate(bullet.velocity * bullet.speed * Time.deltaTime * direction);

        perBulletLifeTime -= Time.deltaTime;
        if(perBulletLifeTime <= 0)
        {
            if (bullet.rewind)
            {
                if(rewindNot == true)
                {
                    perBulletLifeTime = bullet.lifetime;
                    direction *= -1;
                    rewindNot = false;
                    return;
                }
                if(rewindNot == false)
                {
                    Destroy(gameObject);
                    return;
                }
               
            }

            Destroy(gameObject);
            perBulletLifeTime = bullet.lifetime;
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(spawnPoint, 1);
        Gizmos.DrawLine(transform.position, spawnPoint);
    }
}

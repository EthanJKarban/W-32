using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class Bull : MonoBehaviour
{
    public Bullet bullet;

    public float setDamage;
    public bool rewindNot = true;
    private float perBulletLifetime = 3;
    private float direction = 1;

    [SerializeField] private Vector2 spawnPoint;
    
    void Start()
    {
        bullet.damage = setDamage;
        transform.rotation = Quaternion.Euler(0, 0, bullet.rotation);
    }

    public void Update()
    {
        transform.Translate(bullet.velocity * bullet.speed * Time.deltaTime * direction);

        perBulletLifetime -= Time.deltaTime;
        if(perBulletLifetime <= 0)
        {
            if (bullet.rewind)
            {
                if(rewindNot == true)
                {
                    perBulletLifetime = bullet.lifetime;
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
            perBulletLifetime = bullet.lifetime;
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(spawnPoint, 1);
        Gizmos.DrawLine(transform.position, spawnPoint);
    }
}

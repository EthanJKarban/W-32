using UnityEngine;

public class Bull : MonoBehaviour
{
    Bullet bullet;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, bullet.rotation);
    }

    public void Update()
    {
        transform.Translate(bullet.velocity * bullet.speed * Time.deltaTime);

    }
}

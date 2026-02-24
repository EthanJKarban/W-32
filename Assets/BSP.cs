using System.Threading;
using UnityEngine;

public class BSP : MonoBehaviour
{
    public BS bs;
    float timer;

    public float[] rotations;

    public void Start()
    {
        timer = bs.cooldown;
        rotations = new float[bs.numberOfBullets];
        if (!bs.isRandom)
        {
            DistributedRotations();
        }
    }

    private void Update()
    {
        if (timer <= 0)
        {
            SpawnBullets();
            timer = bs.cooldown;
        }
        timer -= Time.deltaTime;
    }

    public float[] RandomRotation()
    {
        for (int i = 0; i < bs.numberOfBullets; i++)
        {
            rotations[i] = Random.Range(bs.minRotation, bs.maxRotation);
        }
        return rotations;
    }

    public float[] DistributedRotations()
    {
        for (int i = 0; i < bs.numberOfBullets; i++)
        {
            var fraction = (float)i / ((float)bs.numberOfBullets - 1);
            var difference = bs.maxRotation - bs.minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + bs.minRotation;
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }

    public GameObject[] SpawnBullets()
    {
        if (bs.isRandom)
        {
            RandomRotation();
        }

        //Spawn Bullets
        GameObject[] spawnedBullets = new GameObject[bs.numberOfBullets];
        for (int i = 0; i < bs.numberOfBullets; i++)
        {
            spawnedBullets[i] = Instantiate(bs.bulletResources, transform);

            spawnedBullets[i].GetComponent<Rigidbody2D>().rotation = rotations[i];
            spawnedBullets[i].GetComponent<Rigidbody2D>().linearVelocity = bs.bulletVelocity * bs.bulletSpeed;
        }   
        return spawnedBullets;
    }


}
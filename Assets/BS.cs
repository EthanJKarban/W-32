using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Spawner", menuName = "Bullet Spawner Stats")]
public class BS : ScriptableObject 
{

    [Header("LimitsNStuff")]
    [SerializeField] public GameObject bulletResources;
    [SerializeField] public float minRotation;
    [SerializeField] public float maxRotation;
    [SerializeField] public int numberOfBullets;
    [SerializeField] public bool isRandom;

    [Header("SpawnerStats")]
    [SerializeField] public float cooldown;
    [SerializeField] public float bulletSpeed;
    [SerializeField] public Vector2 bulletVelocity;

    
}

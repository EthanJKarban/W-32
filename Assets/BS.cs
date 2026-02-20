using JetBrains.Annotations;
using UnityEngine;

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
    [SerializeField] public float timer;
    [SerializeField] public float bulletSpeed;
    [SerializeField] Vector2 bulletVelocity;

    float[] rotations;
}

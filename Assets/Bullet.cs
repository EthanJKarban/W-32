using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet Stats")]
public class Bullet : ScriptableObject
{
    [Header("Bullet Stats")]
    [SerializeField] public float speed;
    [SerializeField] public float rotation;
    [SerializeField] public float damage;
    [SerializeField] public float lifetime;
    
    

    [Header("Bullet Attributes")]
    [SerializeField] public float bulletAmount;
    [SerializeField] public float spread;
    [SerializeField] public bool rewind;
    [SerializeField] public bool piercing;
    [SerializeField] public Vector2 velocity;
}

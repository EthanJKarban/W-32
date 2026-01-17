using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player Stats")]
public class Player : ScriptableObject
{
    [Header("Player Stats")]
    [SerializeField] public float currentHealth;
    [SerializeField] public float health = 10f;
    [SerializeField] public float speed = 5f;
    [SerializeField] public float ospeed = 5f;
    [SerializeField] public float damage = 2f;
    [SerializeField] public int dashCooldown = 5;
    [SerializeField] public float dashDuration = 1.5f;
    [SerializeField] public float dashPower = 20f;

    [Header("Player Status")]
    [SerializeField] public bool isAlive;
    [SerializeField] public bool iframes;
    [SerializeField] public bool canDash = true;
    [SerializeField] public bool isDashing;



}

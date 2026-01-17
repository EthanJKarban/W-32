using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        player.currentHealth = player.health;
        player.isAlive = true;
    }

    private void Update()
    {
        
        if (player.currentHealth <= 0 && player.isAlive)
        {
            Die();
        }
        
    }

    private void Die()
    {
        player.isAlive = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && !player.iframes)
        {
            player.health -= collision.GetComponent<Bullet>().damage;
            StartCoroutine(IFramesCoroutine());
        }
    }
    IEnumerator IFramesCoroutine()
    {
        player.iframes = true;
        yield return new WaitForSeconds(1f);
        player.iframes = false;
    }
}

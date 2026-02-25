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
        Debug.Log("You have perished.");
        player.isAlive = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && !player.iframes)
        {
            Debug.Log("You have taken damage.");
            player.currentHealth -= collision.GetComponent<Bull>().setDamage;
            StartCoroutine(IFramesCoroutine());
        }
        else
        {
            Debug.Log("Damage Nullified");
        }
    }
    IEnumerator IFramesCoroutine()
    {
        player.iframes = true;
        yield return new WaitForSeconds(player.iframeDuration);
        player.iframes = false;
        
    }
}

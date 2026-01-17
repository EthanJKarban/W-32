using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public Player player;

    private float originalGravityScale;
    private Rigidbody2D rb;
    private Vector3 movement;
    private Vector3 dashing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player.canDash = true;
    }

    private void Update()
    {
        rb.MovePosition(transform.position + movement * player.speed * Time.fixedDeltaTime);
    }
    private void Start()
    {
        originalGravityScale = rb.gravityScale;
    }
    public void Walking(InputAction.CallbackContext ctx)
    {
        movement = new Vector3(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y, 0);
        if (player.isDashing)
        {
            return;
        }

        if(movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void Dash(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && player.canDash)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    IEnumerator DashCoroutine()
    {
        player.canDash = false;
        player.isDashing = true;
        player.iframes = true;
        if (rb != null)
        {
            player.speed = player.speed * 2;
            rb.gravityScale = 0f;
            float dashDirectionX = transform.localScale.x;

            rb.linearVelocity = new Vector2(dashDirectionX * player.dashPower, 0);
        }
        yield return new WaitForSeconds(player.dashDuration);

        player.speed = player.ospeed;
        player.isDashing = false;
        player.iframes = false;
        if (rb != null)
        {
            rb.gravityScale = originalGravityScale;
        }
        yield return new WaitForSeconds(player.dashCooldown);
        player.canDash = true;

    }
}

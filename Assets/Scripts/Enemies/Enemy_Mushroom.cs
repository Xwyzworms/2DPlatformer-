using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mushroom : Enemy
{
    // Start is called before the first frame update
    
    [SerializeField] private float speed;
    protected override void Start()
    {
        facingDirection = facingDirection * -1;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationControllers();
        if(animIdleTimer <= 0) 
        {
            rb.velocity = new Vector2(speed * facingDirection, rb.velocity.y);   
        }
        else 
        {
            rb.velocity = Vector2.zero;
        }
        animIdleTimer -= Time.deltaTime;
        CollisionCheck();

        if(isWallDetected || !isGround) 
        {
            Flip();
            animIdleTimer = animIdleCooldown;
        }
    }

    private void AnimationControllers() 
    {
        anim.SetFloat("Xvelocity", rb.velocity.x);
    }
}

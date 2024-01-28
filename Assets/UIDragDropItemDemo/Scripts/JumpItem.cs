using System;
using UnityEngine;

public class JumpItem : FunctionalItemBase
{
    [SerializeField]
    private Vector2 jumpForce;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerRigidBody = GetPlayerComponent<Rigidbody2D>(other);
        if (playerRigidBody != null)
        {
            var playerVelocity = playerRigidBody.velocity;
            playerRigidBody.velocity = new Vector2(playerVelocity.x, 0); // reset vy to apply multi-jump
            playerRigidBody.AddForce(jumpForce);
            
            DisablePhysics();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EnablePhysics();
    }
}

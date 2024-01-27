using UnityEngine;

public class JugglingBallItem : FunctionalItemBase
{
    [SerializeField]
    private Vector2 force;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerRigidBody = GetPlayerComponent<Rigidbody2D>(other);
        if (playerRigidBody != null)
        {
            // Apply a force
            playerRigidBody.AddForce(force);
            DisablePhysics();
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        EnablePhysics();
    }
}

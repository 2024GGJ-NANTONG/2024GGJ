using UnityEngine;

public class JumpItem : MonoBehaviour
{
    [SerializeField]
    private Vector2 jumpForce;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerRigidBody = other.gameObject.GetComponent<Rigidbody2D>();
            var playerVelocity = playerRigidBody.velocity;
            playerRigidBody.velocity = new Vector2(playerVelocity.x, 0); // reset vy to apply multi-jump
            playerRigidBody.AddForce(jumpForce);
        }
    }
}

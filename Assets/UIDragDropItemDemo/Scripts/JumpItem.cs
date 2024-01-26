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
            playerRigidBody.AddForce(jumpForce);
        }
    }
}

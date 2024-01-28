using UnityEngine;

namespace GGJ
{
    public class PlatformPlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _baseMoveSpeed = 3f;
        
        private void Awake()
        {
            var rigidBody = GetComponent<Rigidbody2D>();
            
            // Set base velocity (facing right)
            rigidBody.velocity = new Vector2(_baseMoveSpeed, 0);
        }
    }
}
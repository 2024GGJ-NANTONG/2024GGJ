using UnityEngine;

namespace GGJ
{
    public class Magnet : ItemBase
    {
        [SerializeField]
        private float _effectRadius = 3f;
        
        protected override void Awake()
        {
            base.Awake();
            
            // Force kinematic
            _rigidBody.isKinematic = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _effectRadius);
        }

        private void Update()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, _effectRadius, LayerMask.GetMask("Player"));
            if (colliders != null && colliders.Length > 0)
            {
                // Only care about player for now
                for (int i = 0; i < colliders.Length; ++i)
                {
                    var playerInstance = colliders[i].gameObject.GetComponent<PlayerInstance>();
                    if (playerInstance != null)
                    {
                        if (playerInstance.MagneticCoefficient > 0)
                        {
                            var playerRigidBody = playerInstance.gameObject.GetComponent<Rigidbody2D>();

                            var power = 1.0f / (_rigidBody.position - playerRigidBody.position).magnitude;
                            var force = (_rigidBody.position - playerRigidBody.position).normalized * (playerInstance.MagneticCoefficient * power);
                            playerRigidBody.AddForce(force);
                        }
                    }
                }
            }
        }
    }
}
using UnityEngine;

namespace GGJ
{
    public class DeadZone : ItemBase
    {
        protected override void Awake()
        {
            base.Awake();
            
            // Force kinematic
            _rigidBody.isKinematic = true;
            
            // Force trigger
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerInstance = GetPlayerComponent<PlayerInstance>(other);
            if (playerInstance != null)
            {
                GameManager.Instance.ReloadCurrentLevel();
            }
        }
    }
}
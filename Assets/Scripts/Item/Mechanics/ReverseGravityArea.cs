using UnityEngine;

namespace GGJ
{
    public class ReverseGravityArea : ItemBase, IBuffItem
    {
        private bool _isFirstIn = true;
        private bool _isFirstOut = true;
        
        public BuffType GetBuffType()
        {
            return BuffType.ReverseGravity;
        }
        
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
                if (_isFirstIn)
                {
                    Debug.Log("[ReverseGravityArea] Entered Reverse Gravity Area");
                    AddReverseGravityBuff(playerInstance);
                    _isFirstIn = false;
                    _isFirstOut = true;
                }
            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            var playerInstance = GetPlayerComponent<PlayerInstance>(other);
            if (playerInstance != null)
            {
                if (_isFirstOut)
                {
                    Debug.Log("[ReverseGravityArea] Left Reverse Gravity Area");
                    AddReverseGravityBuff(playerInstance);
                    _isFirstOut = false;
                    _isFirstIn = true;
                }
            }
        }

        private void AddReverseGravityBuff(PlayerInstance playerInstance)
        {
            if (!playerInstance.AddNewBuff(GetBuffType(), out var buffInstance))
            {
                Debug.LogError("[Spring][OnTriggerEnter2D] Failed to add buff.");
                return;
            }

            var addedBuff = buffInstance as ReverseGravityBuff;
            if (addedBuff == null)
            {
                Debug.LogError("[Spring][OnTriggerEnter2D] Buff is not ReverseGravity.");
            }
        }
    }
}
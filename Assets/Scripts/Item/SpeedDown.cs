using System;
using UnityEngine;

namespace GGJ
{
    public class SpeedDown : ItemBase, IBuffItem
    {
        [SerializeField] 
        private float _speedDownValue = 2f;

        [SerializeField]
        private float _timer = 0.5f;
        
        public BuffType GetBuffType()
        {
            return BuffType.SpeedDown;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerInstance = GetPlayerComponent<PlayerInstance>(other);
            if (playerInstance != null)
            {
                if (_isPhysicsEnabled)
                {
                    if (!playerInstance.AddNewBuff(GetBuffType(), out var buffInstance))
                    {
                        Debug.LogError("[Spring][OnTriggerEnter2D] Failed to add buff.");
                        return;
                    }

                    var addedBuff = buffInstance as SpeedDownBuff;
                    if (addedBuff == null)
                    {
                        Debug.LogError("[Spring][OnTriggerEnter2D] Buff is not SpeedDown.");
                        return;
                    }

                    addedBuff.SpeedDownValue = _speedDownValue;
                    addedBuff.Timer = _timer;

                    DisablePhysics();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var playerInstance = GetPlayerComponent<PlayerInstance>(other);
            if (playerInstance != null)
            {
                if (!_isPhysicsEnabled)
                {
                    EnablePhysics();
                }
            }
        }
    }
}
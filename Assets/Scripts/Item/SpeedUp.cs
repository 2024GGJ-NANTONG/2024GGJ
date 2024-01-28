using UnityEngine;

namespace GGJ
{
    public class SpeedUp : ItemBase, IBuffItem
    {
        [SerializeField] 
        private float _speedUpValue = 2f;

        [SerializeField]
        private float _timer = 0.5f;
        
        public BuffType GetBuffType()
        {
            return BuffType.SpeedUp;
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

                    var addedBuff = buffInstance as SpeedUpBuff;
                    if (addedBuff == null)
                    {
                        Debug.LogError("[Spring][OnTriggerEnter2D] Buff is not SpeedUp.");
                        return;
                    }

                    addedBuff.SpeedUpValue = _speedUpValue;
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
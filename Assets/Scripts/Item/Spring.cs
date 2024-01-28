using UnityEngine;

namespace GGJ
{
    public class Spring : ItemBase, IBuffItem
    {
        [SerializeField]
        private Vector2 _instantForce = new Vector2(0, 300);
        
        public BuffType GetBuffType()
        {
            return BuffType.InstantForce;
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

                    var addedBuff = buffInstance as InstantForceBuff;
                    if (addedBuff == null)
                    {
                        Debug.LogError("[Spring][OnTriggerEnter2D] Buff is not InstantForce.");
                        return;
                    }

                    addedBuff.InstanceForce = _instantForce;
            
                    DisablePhysics();
                    Invoke(nameof(EnablePhysics), 0.4f);
                }
            }
        }
    }
}
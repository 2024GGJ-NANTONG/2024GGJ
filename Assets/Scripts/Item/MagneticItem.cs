using UnityEngine;

namespace GGJ
{
    public class MagneticItem : ItemBase, IBuffItem
    {
        [SerializeField]
        private float _coefficient = 1.0f;
        
        [SerializeField]
        private float _timer = 0.5f;
        
        public BuffType GetBuffType()
        {
            return BuffType.Magnetic;
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

                    var addedBuff = buffInstance as MagneticBuff;
                    if (addedBuff == null)
                    {
                        Debug.LogError("[Spring][OnTriggerEnter2D] Buff is not Magnetic.");
                        return;
                    }

                    addedBuff.Coefficient = _coefficient;
                    addedBuff.Timer = _timer;

                    Hide();
                    DisablePhysics();
                }
            }
        }
    }
}
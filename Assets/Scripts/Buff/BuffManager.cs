using System;
using System.Collections.Generic;

namespace GGJ
{
    public class BuffManager : Singleton<BuffManager>
    {
        private int _buffIdSeed = 0;

        private List<IBuffOwner> _buffOwners = new List<IBuffOwner>();

        public void AddNewOwner(IBuffOwner owner)
        {
            _buffOwners.Add(owner);
        }

        public void RemoveOwner(IBuffOwner owner)
        {
            _buffOwners.Remove(owner);
        }
        
        public BuffInstance CreateBuff(BuffType type, IBuffOwner owner)
        {
            BuffInstance buffInstance = null;
            
            switch (type)
            {
                case BuffType.InstantForce:
                    buffInstance =  new InstantForceBuff(_buffIdSeed++, type, owner);
                    break;
                case BuffType.SpeedUp:
                    buffInstance = new SpeedUpBuff(_buffIdSeed++, type, owner);
                    break;
                case BuffType.SpeedDown:
                    buffInstance = new SpeedDownBuff(_buffIdSeed++, type, owner);
                    break;
                case BuffType.Magnetic:
                    buffInstance = new MagneticBuff(_buffIdSeed++, type, owner);
                    break;
                case BuffType.ReverseGravity:
                    buffInstance = new ReverseGravityBuff(_buffIdSeed++, type, owner);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return buffInstance;
        }

        private void Update()
        {
            // Effect all owners' buff instances
            foreach (var buffOwner in _buffOwners)
            {
                buffOwner.EffectBuffInstances();
            }
        }
    }
}
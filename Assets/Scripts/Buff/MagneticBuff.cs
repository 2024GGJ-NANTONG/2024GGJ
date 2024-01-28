using UnityEngine;

namespace GGJ
{
    public class MagneticBuff : BuffInstance, IPreserveBuff
    {
        public float Coefficient { get; set; }
        public float Timer { get; set; }
        
        private bool _firstTime = true;
        
        public MagneticBuff(int id, BuffType type, IBuffOwner owner) : base(id, type, owner)
        {
        }

        public override void Effect()
        {
            if (_firstTime)
            {
                _owner.IncreaseMagneticCoefficient(Coefficient);
                _firstTime = false;
            }

            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                _owner.DecreaseMagneticCoefficient(Coefficient);
                _owner.RemoveBuff(_id);
            }
        }
    }
}
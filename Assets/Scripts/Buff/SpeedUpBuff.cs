using UnityEngine;

namespace GGJ
{
    public class SpeedUpBuff : BuffInstance, IPreserveBuff
    {
        public float SpeedUpValue { get; set; }
        public float Timer { get; set; }
        
        private Rigidbody2D _ownerRigidBody;
        private bool _firstTime = true;
        
        public SpeedUpBuff(int id, BuffType type, IBuffOwner owner) : base(id, type, owner)
        {
            _ownerRigidBody = owner.GetRigidBody();
        }

        public override void Effect()
        {
            if (_firstTime)
            {
                // if facing right
                float increasedX;
                if (_ownerRigidBody.velocity.x >= 0)
                {
                    increasedX = _ownerRigidBody.velocity.x + SpeedUpValue;
                }
                // else facing left
                else
                {
                    increasedX = _ownerRigidBody.velocity.x - SpeedUpValue;
                }
                _ownerRigidBody.velocity = new Vector2(increasedX, _ownerRigidBody.velocity.y);
                
                _firstTime = false;
            }

            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                // if facing right
                float increasedX;
                if (_ownerRigidBody.velocity.x >= 0)
                {
                    increasedX = Mathf.Max(0, _ownerRigidBody.velocity.x - SpeedUpValue);
                }
                // else facing left
                else
                {
                    increasedX = Mathf.Min(0, _ownerRigidBody.velocity.x + SpeedUpValue);
                }
                _ownerRigidBody.velocity = new Vector2(increasedX, _ownerRigidBody.velocity.y);
                
                _owner.RemoveBuff(_id);
            }
        }
    }
}
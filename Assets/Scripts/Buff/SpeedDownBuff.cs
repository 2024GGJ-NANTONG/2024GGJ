using UnityEngine;

namespace GGJ
{
    public class SpeedDownBuff : BuffInstance, IPreserveBuff
    {
        public float SpeedDownValue { get; set; }
        public float Timer { get; set; }
        
        private Rigidbody2D _ownerRigidBody;
        private bool _firstTime = true;
        
        public SpeedDownBuff(int id, BuffType type, IBuffOwner owner) : base(id, type, owner)
        {
            _ownerRigidBody = owner.GetRigidBody();
        }

        public override void Effect()
        {
            if (_firstTime)
            {
                // if static
                float decreasedX;
                if (Mathf.Abs(_ownerRigidBody.velocity.x) < float.Epsilon)
                {
                    decreasedX = _ownerRigidBody.velocity.x;
                }
                // if facing right
                else if (_ownerRigidBody.velocity.x > 0)
                {
                    decreasedX = Mathf.Max(0, _ownerRigidBody.velocity.x - SpeedDownValue);
                }
                // else facing left
                else
                {
                    decreasedX = Mathf.Min(0, _ownerRigidBody.velocity.x + SpeedDownValue);
                }
                _ownerRigidBody.velocity = new Vector2(decreasedX, _ownerRigidBody.velocity.y);
                
                _firstTime = false;
            }

            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                // if static
                float decreasedX;
                if (Mathf.Abs(_ownerRigidBody.velocity.x) < float.Epsilon)
                {
                    decreasedX = _ownerRigidBody.velocity.x;
                }
                // if facing right
                else if (_ownerRigidBody.velocity.x > 0)
                {
                    decreasedX = _ownerRigidBody.velocity.x + SpeedDownValue;
                }
                // else facing left
                else
                {
                    decreasedX = _ownerRigidBody.velocity.x - SpeedDownValue;
                }
                _ownerRigidBody.velocity = new Vector2(decreasedX, _ownerRigidBody.velocity.y);
                
                _owner.RemoveBuff(_id);
            }
        }
    }
}
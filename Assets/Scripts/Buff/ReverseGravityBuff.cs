using UnityEngine;

namespace GGJ
{
    public class ReverseGravityBuff : BuffInstance, IInstantBuff
    {
        private Rigidbody2D _ownerRigidBody;
        
        public ReverseGravityBuff(int id, BuffType type, IBuffOwner owner) : base(id, type, owner)
        {
            _ownerRigidBody = owner.GetRigidBody();
        }

        public override void Effect()
        {
            // reverse gravity scale
            _ownerRigidBody.gravityScale = -1.0f * _ownerRigidBody.gravityScale;
            _owner.RemoveBuff(_id);
        }
    }
}
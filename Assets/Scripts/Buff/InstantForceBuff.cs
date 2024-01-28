using UnityEngine;

namespace GGJ
{
    public class InstantForceBuff : BuffInstance, IInstantBuff
    {
        public Vector2 InstanceForce { get; set; }

        private Rigidbody2D _ownerRigidBody;
        
        public InstantForceBuff(int id, BuffType type, IBuffOwner owner) : base(id, type, owner)
        {
            _ownerRigidBody = owner.GetRigidBody();
        }

        public override void Effect()
        {
            _ownerRigidBody.AddForce(InstanceForce);
            _owner.RemoveBuff(_id);
        }
    }
}
using UnityEngine;

namespace GGJ
{
    public interface IBuffOwner
    {
        bool AddNewBuff(BuffType buffType, out BuffInstance buffInstance);

        bool RemoveBuff(int buffId);

        void ClearBuff();

        void IncreaseMagneticCoefficient(float coefficient);
        
        void DecreaseMagneticCoefficient(float coefficient);

        void EffectBuffInstances();

        Rigidbody2D GetRigidBody();

        Transform GetTransform();
    }
}
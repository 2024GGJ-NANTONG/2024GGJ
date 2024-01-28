using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GGJ
{
    public class PlayerInstance : MonoBehaviour, IBuffOwner, ITeleportable
    {
        [SerializeField]
        private float _maxMagneticCoefficient = 3f;

        public float MagneticCoefficient => _magneticCoefficient;
        private float _magneticCoefficient = 0;
        
        private Dictionary<int, BuffInstance> _buffDict = new();

        public bool AddNewBuff(BuffType buffType, out BuffInstance buffInstance)
        {
            // Create buff by BuffManager
            var createdBuff = BuffManager.Instance.CreateBuff(buffType, this);
            if (createdBuff == null)
            {
                Debug.LogErrorFormat("[PlayerInstance] Failed to create buff {0}", buffType);
                buffInstance = null;
                return false;
            }
            
            _buffDict.Add(createdBuff.Id, createdBuff);
            
            buffInstance = createdBuff;
            return true;
        }

        public bool RemoveBuff(int buffId)
        {
            return _buffDict.Remove(buffId);
        }

        public void ClearBuff()
        {
            _buffDict.Clear();
        }

        public void IncreaseMagneticCoefficient(float coefficient)
        {
            _magneticCoefficient = Mathf.Min(_magneticCoefficient + coefficient, _maxMagneticCoefficient);
        }

        public void DecreaseMagneticCoefficient(float coefficient)
        {
            _magneticCoefficient = Mathf.Max(_magneticCoefficient - coefficient, 0);
        }

        public void EffectBuffInstances()
        {
            // Convert to list then effect because some of the buff may delete it self.
            // Deletion is dangerous when traversing containers.
            // It may destroy the iterator.
            var buffList = _buffDict.Values.ToList();
            foreach (var buffInstance in buffList)
            {
                buffInstance.Effect();
            }
        }

        public Rigidbody2D GetRigidBody()
        {
            return GetComponent<Rigidbody2D>();
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void Teleport(Vector3 position)
        {
            transform.position = position;
        }
    }
}
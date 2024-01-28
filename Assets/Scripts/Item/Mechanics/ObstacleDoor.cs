using UnityEngine;

namespace GGJ
{
    public class ObstacleDoor : ItemBase
    {
        [SerializeField]
        private float _interval;

        protected override void Awake()
        {
            base.Awake();
            
            // Force kinematic
            _rigidBody.isKinematic = true;
            
            InvokeRepeating(nameof(Switch), _interval, _interval);
        }

        private void Switch()
        {
            if (_isPhysicsEnabled)
            {
                DisablePhysics();
                Hide();
            }
            else
            {
                EnablePhysics();
                Show();
            }
        }
    }
}
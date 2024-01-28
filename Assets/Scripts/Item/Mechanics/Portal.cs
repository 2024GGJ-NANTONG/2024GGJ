using System;
using UnityEngine;

namespace GGJ
{
    public class Portal : ItemBase
    {
        [SerializeField]
        private Portal _pair;
        
        private bool _isFirstIn = true;        
        
        protected override void Awake()
        {
            base.Awake();
            
            // Force kinematic
            _rigidBody.isKinematic = true;
            
            // Force trigger
            _collider.isTrigger = true;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerInstance = GetPlayerComponent<PlayerInstance>(other);
            if (playerInstance != null)
            {
                if (_isFirstIn)
                {
                    Debug.LogFormat("[Portal] Entered Portal, teleporting to {0}", _pair.gameObject.name);
                    playerInstance.Teleport(_pair.transform.position + new Vector3(2f, 0, 0));
                    _isFirstIn = false;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var playerInstance = GetPlayerComponent<PlayerInstance>(other);
            if (playerInstance != null)
            {
                if (!_isFirstIn)
                {
                    _isFirstIn = true;
                }
            }
        }
    }
}
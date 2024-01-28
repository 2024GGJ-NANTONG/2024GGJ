using System;
using UnityEngine;

namespace GGJ
{
    public class ItemBase : MonoBehaviour
    {
        protected Collider2D _collider;
        protected Rigidbody2D _rigidBody;

        protected bool _isPhysicsEnabled = true;
        protected bool _isShow = true;

        protected virtual void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        protected void EnablePhysics()
        {
            _collider.isTrigger = false;
            _rigidBody.isKinematic = false;
            _isPhysicsEnabled = true;
        }
    
        protected void DisablePhysics()
        {
            _collider.isTrigger = true;
            _rigidBody.isKinematic = true;
            _isPhysicsEnabled = false;
        }
    
        protected void Show()
        {
            _isShow = true;
            gameObject.SetActive(true);
        }
    
        protected void Hide()
        {
            _isShow = false;
            gameObject.SetActive(false);
        }
    
        protected GameObject GetPlayerGameObject(Collider2D collider2D)
        {
            if (collider2D.gameObject.CompareTag("Player"))
            {
                return collider2D.gameObject;
            }

            return null;
        }

        protected T GetPlayerComponent<T>(Collider2D collider2D) where T : Component
        {
            return GetPlayerGameObject(collider2D)?.GetComponent<T>();
        }
    }
}
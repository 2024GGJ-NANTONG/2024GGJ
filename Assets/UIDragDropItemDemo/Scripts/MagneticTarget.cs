using System;
using UnityEngine;

public class MagneticTarget : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D targetRigidBody;
    
    [HideInInspector]
    public float period;

    private void Start()
    {
        Invoke(nameof(DestroySelf), period);
    }

    public void AddForce(Vector2 force)
    {
        targetRigidBody.AddForce(force);
    }

    public Vector2 GetPosition()
    {
        return targetRigidBody.position;
    }

    private void DestroySelf()
    {
        GameObject.Destroy(gameObject);
    }
}

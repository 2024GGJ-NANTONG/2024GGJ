using UnityEngine;

public class MagneticTarget : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D targetRigidBody;

    public void AddForce(Vector2 force)
    {
        targetRigidBody.AddForce(force);
    }

    public Vector2 GetPosition()
    {
        return targetRigidBody.position;
    }
}

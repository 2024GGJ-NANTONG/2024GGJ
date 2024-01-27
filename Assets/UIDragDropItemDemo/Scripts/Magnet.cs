using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField]
    private float power;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        // If it's a magnetic object
        if (other.gameObject.CompareTag("Magnetic"))
        {
            var magneticTarget = other.gameObject.GetComponent<MagneticTarget>();
            if (magneticTarget != null)
            {
                // Apply a magnetic force when staying in trigger
                Vector3 position = transform.position;
                Vector2 forceDirection = (new Vector2(position.x, position.y) - magneticTarget.GetPosition()).normalized;
                Vector2 force = power * forceDirection;
            
                magneticTarget.AddForce(force);
            }
        }
    }
}

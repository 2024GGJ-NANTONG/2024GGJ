using System;
using UnityEngine;

public class MagneticItem : FunctionalItemBase
{
    [SerializeField]
    private float period;

    [SerializeField]
    private float power;

    private bool isAttracting;
    private float timer;
    private float currentPower;

    private void Awake()
    {
        timer = period;
        currentPower = power;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If it's a magnetic object
        if (other.gameObject.CompareTag("Magnetic"))
        {
            isAttracting = true;
            timer = period;
            currentPower = power;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // If it's a magnetic object
        if (other.gameObject.CompareTag("Magnetic") && isAttracting)
        {
            var magneticTarget = other.gameObject.GetComponent<MagneticTarget>();
            if (magneticTarget != null)
            {
                // Apply a magnetic force when staying in trigger
                Vector2 forceDirection = (rigidBody.position - magneticTarget.GetPosition()).normalized;
                Vector2 force = currentPower * forceDirection;
            
                magneticTarget.AddForce(force);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If it's a magnetic object
        if (other.gameObject.CompareTag("Magnetic") && isAttracting)
        {
            isAttracting = false;
            timer = period;
            currentPower = 0;
        }
    }

    private void Update()
    {
        if (isAttracting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isAttracting = false;
                timer = period;
                currentPower = power;
            }
        }
    }
}

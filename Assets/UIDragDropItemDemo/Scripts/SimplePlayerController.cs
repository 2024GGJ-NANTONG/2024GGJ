using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBidy;
    
    [SerializeField]
    private float moveSpeed;

    // Speed up properties
    private bool isSpeedingUp;
    private float speedUpTimer;
    
    // Speed down properties
    private bool isSpeedingDown;
    private float speedDownTimer;

    public void SpeedUp(float speedUpValue, float period)
    {
        // only speed up once, but can refresh timer
        if (isSpeedingUp)
        {
            speedUpTimer = period;
            return;
        }
        
        float offsetSpeed = rigidBidy.velocity.x > 0 ? speedUpValue : -speedUpValue;
        rigidBidy.velocity = new Vector2(rigidBidy.velocity.x + offsetSpeed, 0);
        isSpeedingUp = true;
        speedUpTimer = period;
    }
    
    public void SpeedDown(float speedDownValue, float period)
    {
        // only speed down once, but can refresh timer
        if (isSpeedingDown)
        {
            speedDownTimer = period;
            return;
        }
        
        float offsetSpeed = rigidBidy.velocity.x > 0 ? -speedDownValue : speedDownValue;
        rigidBidy.velocity = new Vector2(rigidBidy.velocity.x + offsetSpeed, 0);
        isSpeedingDown = true;
        speedDownTimer = period;
    }

    public void StartSimulating()
    {
        if (Time.timeScale > 0)
        {
            ResetVelocity();
            transform.position = new Vector3(-8, 0.5f, 0);
        }
        Time.timeScale = 1;
    }
    
    public void ResetState()
    {
        transform.position = new Vector3(-8, 0.5f, 0);
        Time.timeScale = 0;
        ResetVelocity();
    }

    private void Awake()
    {
        // Stop simulating
        Time.timeScale = 0;
        
        ResetVelocity();
    }

    private void Update()
    {
        // speed up timer
        if (isSpeedingUp)
        {
            speedUpTimer -= Time.deltaTime;
            if (speedUpTimer <= 0)
            {
                ResetVelocity();
                isSpeedingUp = false;
            }
        }
        
        // speed down timer
        if (isSpeedingDown)
        {
            speedDownTimer -= Time.deltaTime;
            if (speedDownTimer <= 0)
            {
                ResetVelocity();
                isSpeedingDown = false;
            }
        }
        
        if (transform.position.y <= -10)
        {
            ResetState();
        }
    }

    private void ResetVelocity()
    {
        rigidBidy.velocity = new Vector2(moveSpeed, 0);
    }
}

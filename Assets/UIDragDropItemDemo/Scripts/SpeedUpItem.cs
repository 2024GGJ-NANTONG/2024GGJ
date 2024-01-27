using UnityEngine;

public class SpeedUpItem : FunctionalItemBase
{
    [SerializeField]
    private float speedUpValue;

    [SerializeField]
    private float period;

    [SerializeField]
    private bool hideAfterTriggerEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerController = GetPlayerComponent<SimplePlayerController>(other);
        if (playerController != null)
        {
            playerController.SpeedUp(speedUpValue, period);

            if (hideAfterTriggerEnter)
            {
                Hide();
            }
            else
            {
                DisablePhysics();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        EnablePhysics();
    }
}

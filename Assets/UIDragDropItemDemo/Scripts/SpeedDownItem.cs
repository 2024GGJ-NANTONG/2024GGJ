using UnityEngine;

public class SpeedDownItem : FunctionalItemBase
{
    [SerializeField]
    private float speedDownValue;

    [SerializeField]
    private float period;

    [SerializeField]
    private bool hideAfterTriggerEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerController = GetPlayerComponent<SimplePlayerController>(other);
        if (playerController != null)
        {
            playerController.SpeedDown(speedDownValue, period);

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

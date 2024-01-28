using UnityEngine;

public class MagneticItem : FunctionalItemBase
{
    [SerializeField]
    private float period;

    [SerializeField]
    private GameObject magneticTargetPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = GetPlayerGameObject(other);
        if (player != null)
        {
            // only add magnetic target once
            if (!player.transform.Find("MagneticTarget"))
            {
                var magneticTargetObject = Instantiate(magneticTargetPrefab, player.transform);
                var magneticTargetComponent = magneticTargetObject.GetComponent<MagneticTarget>();
                magneticTargetComponent.targetRigidBody = player.GetComponent<Rigidbody2D>();
                magneticTargetComponent.period = period;
            }

            Hide();
        }
    }
}

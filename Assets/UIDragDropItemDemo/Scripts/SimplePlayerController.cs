using System;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBidy;
    
    [SerializeField]
    private float moveSpeed;

    private void Start()
    {
        rigidBidy.velocity = new Vector2(moveSpeed, 0);
    }

    private void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x >= Screen.width)
        {
            screenPos.x = 0;
        }

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        transform.position = worldPos;
    }
}

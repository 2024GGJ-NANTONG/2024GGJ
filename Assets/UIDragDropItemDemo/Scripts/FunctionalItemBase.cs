using UnityEngine;

public class FunctionalItemBase : MonoBehaviour
{
    [SerializeField]
    protected Collider2D mainCollider;

    [SerializeField]
    protected Rigidbody2D rigidBody;
    
    protected void EnablePhysics()
    {
        mainCollider.isTrigger = false;
        rigidBody.isKinematic = false;
    }
    
    protected void DisablePhysics()
    {
        mainCollider.isTrigger = true;
        rigidBody.isKinematic = true;
    }
    
    protected void Show()
    {
        gameObject.SetActive(true);
    }
    
    protected void Hide()
    {
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

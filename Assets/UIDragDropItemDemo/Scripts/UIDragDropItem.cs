using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private Image dragSourceImage;
    
    [SerializeField]
    private GameObject entityPrefab;

    private GameObject dragObject;
    private RectTransform dragRectTransform;
    private RectTransform canvasRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Find canvas
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.GetComponent<RectTransform>();
        }
        
        // Create an object only for showing drag sprite
        dragObject = new GameObject("DragSprite_" + entityPrefab.name);
        dragRectTransform = dragObject.AddComponent<RectTransform>();
        dragRectTransform.SetParent(canvasRectTransform);
        Image dragImage = dragObject.AddComponent<Image>();
        dragImage.sprite = dragSourceImage.sprite;
        
        dragObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void GenerateEntity()
    {
        if (entityPrefab != null)
        {
            Vector3 spawnPointScreen = canvasRectTransform.TransformPoint(dragRectTransform.anchoredPosition3D);
            Vector3 spawnPointWorld = Camera.main.ScreenToWorldPoint(spawnPointScreen);
            // fix z default value from -10 to 0.
            spawnPointWorld.z = 0;
            Instantiate(entityPrefab, spawnPointWorld, Quaternion.identity);
        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (dragObject != null)
        {
            dragObject.SetActive(true);
            dragObject.transform.SetAsLastSibling();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragObject != null)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);
            dragObject.transform.localPosition = localPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragObject != null)
        {
            dragObject.SetActive(false);
        }
        
        GenerateEntity();
    }
}

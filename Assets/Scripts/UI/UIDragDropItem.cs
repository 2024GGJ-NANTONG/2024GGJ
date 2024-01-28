using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GGJ
{
    public class UIDragDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler,
    IPointerMoveHandler, IPointerExitHandler
    {
        [SerializeField] 
        private Image dragSourceImage;
    
        [SerializeField] 
        private GameObject entityPrefab;
    
        [TextArea] [SerializeField] 
        private string infoText;
    
        private GameObject dragObject;
        private RectTransform dragRectTransform;
    
        private RectTransform canvasRectTransform;
    
        private RectTransform infoPanelRectTransform;
        private float infoPanelWidth;
        public float hoverDelay = 0.5f;
        private bool isHovering = false;
    
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
            dragImage.color = new Color(dragImage.color.r, dragImage.color.g, dragImage.color.b, 0.3f);
            dragObject.SetActive(false);
    
            infoPanelRectTransform = DragDropItemInfoPanel.Instance.gameObject.GetComponent<RectTransform>();
            infoPanelWidth = infoPanelRectTransform.rect.width;
        }
    
        private void GenerateEntity()
        {
            if (entityPrefab != null)
            {
                Vector3 spawnPointScreen = canvasRectTransform.TransformPoint(dragRectTransform.anchoredPosition3D);
                Vector3 spawnPointWorld = Camera.main.ScreenToWorldPoint(spawnPointScreen);
    
                // Fix z default value from -10 to 0.
                spawnPointWorld.z = 0;
                Instantiate(entityPrefab, spawnPointWorld, Quaternion.identity);
            }
        }
    
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (GameManager.Instance.IsSimulating)
            {
                return;
            }
            
            isHovering = false;
    
            if (dragObject != null)
            {
                dragObject.SetActive(true);
                dragObject.transform.SetAsLastSibling();
            }
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            if (GameManager.Instance.IsSimulating)
            {
                return;
            }
            
            if (dragObject != null)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position,
                    eventData.pressEventCamera, out Vector2 localPoint);
                dragRectTransform.anchoredPosition = localPoint;
            }
        }
    
        public void OnEndDrag(PointerEventData eventData)
        {
            if (GameManager.Instance.IsSimulating)
            {
                return;
            }
            
            if (dragObject != null)
            {
                dragObject.SetActive(false);
            }
    
            GenerateEntity();
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            isHovering = true;
    
            StartCoroutine(ShowInfoPanelDelayed());
        }
    
        public void OnPointerMove(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position,
                eventData.enterEventCamera, out Vector2 localPoint);
    
            Vector2 offset = localPoint.x + infoPanelWidth <= Screen.width
                ? new Vector2(10, 10)
                : new Vector2(-10 - infoPanelWidth, 10);
            DragDropItemInfoPanel.Instance.gameObject.transform.localPosition = localPoint + offset;
        }
    
        public void OnPointerExit(PointerEventData eventData)
        {
            isHovering = false;
            DragDropItemInfoPanel.Instance.SetText("");
            DragDropItemInfoPanel.Instance.gameObject.SetActive(false);
        }
    
        IEnumerator ShowInfoPanelDelayed()
        {
            // delay for a while
            yield return new WaitForSeconds(hoverDelay);
    
            if (isHovering)
            {
                DragDropItemInfoPanel.Instance.gameObject.SetActive(true);
                DragDropItemInfoPanel.Instance.SetText(infoText);
            }
        }
    }
}


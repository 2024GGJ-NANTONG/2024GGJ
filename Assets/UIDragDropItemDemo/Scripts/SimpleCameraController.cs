using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public enum CursorType
{
    Normal = 0,
    Moving
}

public class SimpleCameraController : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private Vector3 startPosition;
    
    [SerializeField]
    private float zoomSpeed = 5f;
    
    [SerializeField]
    private float minZoom = 5f;
    
    [SerializeField]
    private float maxZoom = 20f;

    [SerializeField]
    private Texture2D normalCursor;

    [SerializeField]
    private Texture2D movingCursor;

    private CursorType cursorType = CursorType.Normal;

    private Camera mainCamera;
    private Vector3 dragOrigin;

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
    
    void Awake()
    {
        mainCamera = GetComponent<Camera>();
        
        // disable follow cam in the beginning
        virtualCamera.enabled = false;
        
        Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
        cursorType = CursorType.Normal;

        ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSimulating())
        {
            virtualCamera.enabled = true;
            
            if (cursorType != CursorType.Normal)
            {
                Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
                cursorType = CursorType.Normal;
            }
        }
        else
        {
            virtualCamera.enabled = false;

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                // Free moving cam
                // Drag
            
                if (Input.GetMouseButtonDown(1))
                {
                    dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    Cursor.SetCursor(movingCursor, Vector2.zero, CursorMode.Auto);
                    cursorType = CursorType.Moving;
                }

                if (Input.GetMouseButton(1))
                {
                    Vector3 offset = dragOrigin - mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    mainCamera.transform.position += offset;
                }

                if (Input.GetMouseButtonUp(1))
                {
                    Cursor.SetCursor(normalCursor, Vector2.zero, CursorMode.Auto);
                    cursorType = CursorType.Normal;
                }
                
                // Scroll -> Zoom in zoom out
                float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
                ZoomCamera(scrollWheelInput);
            }
            else
            {
                dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

    private bool IsSimulating()
    {
        return Time.timeScale > 0;
    }
    
    private void ZoomCamera(float zoomInput)
    {
        float newZoom = Mathf.Clamp(mainCamera.orthographicSize - zoomInput * zoomSpeed, minZoom, maxZoom);
        mainCamera.orthographicSize = newZoom;
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GGJ
{
    public class UIManager : Singleton<UIManager>
    {
        private Canvas _canvas;
        private EventSystem _eventSystem;

        public UnityAction OnPlayButtonClicked;
        public UnityAction OnResetButtonClicked;

        private bool _isInitialized;
        
        public void InitCanvasAndEventSystem()
        {
            if (!_isInitialized)
            {
                var canvasPrefab = Resources.Load<GameObject>("Prefabs/UI/Canvas");
                var canvasObject = Instantiate(canvasPrefab, transform);
                _canvas = canvasObject.GetComponent<Canvas>();

                // Brute-force binding for now
                _canvas.transform.Find("PlayButton").GetComponent<Button>().onClick.AddListener(OnPlayButtonClicked);
                _canvas.transform.Find("ResetButton").GetComponent<Button>().onClick.AddListener(OnResetButtonClicked);
            
                var eventSystemPrefab = Resources.Load<GameObject>("Prefabs/UI/EventSystem");
                var eventSystemObject = Instantiate(eventSystemPrefab, transform);
                _eventSystem = eventSystemObject.GetComponent<EventSystem>();

                _isInitialized = true;
            }
        }
    }
}
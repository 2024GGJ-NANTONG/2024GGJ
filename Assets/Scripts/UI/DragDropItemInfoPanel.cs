using TMPro;
using UnityEngine;

namespace GGJ
{
    public class DragDropItemInfoPanel : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textMeshPro;
    
        public static DragDropItemInfoPanel Instance => _instance;
        private static DragDropItemInfoPanel _instance;

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                // DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        
            gameObject.SetActive(false);
        }

        public void SetText(string text)
        {
            textMeshPro.text = text;
        }
    }
}
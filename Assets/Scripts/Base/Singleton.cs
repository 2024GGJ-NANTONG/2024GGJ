using UnityEngine;

namespace GGJ
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        // Property to get the instance of the Singleton
        public static T Instance
        {
            get
            {
                // If the instance is null, try to find it in the scene
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    // If it's still null, create a new instance
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(T).Name);
                        _instance = singletonObject.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            // Ensure there is only one instance of the Singleton
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
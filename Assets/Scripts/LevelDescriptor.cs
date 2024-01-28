using System;
using UnityEngine;

namespace GGJ
{
    public class LevelDescriptor : MonoBehaviour
    {
        [SerializeField]
        private PlayerInstance _playerInstance;

        private void Awake()
        {
            BuffManager.Instance.AddNewOwner(_playerInstance);

            GameManager.Instance.InitPlayerInstance(_playerInstance);
            
            GameManager.Instance.InitBGM();
        }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0.0f;
            
            UIManager.Instance.OnPlayButtonClicked = () =>
            {
                GameManager.Instance.StartSimulating();
            };

            UIManager.Instance.OnResetButtonClicked = () =>
            {
                GameManager.Instance.ResetSimulation();
            };
            
            UIManager.Instance.OnReloadButtonClicked = () =>
            {
                GameManager.Instance.ReloadCurrentLevel();
            };
        
            UIManager.Instance.InitCanvasAndEventSystem();
        }
    }
}
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GGJ
{
    public class GameManager : Singleton<GameManager>
    {
        private PlayerInstance _playerInstance;
        private Rigidbody2D _playerRigidBody;
        private PlatformPlayerController _playerController;
        private Vector3 _playerSpawnPoint;
        private Vector2 _playerInitialVelocity;
        private PlatformCameraController _camera;

        public bool IsSimulating => _isSimulating;
        private bool _isSimulating;

        public void InitBGM()
        {
            if (gameObject.GetComponent<AudioSource>() == null)
            {
                var audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = Resources.Load<AudioClip>("Audio/GameLoop");
                audioSource.loop = true;
                audioSource.playOnAwake = true;
                audioSource.Play();
            }
        }
        
        public void InitPlayerInstance(PlayerInstance playerInstance)
        {
            _playerInstance = playerInstance;
            _playerRigidBody = _playerInstance.gameObject.GetComponent<Rigidbody2D>();
            _playerController = _playerInstance.gameObject.GetComponent<PlatformPlayerController>();
            _playerSpawnPoint = _playerInstance.transform.position;
            _playerInitialVelocity = new Vector2(_playerController.InitialSpeed, 0);
            _camera = FindAnyObjectByType<PlatformCameraController>();
        }
        
        public void StartSimulating()
        {
            _isSimulating = true;
            Time.timeScale = 1.0f;
            _camera.Reset();
        }
        
        public void ResetSimulation()
        {
            _isSimulating = false;
            Time.timeScale = 0.0f;
            _playerInstance.transform.position = _playerSpawnPoint;
            _playerRigidBody.velocity = _playerInitialVelocity;
            _playerInstance.ClearBuff();
        }

        public void ReloadCurrentLevel()
        {
            _isSimulating = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
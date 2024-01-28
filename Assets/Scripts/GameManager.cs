using UnityEngine;

namespace GGJ
{
    public class GameManager : Singleton<GameManager>
    {
        private PlayerInstance _playerInstance;
        private Rigidbody2D _playerRigidBody;
        private Vector3 _playerSpawnPoint;
        private Vector2 _playerInitialVelocity;
        private PlatformCameraController _camera;
        
        public void InitPlayerInstance(PlayerInstance playerInstance)
        {
            _playerInstance = playerInstance;
            _playerRigidBody = _playerInstance.gameObject.GetComponent<Rigidbody2D>();
            _playerSpawnPoint = _playerInstance.transform.position;
            _playerInitialVelocity = _playerRigidBody.velocity;
            _camera = FindAnyObjectByType<PlatformCameraController>();
        }
        
        public void StartSimulating()
        {
            Time.timeScale = 1.0f;
            _camera.Reset();
        }
        
        public void ResetSimulation()
        {
            Time.timeScale = 0.0f;
            _playerInstance.transform.position = _playerSpawnPoint;
            _playerRigidBody.velocity = _playerInitialVelocity;
            _playerInstance.ClearBuff();
        }
    }
}
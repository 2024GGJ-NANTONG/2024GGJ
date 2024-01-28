using UnityEngine;

namespace GGJ
{
    public class PlatformCameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform playerPos;

        [SerializeField]
        private Transform sceneBackgroundPos;

        public float speed;

        private void Start()
        {
            this.transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -10);
        }

        private void Update()
        {
            if (Time.timeScale == 0)
            {
                float x = Input.GetAxisRaw("Horizontal");
                float y = Input.GetAxisRaw("Vertical");

                this.transform.position = this.transform.position + new Vector3(x, y, 0) * speed;
            }

            sceneBackgroundPos.position =
                new Vector3(transform.position.x, transform.position.y, sceneBackgroundPos.position.z);
        }

        private void FixedUpdate()
        {
            if(Time.timeScale == 1)
                this.transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -10);
        }

        public void Reset()
        {
            this.transform.position = new Vector3(playerPos.position.x, playerPos.position.y, -10);
        }
    }
}
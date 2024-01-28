using GGJ;
using UnityEngine;

public class DemoLevel : MonoBehaviour
{
    [SerializeField]
    private PlayerInstance _playerInstance;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        
        BuffManager.Instance.AddNewOwner(_playerInstance);

        GameManager.Instance.InitPlayerInstance(_playerInstance);
        
        UIManager.Instance.OnPlayButtonClicked = () =>
        {
            GameManager.Instance.StartSimulating();
        };

        UIManager.Instance.OnResetButtonClicked = () =>
        {
            GameManager.Instance.ResetSimulation();
        };
        
        UIManager.Instance.InitCanvasAndEventSystem();
    }
}

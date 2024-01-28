using System.Collections;
using System.Collections.Generic;
using GGJ;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField]
    private string nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            GameManager.Instance.ResetSimulation();
            SceneManager.LoadScene(nextScene);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string levelName;
    public void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}

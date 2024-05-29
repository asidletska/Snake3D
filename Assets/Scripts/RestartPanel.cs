using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartPanel : MonoBehaviour
{
    public void OnPlayerHandler()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }
    public void OnExitHandler()
    {
        SceneManager.LoadScene(0);
    }
}

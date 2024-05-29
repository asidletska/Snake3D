using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayHandler ()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
    }
    public void SettingsHandler()
    {
        SceneManager.LoadScene(1);
    }
    public void OnExitHandler()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{   
    public void StartGame()
    {
        CanvasManager.Instance.OpenPage(StringManager.UIPAGE_MAINGAME);
        SceneManager.LoadScene(1);
    }

    public void Options()
    {

    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}

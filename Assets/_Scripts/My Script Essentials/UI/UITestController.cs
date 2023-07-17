using UnityEngine;

public class UITestController : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) OpenGamePlayUI();
        else if (Input.GetKeyDown(KeyCode.S)) OpenPostGameUI();
        else if (Input.GetKeyDown(KeyCode.D)) OpenMainMenuUI();
    }
    public void OpenGamePlayUI()
    {
        CanvasManager.Instance.OpenPage("Main Game Menu");
    }

    public void OpenPostGameUI()
    {
        CanvasManager.Instance.OpenPage("Post Game");
    }

    public void OpenMainMenuUI()
    {
        CanvasManager.Instance.OpenPage("Main Menu");
    }
}

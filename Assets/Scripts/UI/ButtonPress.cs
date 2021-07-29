using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
    public string SceneName = "";
    public int ButtonType;
    /*
        BUTTON TYPES
        1 - Start
        2 - Quit
        3 - ReadMe
    */

    private void OnMouseUp()
    {
        switch (ButtonType)
        {
            case 0:
                break;

            case 1:
                Application.targetFrameRate = 300;
                SceneManager.LoadScene(SceneName);
                break;

            case 2:
                Application.Quit();
                break;
        }
    }
}
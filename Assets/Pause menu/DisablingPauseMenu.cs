using UnityEngine;
using UnityEngine.UIElements;

public class DisablingPauseMenu : MonoBehaviour
{
    public Canvas canvas;
    public void Resume()
    {
        canvas.enabled = false;
        Time.timeScale = 1;
    }

    public void ExitToMenu()
    {
        SceneChanger.ChangeScene("start menu");
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartExit : MonoBehaviour
{
    public void Restart ()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame ()
    {
        SceneManager.LoadScene(1);
    }
}

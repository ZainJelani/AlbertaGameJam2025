using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuScript : MonoBehaviour
{
    const int startingScene = 1;

    public void OnPlayButton()
    {
        SceneManager.LoadScene(startingScene);
    }   

    public void OnQuitButton()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

   
    public void QuitGame()
    {
        Debug.Log("Wyj�cie z gry!");
        Application.Quit();
    }

   
    public void OpenOptions()
    {
        Debug.Log("Otwieranie opcji!");
    }
}


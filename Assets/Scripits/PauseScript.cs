using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public Timer Timeset;
    

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseMenu?.SetActive(false); //closes the pause menu
        Time.timeScale = 1; //resumes the time of the game from where it was paused at  
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("starting up");
        Time.timeScale = 1;

    }
    public void Restart()
    {   
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        
        
        Timeset.RestartTimer();
    }
    public void Exit() //a button option on the pause menu
    {
#if UNITY_EDITOR //this is used to work in unity game engine 
        UnityEditor.EditorApplication.isPlaying = false; //this gors into unity and force stop the game 
#endif //closing the if statement
        Application.Quit();//this is also added for when it is published
    }
}

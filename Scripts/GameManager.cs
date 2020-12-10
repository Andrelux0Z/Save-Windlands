using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool isPaused;
    public bool isDead;
    public GameObject pauseMenu;
    public GameObject dieMenu;

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           if (isPaused == false)
           {
               Pause();
           }
           else
           {
               Resume();
           }
       } 
    }

    public void Pause()
    {

        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;

    }

    public void Resume()
    {

        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;

    }
    
    public void ExitGame()
    {

        Application.Quit();

    }

    public void Restart()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isDead = false;

    }

    public void Die()
    {

        dieMenu.SetActive(true);
        isDead = true;

    }

    public void Win()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Next()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void ReturnToMenu()
    {

        SceneManager.LoadScene("TitleScene");
        PlayerPrefs.DeleteKey("collectible1");
        PlayerPrefs.DeleteKey("collectible2");
        PlayerPrefs.DeleteKey("collectible3");
    }

}

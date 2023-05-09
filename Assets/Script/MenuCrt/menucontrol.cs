using UnityEngine;
using UnityEngine.SceneManagement;

public class menucontrol : MonoBehaviour
{
    public bool paused = false;
    public GameObject PauseMenuUI;
    public GameObject pauseBttn;
    public GameObject scoretext;
    public GameObject gameOverpanel;

    public void loadCreditScene()
    { 
        SceneManager.LoadScene(2);
    }
    public void loadGameover()
    {
        pauseBttn.SetActive(false);
        gameOverpanel.SetActive(true);
    }
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void startGame/*load game scene*/()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void resume()
    {
        PauseMenuUI.SetActive(false);
        pauseBttn.SetActive(true);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        scoretext.SetActive(true);
    }
    public void pause()
    {
        pauseBttn.SetActive(false);
        PauseMenuUI.SetActive(true);
        scoretext.SetActive(false);
        Time.timeScale = 0f;
        paused = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}

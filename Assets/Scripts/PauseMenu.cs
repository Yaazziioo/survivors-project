using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Canvas för pausmenyn
    public static bool GameIsPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);  // Pausmenyn ska vara inaktiv vid spelets start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  // Tryck på "Escape" för att pausa
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Dölj pausmenyn
        Time.timeScale = 1f;  // Återuppta spelet
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);  // Visa pausmenyn
        Time.timeScale = 0f;  // Pausa spelet genom att stoppa tiden
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;  // Återställ tiden innan scenbyte
        SceneManager.LoadScene("Main Menu");  // Ladda huvudmenyscenen
    }

    public void QuitGame()
    {
        Application.Quit();  // Avsluta spelet
    }
}

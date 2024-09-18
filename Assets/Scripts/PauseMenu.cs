using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Canvas f�r pausmenyn
    public static bool GameIsPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);  // Pausmenyn ska vara inaktiv vid spelets start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  // Tryck p� "Escape" f�r att pausa
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
        pauseMenuUI.SetActive(false);  // D�lj pausmenyn
        Time.timeScale = 1f;  // �teruppta spelet
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
        Time.timeScale = 1f;  // �terst�ll tiden innan scenbyte
        SceneManager.LoadScene("Main Menu");  // Ladda huvudmenyscenen
    }

    public void QuitGame()
    {
        Application.Quit();  // Avsluta spelet
    }
}

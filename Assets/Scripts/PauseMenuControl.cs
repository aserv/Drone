using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour {

    public GameObject pauseMenu;
    public KeyCode pauseButton;

    private bool paused = false;
    public int currentLvl;

    void Awake() {
        currentLvl = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(pauseButton)) {
            ClickPause();
        }
    }

    public void ClickPause() {
        if (paused) {
            paused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        } else {
            paused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void ClickRestart() {
        SceneManager.LoadScene(currentLvl);
    }

    public void ClickQuit() {
        SceneManager.LoadScene(0);
    }
}

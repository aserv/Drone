using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour {

    public GameObject pauseMenu;
    public KeyCode pauseButton;

    private bool paused = false;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(pauseButton)) {
            clickPause();
        }
    }

    public void clickPause() {
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

    public void clickStart(int level) {
        SceneManager.LoadScene(level);
    }

    public void clickQuit() {
        SceneManager.LoadScene(0);
    }
}

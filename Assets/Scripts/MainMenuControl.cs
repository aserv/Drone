using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour {

    public GameObject ControlsPanel;
    public GameObject CreditsPanel;

    private bool control = false;
    private bool credits = false;

    public void clickPlay() {
        SceneManager.LoadScene(1);
    }

    public void clickControls() {
        if (control) {
            control = false;
            ControlsPanel.SetActive(false);
        } else {
            control = true;
            ControlsPanel.SetActive(true);
        }
    }

    public void clickQuit() {
        Application.Quit();
    }

    public void clickCredits() {
        if (credits) {
            credits = false;
            CreditsPanel.SetActive(false);
        } else {
            credits = true;
            CreditsPanel.SetActive(true);
        }
    }
}

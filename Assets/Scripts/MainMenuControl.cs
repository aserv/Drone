using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour {

    public void clickPlay() {
        SceneManager.LoadScene(1);
    }

    public void clickQuit() {
        Application.Quit();
    }
}

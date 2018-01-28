using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuControl : MonoBehaviour {

    public GameObject m_DeathPanel;

    public bool m_Dead = false;
    public int m_CurrentLevel;

    void Awake() {
        m_CurrentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update() {
        if (m_Dead) {
            PlayerDead();
        }
    }

    public void PlayerDead() {
        if (!m_Dead) {
            Time.timeScale = 1;
            m_DeathPanel.SetActive(false);
        }
       else {
            Time.timeScale = 0;
            m_DeathPanel.SetActive(true);
        }
    }

    public void ClickRestart() {
        m_Dead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerDead();
    }

    public void ClickQuit() {
        m_Dead = false;
        PlayerDead();
        SceneManager.LoadScene(0);
    }
}

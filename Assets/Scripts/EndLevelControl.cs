using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelControl : MonoBehaviour {

    public int currentLvl;
    public bool m_Active;

	// Use this for initialization
	void Awake () {
        m_Active = true;
        currentLvl = SceneManager.GetActiveScene().buildIndex;
	}

    void OnTriggerEnter(Collider col) {
        if (!m_Active) return;
        if (col.CompareTag("Player")) {
            SceneManager.LoadScene(currentLvl + 1);
        }
    }

    void Update() {
        if (m_Active == true && gameObject.activeSelf == false) {
            gameObject.SetActive(true);
        }
        if (m_Active == false && gameObject.activeSelf == true) {
            gameObject.SetActive(false);
        }
    }

    public void ChangeActive(bool state) {
        m_Active = state;
    }
}

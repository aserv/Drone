using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelControl : MonoBehaviour {

    public int currentLvl;

	// Use this for initialization
	void Awake () {
        currentLvl = SceneManager.GetActiveScene().buildIndex;
	}

    void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player")) {
            SceneManager.LoadScene(currentLvl + 1);
        }
    }
}

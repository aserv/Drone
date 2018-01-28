using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileControl : MonoBehaviour {

    public GameObject m_End;
    public bool m_Grabbed = false;
    
    void Start() {
        m_End.GetComponent<EndLevelControl>().ChangeActive(false);
    }

    void Update() {
        if (m_Grabbed) {
            Destroy(gameObject);
            ActivateEnd(true);
        }
    }

    public void ActivateEnd(bool state) {
        m_End.GetComponent<EndLevelControl>().ChangeActive(state);
        m_End.SetActive(state);
    }
}

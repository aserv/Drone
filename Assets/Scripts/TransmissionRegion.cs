﻿using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TransmissionRegion : MonoBehaviour {
    public TransmissionSource m_TransmissionSource;

    private bool m_Active;

    void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player")) {
            col.GetComponent<PlayerDroneControl>().SetCommandState(true);
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.CompareTag("Player")) {
            col.GetComponent<PlayerDroneControl>().SetCommandState(false);
        }
    }

    public void Activate(bool val) {
        m_Active = val;
        GetComponent<SpriteRenderer>().color = m_Active ? Color.white : Color.blue;
        GetComponent<Collider>().enabled = m_Active;
        if (m_TransmissionSource != null) m_TransmissionSource.Activate(val); 
    }
}

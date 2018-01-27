using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInZone : MonoBehaviour
{
    public TransmissionRegion[] m_ToggleZones;
    [SerializeField]
    private bool m_Active;

    void Awake() {
        Activate(m_Active);
    }

    void Activate(bool val) {
        foreach (var t in m_ToggleZones) {
            t.Activate(val);
        }
    }

    public void ToggleActive() {
        Activate(m_Active = !m_Active);
    }
}

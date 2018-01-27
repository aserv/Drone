using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TransmissionRegion : MonoBehaviour {
    private bool m_Active;

    void OnTriggerEnter(Collider col) {
        Debug.Log("Enter");
        if (col.CompareTag("Player")) {
            col.GetComponent<PlayerDroneControl>().SetCommandState(true);
        }
    }

    void OnTriggerExit(Collider col) {
        Debug.Log("Exit");
        if (col.CompareTag("Player")) {
            col.GetComponent<PlayerDroneControl>().SetCommandState(false);
        }
    }

    public void Activate(bool val) {
        m_Active = val;
        GetComponent<SpriteRenderer>().color = m_Active ? Color.white : Color.gray;
        GetComponent<Collider>().enabled = m_Active;
    }
}

using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TransmissionRegion : MonoBehaviour {
    void OnTriggerEnter(Collider col) {
        Debug.Log("Enter");
        Debug.Log(col);
        if (col.CompareTag("Player")) {
            col.GetComponent<PlayerDroneControl>().SetCommandState(true);
        }
    }

    void OnTriggerExit(Collider col) {
        Debug.Log("Exit");
        Debug.Log(col);
        if (col.CompareTag("Player")) {
            col.GetComponent<PlayerDroneControl>().SetCommandState(false);
        }
    }
}

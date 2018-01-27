using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TransmissionRegion : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            col.GetComponent<PlayerDroneControl>().SetCommandState(true);
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            col.GetComponent<PlayerDroneControl>().SetCommandState(false);
        }
    }
}

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerDroneControl : MonoBehaviour {
    public float m_MoveSpeed;
    public Transform m_StartPos;

    private Vector2 m_MoveVector;
    private bool m_CanCommand = true;
    private NavMeshAgent m_Agent;
    private bool m_CommandDown;

    void Awake() {
        //GetComponent<NavMeshAgent>().destination = m_Destination.position;
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.Warp(m_StartPos.position);
    }

    void Update() {
        if (!m_CanCommand) return;
        if (m_CommandDown) {
            m_CommandDown = Input.GetAxisRaw("Command") > 0;
        } else if (Input.GetAxisRaw("Command") > 0) {
            m_CommandDown = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * 2, Vector3.down, out hit, 4, 1 << LayerMask.NameToLayer("Terminal"), QueryTriggerInteraction.Collide)) {
                hit.collider.gameObject.GetComponent<CommandInZone>().ToggleActive();
            }
        }
        m_MoveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); 
    }

    void FixedUpdate() {
        //Make this smoother
        Vector2 vel = m_MoveSpeed * m_MoveVector * Time.deltaTime;
        m_Agent.Move(new Vector3(vel.x, 0, vel.y));
        //m_RigidBody.velocity = new Vector3(vel.x, 0, vel.y);
    }

    static int IntSign(float f) {
        if (f < 0) {
            return -1;
        } else if (f > 0) {
            return 1;
        } else {
            return 0;
        }
    }

    public void SetCommandState(bool state) {
        m_CanCommand = state;
    }
}

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerDroneControl : MonoBehaviour {
    public float m_MoveSpeed;
    public Transform m_Destination;

    private Vector2 m_MoveVector;
    private bool m_CanCommand = true;
    private Rigidbody m_RigidBody;
    private NavMeshAgent m_Agent;

    void Awake() {
        //GetComponent<NavMeshAgent>().destination = m_Destination.position;
        m_RigidBody = GetComponent<Rigidbody>();
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if (!m_CanCommand) return;
        m_MoveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); 
    }

    void FixedUpdate() {
        Vector2 vel = m_RigidBody.velocity;
        //Make this smoother
        vel = m_MoveSpeed * m_MoveVector;
        //m_Agent.Move(new Vector3(m_MoveVector.x, 0, m_MoveVector.y));
        m_RigidBody.velocity = new Vector3(vel.x, 0, vel.y);
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

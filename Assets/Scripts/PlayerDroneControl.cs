using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerDroneControl : MonoBehaviour {
    public float m_MoveSpeed;

    private Vector2 m_MoveVector;
    private bool m_CanCommand = true;
    private Rigidbody2D m_RigidBody;

    void Awake() {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (!m_CanCommand) return;
        m_MoveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); 
    }

    void FixedUpdate() {
        Vector2 vel = m_RigidBody.velocity;
        //Make this smoother
        vel = m_MoveSpeed * m_MoveVector;
        m_RigidBody.velocity = vel;
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

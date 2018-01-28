using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerDroneControl : MonoBehaviour {
    public float m_MoveSpeed;
    public Transform m_StartPos;
    public float m_SignalDelay;

    private Rigidbody m_RigidBody;
    private Vector2 m_MoveVector;
    private bool m_CanCommand = true;
    private NavMeshAgent m_Agent;
    private bool m_CommandDown;
    //private float m_CommandDelay = 0f;
    private Vector3 continuationVector;

    void Start() {
        transform.position = m_StartPos.position;
        m_RigidBody = GetComponent<Rigidbody>();
    }

    void Update() {
        //if (m_CommandDelay > 0) {
        //    m_CommandDelay -= Time.deltaTime;
        //    if (m_CommandDelay <= 0) {
        //        m_CanCommand = !m_CanCommand;
        //    }
        //}
        if (!m_CanCommand) return;
        if (m_CommandDown) {
            m_CommandDown = Input.GetAxisRaw("Command") > 0;
        } else if (Input.GetAxisRaw("Command") > 0) {
            m_CommandDown = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * 2, Vector3.down, out hit, 4, 1 << LayerMask.NameToLayer("Terminal"), QueryTriggerInteraction.Collide)) {
                hit.collider.gameObject.GetComponent<CommandInZone>().ToggleActive();
            }
            if (Physics.Raycast(transform.position + Vector3.up * 2, Vector3.down, out hit, 4, 1 << LayerMask.NameToLayer("File"), QueryTriggerInteraction.Collide))
            {

            }
        }
        //m_MoveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); 
    }

    void FixedUpdate() {
        if (m_CanCommand) {
            float hmove = m_MoveSpeed * Input.GetAxis("Horizontal");
            float vmove = m_MoveSpeed * Input.GetAxis("Vertical");
            float ahmove = Mathf.Abs(hmove);
            float avmove = Mathf.Abs(vmove);
            if (ahmove > avmove && ahmove >= 0.1) {
                continuationVector = new Vector3(hmove, 0, 0) * Time.deltaTime;
                transform.Translate(continuationVector);
                return;
            } else if (avmove >= 0.1) {
                continuationVector = new Vector3(0, 0, vmove) * Time.deltaTime;
                transform.Translate(continuationVector);
                return;
            }

        } else {
            transform.Translate(continuationVector);
        }
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
        //if (state != m_CanCommand) {
        //    if (m_CommandDelay <= 0) {
        //        m_CommandDelay = m_SignalDelay;
        //    }
        //} else {
        //    m_CommandDelay = 0f;
        //}
        m_CanCommand = state;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBaseControl : MonoBehaviour {
    public PatrolPathPoint[] m_PatrolPath;

    private NavMeshAgent m_Agent;
    private bool m_Patroling = true;
    private int m_PathIndex = 0;
    private double m_WaitTime = 0;
    
    void Start() {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.Warp(m_PatrolPath[0].m_Position.position);
        m_Agent.destination = transform.position;
        if (m_PatrolPath == null || m_PatrolPath.Length == 0) m_Patroling = false;
    }

    void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player")) {
            Debug.Log("Seen");
        }
    }

    void Update() {
        if (!m_Patroling) return;
        if (m_Agent.remainingDistance < 0.1) {
            m_WaitTime -= Time.deltaTime;
            if (m_WaitTime <= 0) {
                m_PathIndex = (m_PathIndex + 1) % m_PatrolPath.Length;
                m_WaitTime = m_PatrolPath[m_PathIndex].m_WaitTime;
                m_Agent.destination = m_PatrolPath[m_PathIndex].m_Position.position;
            }
        }
    }
}

[Serializable]
public struct PatrolPathPoint {
    public Transform m_Position;
    [Range(0, 60)]
    public float m_WaitTime;
}

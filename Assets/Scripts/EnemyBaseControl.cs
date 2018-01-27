using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public class EnemyBaseControl : MonoBehaviour {
    public float m_PatrolSpeed;
    public float m_ChaseSpeed;
    public PatrolPathPoint[] m_PatrolPath;
    public float m_SearchTime;

    private enum AlertState {
        Idle,
        Patroling,
        Chasing,
        Searching,
    }
    private NavMeshAgent m_Agent;
    [SerializeField]
    private AlertState m_AlertState = AlertState.Idle;
    private int m_PathIndex = 0;
    private double m_WaitTime = 0;
    private GameObject m_TargetPlayer;

    
    void Start() {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.Warp(m_PatrolPath[0].m_Position.position);
        m_Agent.destination = CleanDestination(transform.position);
        if (m_PatrolPath != null || m_PatrolPath.Length != 0) m_AlertState = AlertState.Patroling;
    }

    void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player")) {
            m_TargetPlayer = col.gameObject;
            m_AlertState = AlertState.Chasing;
            m_Agent.speed = m_ChaseSpeed;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.gameObject == m_TargetPlayer) {
            m_TargetPlayer = null;
        }
    }

    void Update() {
        switch (m_AlertState) {
        case AlertState.Idle:
            return;
        case AlertState.Patroling:
            PatrolAction();
            return;
        case AlertState.Chasing:
            ChaseAction();
            return;
        case AlertState.Searching:
            SearchAction();
            return; 
        } 
    }

    void PatrolAction() {
        if (m_Agent.remainingDistance < 0.1) {
            m_WaitTime -= Time.deltaTime;
            if (m_WaitTime <= 0) {
                m_PathIndex = (m_PathIndex + 1) % m_PatrolPath.Length;
                m_WaitTime = m_PatrolPath[m_PathIndex].m_WaitTime;
                m_Agent.destination = CleanDestination(m_PatrolPath[m_PathIndex].m_Position.position);
            }
        }
    }

    void ChaseAction() {
        if (m_TargetPlayer) {
            m_Agent.destination = CleanDestination(m_TargetPlayer.transform.position);
        } else if (m_Agent.remainingDistance < 0.1) {
            m_AlertState = AlertState.Searching;
            m_WaitTime = m_SearchTime;
        }
    }

    void SearchAction() {
        //Some sort of wandering action
        m_WaitTime -= Time.deltaTime;
        if (m_WaitTime <= 0) {
            m_AlertState = AlertState.Patroling;
            m_Agent.speed = m_PatrolSpeed;
            float minDist = float.MaxValue;
            int minIndex = 0;
            for (int i = 0; i < m_PatrolPath.Length; i++) {
                float d = (m_PatrolPath[i].m_Position.position - transform.position).sqrMagnitude;
                if (d < minDist) {
                    minDist = d;
                    minIndex = i;
                }
            }
            m_PathIndex = minIndex;
        }
    }

    Vector3 CleanDestination(Vector3 v) {
        return new Vector3(v.x, transform.position.y, v.z);
    }
}

[Serializable]
public struct PatrolPathPoint {
    public Transform m_Position;
    [Range(0, 60)]
    public float m_WaitTime;
}

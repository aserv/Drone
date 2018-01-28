using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.AI;

[CustomEditor(typeof(MapBaker))]
public class EditorMapBaker : Editor {
    public override void OnInspectorGUI() {
        /*
        if (GUILayout.Button("Rebake Mesh")) {
            MapBaker mb = (target as MapBaker);
            GameObject tgo = mb.gameObject;
            List<NavMeshBuildSource> sources = new List<NavMeshBuildSource>();
            foreach (Transform c in tgo.GetComponentsInChildren<Transform>()) {
                int surface;
                if (c.gameObject.CompareTag("Walkable")) {
                    surface = 0;
                } else if (c.gameObject.CompareTag("Wall")) {
                    surface = 1;
                } else {
                    continue;
                }
                foreach (BoxCollider b in c.GetComponents<BoxCollider>()) {
                    NavMeshBuildSource s = new NavMeshBuildSource();
                    s.shape = NavMeshBuildSourceShape.Box;
                    s.area = surface;
                    s.size = b.size;
                    s.transform = b.transform.localToWorldMatrix;
                }
            }
            
            NavMeshBuildSettings settings = new NavMeshBuildSettings();
            NavMeshData data = NavMeshBuilder.BuildNavMeshData(settings, sources, new Bounds(), Vector3.zero, Quaternion.identity);
            //Scene open = EditorSceneManager.GetActiveScene();
            NavMesh.AddNavMeshData(data);
        }
        */

        DrawDefaultInspector();
        if (GUILayout.Button("Create Mesh Objects")) {
            MapBaker mb = (target as MapBaker);
            GameObject tgo = mb.gameObject;
            foreach (Transform c in tgo.GetComponentsInChildren<Transform>()) {
                if (c.gameObject.CompareTag("Walkable") || c.gameObject.CompareTag("Wall")) {
                    foreach (BoxCollider b in c.GetComponents<BoxCollider>()) {
                        GameObject go = new GameObject("temp" + c.gameObject.tag);
                        go.tag = "Temp";
                        go.transform.parent = c.transform;
                        go.transform.localRotation = Quaternion.identity;
                        go.transform.localPosition = b.center;
                        go.transform.localScale = b.size;
                        MeshFilter mf = go.AddComponent<MeshFilter>();
                        mf.mesh = mb.m_CubeMesh;
                        go.AddComponent<MeshRenderer>();
                    }
                }
            }
        }
        if (GUILayout.Button("Clear Generated Objects")) {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Temp")) {
                DestroyImmediate(go);
            }
        }
    }
}

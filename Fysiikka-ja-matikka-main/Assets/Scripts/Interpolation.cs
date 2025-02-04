using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class Interpolation : MonoBehaviour
{
    public GameObject ObjA;
    public GameObject ObjB;

    [Range(0f, 1f)]
    public float t = 0.0f;

    // How long does the interpolation take in seconds:
    public float InterpTime = 5.0f;
    // Use vectors to make computation code easier to type and read
    private Vector3 posA;
    private Vector3 posB;

    public GameObject sonic;
    private void DrawVectorAt(Vector3 pos, Vector3 vec, Color c, float thickness = 1.0f)
    {
        Color orig = Handles.color;
        Handles.color = c;
        Handles.DrawLine(pos, pos + vec, thickness);

        Handles.ConeHandleCap(0, pos + vec - 0.2f * vec.normalized, Quaternion.LookRotation(vec), 0.286f, EventType.Repaint);
        Handles.color = orig;

    }

        private void OnDrawGizmos()
    {
        Vector3 posA = ObjA.transform.position;
        Vector3 posB = ObjB.transform.position;

            DrawVectorAt(Vector3.zero, posA, Color.gray, 1.0f);
            DrawVectorAt(Vector3.zero, posB, Color.gray, 1.0f);

        Vector3 posInt = (1-t)*posA + t*posB;
        DrawVectorAt(Vector3.zero, posInt, Color.black, 2.0f);
        Handles.color = Color.white;
        Handles.DrawLine(posA, posB, 2.0f);
        }

    private void Start()
    {
        posA = ObjA.transform.position;
        posB = ObjB.transform.position;
    }

    private void Update()
    {
        float t = Time.time / InterpTime;
        if (t > 1.0f)
            t = 1.0f; 
         Vector3 interpPos = (1 - t) * posA + t * posB;
        sonic.transform.position = interpPos;
    }
}

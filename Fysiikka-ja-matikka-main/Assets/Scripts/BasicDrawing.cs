using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BasicDrawing : MonoBehaviour
{
    [SerializeField]
    public float axis_length = 3.0f;

    public GameObject VectorTo;

    public GameObject RectanglePos;
    [Range(0.1f, 20f)]
    public float RectWidth = 5.0f;
    [Range(0.1f, 10f)]
    public float RectHeight = 3.0f;


    private void DrawXYRectAt(Vector3 pos, float width, float height, Color c)
    {

        pos = RectanglePos.transform.position;
            width = RectWidth;
        height = RectHeight;

        Vector3 vertical = new Vector3(0, height, 0);
        Vector3 horizontal = new Vector3(width, 0, 0);

        Gizmos.color = c;
        Gizmos.DrawLine(pos, pos + horizontal);
        Gizmos.DrawLine(pos, pos + vertical);
        Gizmos.DrawLine(pos + horizontal, pos + horizontal + vertical);
        Gizmos.DrawLine(pos + vertical, pos + horizontal + vertical);
    }


    private void OnDrawGizmos()
    {
        //Draw X-AXIS (red)
        Gizmos.color = Color.red;
        //Draws a line "from" -- "to" (x,y,z)
        Gizmos.DrawLine(Vector3.zero,
            new Vector3(axis_length,0,0));

        //Draw Y-AXIS (green)
        Gizmos.color = Color.green;
        //Draws a line "from" -- "to" (x,y,z)
        Gizmos.DrawLine(Vector3.zero,
            new Vector3(0, axis_length, 0));


        // Unit circle
        Handles.color= Color.white;
        Handles.DrawWireDisc(Vector3.zero, Vector3.back, 1.0f);

        //Given vector (from origin ---> VectorTo)
        Gizmos.color = Color.black;
        Gizmos.DrawLine(Vector3.zero,
            VectorTo.transform.position);


        // Rectangle
        DrawXYRectAt(new Vector3(1,2,0), RectWidth, RectHeight, Color.magenta);


    }
}

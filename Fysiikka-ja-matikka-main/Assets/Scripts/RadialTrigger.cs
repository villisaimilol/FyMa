using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    //[Min(0.1f)]
    [Range(0.1f, 10f)]
    public float Radius = 5.0f;
    public bool DrawRadius = true;

    public GameObject Target;
    public float closeDistance = 5.0f;



    private void OnDrawGizmos()
    {
        bool bTriggered = false;    

        Vector3 vecTriggerPos = transform.position;
        Vector3 vecTargetPos = Target.transform.position;
        //  Compute vector from trigger to target?
        Vector3 vecTriggerToTarget = vecTargetPos - vecTriggerPos;
        // TODO:
        // - check if target is closer than radius
        // - change color accordingly
        if ((vecTargetPos - vecTriggerPos).magnitude <= Radius)
        {
            bTriggered= true;
        }
 
        // 1. Draw trigger radius

        if (DrawRadius)
        {
            if (bTriggered)
            {
                Handles.color = Color.yellow;
                Handles.DrawWireDisc(vecTriggerPos, Vector3.forward, Radius, 3f);
            }
            else
            {
                Handles.color = new Color32(0xFA, 0xBB, 0xFF, 0xF0);
                Handles.DrawWireDisc(vecTriggerPos, Vector3.forward, Radius, 3f);
            }

        }

        // 2. Draw vectors:
        //    - from origin to trigger position
        MyDraw.DrawVectorAt(Vector3.zero, vecTriggerPos, Color.red, 3f);

        //    - from origin to target
        MyDraw.DrawVectorAt(Vector3.zero, vecTargetPos, Color.blue, 3f);

        //    - FROM TRIGGER TO TARGET!!! :3

        // Draw from trigger to target?
        MyDraw.DrawVectorAt(vecTriggerPos, vecTriggerToTarget,
                                           Color.magenta, 4f);
    }
}

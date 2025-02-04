using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : MonoBehaviour
{
    public GameObject LookAt;
    public GameObject Target;

    [Range(-1f, 1f)]
    public float Treshold = 0.8f;

    private void OnDrawGizmos()
    {
        Vector3 vecTriggerPos = transform.position;
        Vector3 vecTargetPos = Target.transform.position;
        Vector3 vecLookAtPos = LookAt.transform.position;
        //  Compute vector from trigger to target?
        Vector3 v = vecTargetPos - vecTriggerPos;
        // Compute vector from trigger to LookAt
        Vector3 l = vecLookAtPos - vecTriggerPos;

        // Look vector
        MyDraw.DrawVectorAt(vecTriggerPos, l, Color.blue, 3f);
        //Target vector
        MyDraw.DrawVectorAt(vecTriggerPos, v, Color.green, 3f);

        // Normalize l and v
        Vector3 l_hat = l.normalized;
        Vector3 v_hat = v.normalized;

        // Normalized Look vector
        MyDraw.DrawVectorAt(vecTriggerPos, l_hat, Color.blue, 3f);
        // Normalized Target vector
        MyDraw.DrawVectorAt(vecTriggerPos, v_hat, Color.green, 3f);

        float dotprod = Vector3.Dot(v_hat, l_hat);
        Debug.Log(dotprod);

        if(dotprod > Treshold)
        {
            MyDraw.DrawVectorAt(vecTriggerPos, v, Color.red, 5f);
        }

    }
}

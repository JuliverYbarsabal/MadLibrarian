using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] private float waypointSize = 1f;
    private void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }


        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }

        //loop the waypoints objects red line
        //Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
    }

    public Transform GetNextWaypoint(Transform currentWaypoint)
    {
        if (currentWaypoint == null)
        {
            return transform.GetChild(0);
        }

        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        else
        {
            //loops back the waypoint to the first waypoint 
            return transform.GetChild(0);

            //stays at the very last waypoint
            //return transform.GetChild(transform.childCount - 1);
        }


    }
}

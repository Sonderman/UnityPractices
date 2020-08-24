using UnityEngine;

public class Path : MonoBehaviour
{
    public LineRenderer lineRenderer { get { return GetComponent<LineRenderer>(); } }
    public Transform[] waypoints;

    Vector3[] waypointPositions;

    void Awake()
    {
        waypointPositions = new Vector3[waypoints.Length];
        lineRenderer.positionCount = waypoints.Length;
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypointPositions[i] = waypoints[i].position;
        }
        lineRenderer.SetPositions(waypointPositions);
    }

    public Vector3 getPoint(int index)
    {
        return waypointPositions[index];
    }

    public Vector3 getlastPoint()
    {
        return waypointPositions[waypointPositions.Length - 1];
    }

    public int Length { get { return waypoints.Length; } }
}

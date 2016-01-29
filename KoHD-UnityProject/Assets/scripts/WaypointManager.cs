using UnityEngine;
using System.Collections;

public class WaypointManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] waypoints;

    public GameObject[] GetWaypoints()
    {
        return waypoints;
    }

}

using UnityEngine;
using System.Collections;

public class WaypointManager : MonoBehaviour {

    public static WaypointManager Instance;

    [SerializeField]
    private GameObject[] waypoints;


    void Awake()
    {
        Instance = this;
    }


    public GameObject[] GetWaypoints()
    {
        return waypoints;
    }

}

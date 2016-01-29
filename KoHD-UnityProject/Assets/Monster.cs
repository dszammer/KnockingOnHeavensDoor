using UnityEngine;
using System.Collections;
using System;

public class Monster : MonoBehaviour {

    [SerializeField]
    private int health = 1000;
    [SerializeField]
    private float speed = 0.5f;

    private Transform nextWaypoint;
    private GameObject[] WaypointsArray;
    

    // Use this for initialization
    void Start () {

        WaypointsArray = WaypointManager.Instance.GetWaypoints();

        nextWaypoint = WaypointsArray[0].transform;
    }
	
	// Update is called once per frame
	void Update () {
        MoveToNextWaypoint();
	}

    private void MoveToNextWaypoint()
    {
        Vector3 actualPos = gameObject.transform.position;
        Vector3 destinationPos = nextWaypoint.position;

        actualPos += (destinationPos - actualPos).normalized * speed * Time.deltaTime;
        
        gameObject.transform.position = actualPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(nextWaypoint.gameObject))
        {
            SetNextWaypoint();
        }
    }

    void SetNextWaypoint()
    {
        if (nextWaypoint.GetSiblingIndex() >= WaypointsArray.Length - 1)
        {
            nextWaypoint = WaypointsArray[0].transform;
        }
        else
        {
            nextWaypoint = WaypointsArray[nextWaypoint.GetSiblingIndex() + 1].transform;
        }
    }

}

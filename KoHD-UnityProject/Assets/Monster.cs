using UnityEngine;
using System.Collections;
using System;

public class Monster : MonoBehaviour {

    [SerializeField]
    private int health = 1000;
    [SerializeField]
    private float speed = 0.5f;

    private Transform nextWaypoint;
    private GameObject WaypointArray;

    // Use this for initialization
    void Start () {
        //this.transform.position;
        WaypointArray = GameObject.Find("Waypoints");
        nextWaypoint = WaypointArray.transform.GetChild(4);
        //Debug.Log(nextWaypoint.GetSiblingIndex());
        //SetNextWaypoint();

        //Debug.Log(nextWaypoint.GetSiblingIndex());
    }
	
	// Update is called once per frame
	void Update () {
        MoveToNextWaypoint();
	}

    private void MoveToNextWaypoint()
    {
        //Debug.Log(gameObject.transform.position);
        Vector3 actualPos = gameObject.transform.position;
        Vector3 destinationPos = nextWaypoint.position;

         actualPos += (destinationPos - actualPos).normalized * speed * Time.deltaTime;

        //Vector3 newPos = new Vector3(actualPos.x + (destinationPos.x - actualPos.x) * speed, actualPos.y + (destinationPos.y - actualPos.y) * speed, actualPos.z);
        gameObject.transform.position = actualPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided WayPoint" + nextWaypoint.GetSiblingIndex());
        if (other.gameObject.transform.Equals(nextWaypoint))
        {
            Debug.Log("Switch WayPoint" + nextWaypoint.GetSiblingIndex()+1);
            SetNextWaypoint();
        }
        //WaypointArray.transform.
    }

    void SetNextWaypoint()
    {
        if(nextWaypoint.GetSiblingIndex() >= WaypointArray.transform.childCount - 1)
        {
            nextWaypoint = WaypointArray.transform.GetChild(0);
        }
        else
        {
            nextWaypoint = WaypointArray.transform.GetChild(nextWaypoint.GetSiblingIndex() + 1);
        }
    }

}

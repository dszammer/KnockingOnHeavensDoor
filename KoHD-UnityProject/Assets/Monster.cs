using UnityEngine;
using System.Collections;
using System;

public class Monster : MonoBehaviour {

    [SerializeField]
    private int health = 1000;
    [SerializeField]
    private int speed = 5;

    private Vector3 nextWaypoint;

    
    // Use this for initialization
    void Start () {
        //this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        MoveToNextWaypoint();
	}

    private void MoveToNextWaypoint()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

    }

}

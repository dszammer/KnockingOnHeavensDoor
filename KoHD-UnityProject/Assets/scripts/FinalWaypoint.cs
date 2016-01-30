using UnityEngine;
using System.Collections;

public class FinalWaypoint : MonoBehaviour {

	public GameObject gameManager;
	private GameManager gm;

	// Use this for initialization
	void Start () {
		gm = gameManager.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		gm.MonsterFinished ();
	}
}

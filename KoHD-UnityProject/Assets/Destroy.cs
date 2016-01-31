using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 2.0f);
	}
}

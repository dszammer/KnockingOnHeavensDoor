using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MenuButton(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}

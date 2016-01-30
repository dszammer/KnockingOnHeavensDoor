using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartButton(string scene)
    {
        SceneManager.LoadScene(scene);
    } 
    public void ExitButton()
    {
        Application.Quit();
    }
}

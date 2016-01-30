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
    public void CreditsButton()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("CreditsCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;
        GameObject.Find("CreditsCanvas").GetComponent<CanvasGroup>().alpha = 1;
    }
    public void ReturnButton()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("MenuCanvas").GetComponent<CanvasGroup>().blocksRaycasts = true;
        GameObject.Find("MenuCanvas").GetComponent<CanvasGroup>().alpha = 1;
    }
}

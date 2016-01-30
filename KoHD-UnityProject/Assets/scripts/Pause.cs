using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {


    private bool paused = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseButton();
            }
            else
            {
                PlayButton();
            }
        }
        
	}

    public void PauseButton()
    {
        Time.timeScale = 0;
        paused = true;
        GameObject.Find("IngameUI").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("IngameUI").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("IngameUI").GetComponent<CanvasGroup>().alpha = .2f;
        GameObject.Find("PauseScreen").GetComponent<CanvasGroup>().blocksRaycasts = true;
        GameObject.Find("PauseScreen").GetComponent<CanvasGroup>().alpha = .8f;
        GameObject.Find("PauseScreen").GetComponent<CanvasGroup>().interactable = true;


        GameObject.Find("MonsterSpawner").GetComponent<MonsterSpawner>().enabled = false;
    }


    public void PlayButton()
    {
        Time.timeScale = 1;
        paused = false;
        GameObject.Find("PauseScreen").GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject.Find("PauseScreen").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("PauseScreen").GetComponent<CanvasGroup>().alpha = 0;
        
        GameObject.Find("IngameUI").GetComponent<CanvasGroup>().alpha = 1f;
        GameObject.Find("IngameUI").GetComponent<CanvasGroup>().interactable = true;
        GameObject.Find("IngameUI").GetComponent<CanvasGroup>().blocksRaycasts = true;


        GameObject.Find("MonsterSpawner").GetComponent<MonsterSpawner>().enabled = true;
    }
}

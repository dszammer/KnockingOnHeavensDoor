using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject textField;
	private GUIText text;

	public int monsterToWin = 100;
	private int monstersInGoal = 0;

	public float levelTimeLimitSeconds = 60;
	private float levelTimePassed = 0;

	public void MonsterFinished(){
		monstersInGoal++;
		if (monstersInGoal >= monstersInGoal) {
			SceneManager.LoadScene ("winScreen");
		}
	}

	// Use this for initialization
	void Start () {
		text = textField.GetComponents<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		levelTimePassed += Time.deltaTime;
		text.text = "Time Left: " + (levelTimeLimitSeconds - levelTimePassed) + "s";
		if (levelTimePassed >= levelTimeLimitSeconds) {
			SceneManager.LoadScene ("loseScreen");
		}
	}
}

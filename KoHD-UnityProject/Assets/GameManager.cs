using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

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
		
	}
	
	// Update is called once per frame
	void Update () {
		levelTimePassed += Time.deltaTime;
		if (levelTimePassed >= levelTimeLimitSeconds) {
			SceneManager.LoadScene ("loseScreen");
		}
	}
}

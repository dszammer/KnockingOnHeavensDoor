using UnityEngine;
using System.Collections;

public class GoatGrinder : MonoBehaviour {

	private float leftStickVerticalValue;
	private float leftStickHorizontalValue;
	private float leftStickAngle;

	private float[] mainAngles = { 0, 90, 180, 90 };
	private float angleAccuracy = 10;
	private float currentAngleIndex = -1;

	// Use this for initialization
	void Start () {
		
	}

	void CalculateAngle(){
		leftStickVerticalValue = Input.GetAxis("VerticalLeft");
		leftStickHorizontalValue = Input.GetAxis("HorizontalLeft");

		if((leftStickHorizontalValue != 0) || (leftStickVerticalValue != 0)){
			leftStickAngle = Vector2.Angle(new Vector2(0, 1), new Vector2(leftStickHorizontalValue, leftStickVerticalValue));
			/*if(leftStickHorizontalValue < 0) {
				leftStickAngle = (360 - leftStickAngle);
			}*/
		}
	}

	void generateBlood(){
		//blood++;
		Debug.Log("More blood for the goat god.");
	}
	
	// Update is called once per frame
	void Update () {
		CalculateAngle ();
		if (currentAngleIndex == -1) {
			for (int i; i < mainAngles.Length; i++) {
				if (checkForBlood(i)) {
					break;
				}
			}
		} else {
			int previousAngle = currentAngleIndex--;
			if (previousAngle < 0) {
				previousAngle = mainAngles.Length - 1;
			}
			int nextAngle = currentAngleIndex++;
			if (nextAngle > mainAngles.Length - 1) {
				nextAngle = 0;
			}
		}
	}

	bool checkForBlood(int index){
		if (System.Math.Abs (leftStickAngle - mainAngles [i]) < angleAccuracy) {
			currentAngleIndex = i;
			generateBlood ();
			return true;
		}
		return false;
	}
}

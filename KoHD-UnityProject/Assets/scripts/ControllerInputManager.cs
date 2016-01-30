using UnityEngine;
using System;
using System.Collections;

public class ControllerInputManager : MonoBehaviour {

  private bool buttonDownA; //0
  public bool ButtonDownA { get { return buttonDownA; } }
  private bool buttonDownB; //1
  public bool ButtonDownB { get { return buttonDownB; } }
  private bool buttonDownX; //2
  public bool ButtonDownX { get { return buttonDownX; } }
  private bool buttonDownY; //3
  public bool ButtonDownY { get { return buttonDownY; } }
  private bool buttonDownLB; //4
  public bool ButtonDownLB { get { return buttonDownLB; } }
  private bool buttonDownLT;
  public bool ButtonDownLT { get { return buttonDownLT; } }
  private bool buttonDownRB; //5
  public bool ButtonDownRB { get { return buttonDownRB; } }
  private bool buttonDownRT;
  public bool ButtonDownRT { get { return buttonDownRT; } }
  private bool leftVerticalUp;
  public bool LeftVerticalUp { get { return leftVerticalUp; } }
  private bool rightVerticalUp;
  public bool RightVerticalUp { get { return rightVerticalUp; } }
  private bool leftVerticalDown;
  public bool LeftVerticalDown { get { return leftVerticalDown; } }
  private bool rightVerticalDown;
  public bool RightVerticalDown { get { return rightVerticalDown; } }
  private bool leftHorizontalLeft;
  public bool LeftHorizontalLeft { get { return leftHorizontalLeft; } }
  private bool leftHorizontalRight;
  public bool LeftHorizontalRight { get { return leftHorizontalRight; } }
  private bool rightHorizontalLeft;
  public bool RightHorizontalLeft { get { return rightHorizontalLeft; } }
  private bool rightHorizontalRight;
  public bool RightHorizontalRight { get { return rightHorizontalRight; } }
  private bool dPadUp;
  public bool DPadUp { get { return dPadUp; } }
  private bool dPadDown;
  public bool DPadDown { get { return dPadDown; } }
  private bool dPadLeft;
  public bool DPadLeft { get { return dPadLeft; } }
  private bool dPadRight;
  public bool DPadRight { get { return dPadRight; } }
  private bool leftStickClick;
  public bool LeftStickClick { get { return leftStickClick; } }
  private bool rightStickClick;
  public bool RightStickClick{ get { return rightStickClick; } }
  private float leftStickAngle;
  public float LeftStickAngle { get { return leftStickAngle; } }
  private float rightStickAngle;
  public float RightStickAngle { get { return rightStickAngle; } }
  private float valueButtonLT;
  public float ValueButtonLT { get { return valueButtonLT; } }
  private float valueButtonRT;
  public float ValueButtonRT { get { return valueButtonRT; } }
  private float leftStickVerticalValue;
  private float leftStickHorizontalValue;
  private float rightStickVerticalValue;
  private float rightStickHorizontalValue;
  private float dpadHorizontal;
  private float dpadVertical;

  public void Update() {
    if(Input.GetButtonDown("ButtonA") == true) {
      Debug.Log("ButtonA");
    } else if (Input.GetButtonDown("ButtonB") == true) {
      Debug.Log("ButtonB");
    } else if (Input.GetButtonDown("ButtonX") == true) {
      Debug.Log("ButtonX");
    } else if (Input.GetButtonDown("ButtonY") == true) {
      Debug.Log("ButtonY");
    }

    /*var LeftHorizontalValue = Input.GetAxis("HorizontalLeft");
    if((LeftHorizontalValue >= 0.25f) || (LeftHorizontalValue <= -0.25f)){
      Debug.Log("LeftHorizontalValue: " + LeftHorizontalValue);
    }
    var LeftVerticalValue = Input.GetAxis("VerticalLeft");
    if ((LeftVerticalValue >= 0.25f) || (LeftVerticalValue <= -0.25f)) {
      Debug.Log("LeftVerticalValue: " + LeftVerticalValue);
    }
    var RightHorizontalValue = Input.GetAxis("HorizontalRight");
    if ((RightHorizontalValue >= 0.25f) || (RightHorizontalValue <= -0.25f)) {
      Debug.Log("RightHorizontalValue: " + RightHorizontalValue);
    }
    var RightVerticalValue = Input.GetAxis("VerticalRight");
    if ((RightVerticalValue >= 0.25f) || (RightVerticalValue <= -0.25f)) {
      Debug.Log("RightVerticalValue: " + RightVerticalValue);
    }*/

    buttonDownA = Input.GetButtonDown("ButtonA");
    buttonDownB = Input.GetButtonDown("ButtonB");
    buttonDownX = Input.GetButtonDown("ButtonX");
    buttonDownY = Input.GetButtonDown("ButtonY");
    buttonDownLB = Input.GetButtonDown("ButtonLB");
    buttonDownRB = Input.GetButtonDown("ButtonRB");
    rightStickClick = Input.GetButtonDown("RightStickClick");
    leftStickClick = Input.GetButtonDown("LeftStickClick");

    valueButtonLT = Input.GetAxis("ButtonLT");
    valueButtonRT = Input.GetAxis("ButtonRT");
    leftStickVerticalValue = Input.GetAxis("VerticalLeft");
    leftStickHorizontalValue = Input.GetAxis("HorizontalLeft");
    rightStickVerticalValue = Input.GetAxis("VerticalRight");
    rightStickHorizontalValue = Input.GetAxis("HorizontalRight");
    dpadHorizontal = Input.GetAxis("HorizontalDPad");
    dpadVertical = Input.GetAxis("VerticalDPad");
    
	if((leftStickHorizontalValue != 0) || (leftStickVerticalValue != 0)){
	  leftStickAngle = Vector2.Angle(new Vector2(0, 1), new Vector2(leftStickHorizontalValue, leftStickVerticalValue));
	  if(leftStickHorizontalValue < 0) {
	    leftStickAngle = (360 - leftStickAngle);
	  }
	}
	
	if((rightStickHorizontalValue != 0) || (rightStickVerticalValue != 0)){
	  rightStickAngle = Vector2.Angle(new Vector2(0, 1), new Vector2(rightStickHorizontalValue, rightStickVerticalValue));
	  if(rightStickHorizontalValue < 0) {
	    rightStickAngle = (360 - rightStickAngle);
      }
	}

	
    

    if (valueButtonLT >= 0.5f) {
      buttonDownLT = true;
    } else {
      buttonDownLT = false;
    }
    if (valueButtonLT >= 0.5f) {
      buttonDownLT = true;
    } else {
      buttonDownLT = false;
    }

    //leftStickBools
    if(leftStickHorizontalValue >= 0.25f) {
      leftHorizontalLeft = true;
    } else if(leftStickHorizontalValue <= -0.25f) {
      leftHorizontalRight = true;
    } else {
      leftHorizontalRight = false;
      leftHorizontalLeft = false;
    }
    if (leftStickVerticalValue >= 0.25f) {
      leftVerticalUp = true;
    } else if (leftStickVerticalValue <= -0.25f) {
      leftVerticalDown = true;
    } else {
      leftVerticalDown = false;
      leftVerticalUp = false;
    }

    //rightStick bools
    if (rightStickHorizontalValue >= 0.25f) {
      rightHorizontalLeft = true;
    } else if (rightStickHorizontalValue <= -0.25f) {
      rightHorizontalRight = true;
    } else {
      rightHorizontalRight = false;
      rightHorizontalLeft = false;
    }
    if (rightStickVerticalValue >= 0.25f) {
      rightVerticalUp = true;
    } else if (rightStickVerticalValue <= -0.25f) {
      rightVerticalDown = true;
    } else {
      rightVerticalDown = false;
      rightVerticalUp = false;
    }
    //DPad bools
    if (dpadHorizontal >= 0.25f) {
      dPadRight = true;
    } else if (dpadHorizontal <= -0.25f) {
      dPadLeft = true;
    } else {
      dPadLeft = false;
      dPadRight = false;
    }
    if (dpadVertical >= 0.25f) {
      dPadUp = true;
    } else if (dpadVertical <= -0.25f) {
      dPadDown = true;
    } else {
      dPadDown = false;
      dPadUp = false;
    }

  }
}

using UnityEngine;
using System;
using System.Collections;

public class ControllerInputManager : MonoBehaviour {

  private bool buttonDownA; //a
  public String ButtonDownA { get { if (buttonDownA) return "a"; else return ""; } }
  private bool buttonDownB; //b
  public String ButtonDownB { get { if (buttonDownB) return "b"; else return ""; } }
  private bool buttonDownX; //c
  public String ButtonDownX { get { if (buttonDownX) return "c"; else return ""; } }
  private bool buttonDownY; //d
  public String ButtonDownY { get { if (buttonDownY) return "d"; else return ""; } }
  private bool buttonDownLB; //e
  public String ButtonDownLB { get { if (buttonDownLB) return "e"; else return ""; } }
  private bool buttonDownLT; //f
  public String ButtonDownLT { get { if (buttonDownLT) return "f"; else return ""; } }
  private bool buttonDownRB; //g
  public String ButtonDownRB { get { if (buttonDownRB) return "g"; else return ""; } }
  private bool buttonDownRT; //h
  public String ButtonDownRT { get { if (buttonDownRT) return "h"; else return ""; } }
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
  private bool dPadUp; //i
  public String DPadUp { get { if (dPadUp) return "i"; else return ""; } }
  private bool dPadDown; //j
  public String DPadDown { get { if (dPadDown) return "j"; else return ""; } }
  private bool dPadLeft; //k
  public String DPadLeft { get { if (dPadLeft) return "k"; else return ""; } }
  private bool dPadRight; //l
  public String DPadrigh { get { if (dPadRight) return "l"; else return ""; } }
  private bool leftStickClick; //m
  public String LeftStickClick { get { if (leftStickClick) return "m"; else return ""; } }
  private bool rightStickClick; //n
  public String RightStickClick { get { if (leftStickClick) return "n"; else return ""; } }
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

using UnityEngine;
using System;

public class InputThingy {
    private string code;
    private bool axis;
    private string keyCode;
    private bool invert;

	private bool axisDown;
	private bool axisPressed;

    public InputThingy(string code, string keyCode) {
      this.code = code;
      this.keyCode = keyCode;
      this.axis = false;
    }

    public InputThingy(string code, string axisCode, bool invert) {
      this.code = code;
      this.keyCode = axisCode;
      this.axis = true;
      this.invert = invert;
    }

	public void Update(){
		checkAxisDown ();
	}

    private float treshold = 0.5f;

	public bool isPressed(){
		return axisPressed;
	}

	private void checkAxisDown(){
		if (axis) {
			float value = Input.GetAxis(keyCode);
			if (invert && value > treshold) {
				if (axisDown) {
					axisPressed = false;
				} else {
					axisDown = true;
					axisPressed = true;
				}
			} else if (!invert && value < -treshold) {
				if (axisDown) {
					axisPressed = false;
				} else {
					axisDown = true;
					axisPressed = true;
				}
			} else {
				axisDown = false;
				axisPressed = false;
			}
		}
	}

    public bool isDown() {
      if (axis) {
		return axisPressed;
      } else {
        return Input.GetButtonDown(keyCode);
      }
    }

    public bool comparecode(string code) {
      return code.Equals(this.code);
    }

	public bool isAxis(){
		return axis;
	}
}

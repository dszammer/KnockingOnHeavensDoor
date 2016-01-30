using UnityEngine;
using System;

public class InputThingy {
    private string code;
    private bool axis;
    private string keyCode;
    private bool invert;

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

    private float treshold = 0.5f;

    public bool isDown() {
      if (axis) {
        float value = Input.GetAxis(keyCode);
        if (invert && value > treshold) {
          return true;
        } else if (!invert && value < -treshold) {
          return true;
        } else {
          return false;
        }
      } else {
        return Input.GetButtonDown(keyCode);
      }
    }

    public bool comparecode(string code) {
      return code.Equals(this.code);
    }
}

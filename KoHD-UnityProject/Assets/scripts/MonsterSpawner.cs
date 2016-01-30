using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class MonsterSpawner : MonoBehaviour {

  

    [SerializeField]
    private GameObject[] _monsterPrefabs;

    [SerializeField]
    private Text [] _keyTexts;
    [SerializeField]
    private Sprite[] _buttonSprites;

    [SerializeField]
    GameObject _startPoint;

    private string [][] _monsterKeys;
    private bool [][] _monsterKeysPressed;

  private Dictionary<string, InputThingy> controllerMapping;

    private int _textLength = 3;
        
    //private string[] combinations;
    //private bool[] _combinuse;
   // private int[] _comids;
   // private int _numberofkeycombinations = 19;

    // Use this for initialization
    void Start () {
    controllerMapping = new Dictionary<string, InputThingy>();
    controllerMapping.Add("a", new InputThingy("a","ButtonA"));
    controllerMapping.Add("b", new InputThingy("a", "ButtonB"));
    controllerMapping.Add("c", new InputThingy("a", "ButtonX"));
    controllerMapping.Add("d", new InputThingy("a", "ButtonY"));
    controllerMapping.Add("e", new InputThingy("a", "ButtonLB"));
    controllerMapping.Add("f", new InputThingy("a", "ButtonLT", true));
    controllerMapping.Add("g", new InputThingy("a", "ButtonRB"));
    controllerMapping.Add("h", new InputThingy("a", "ButtonRT", true));
    controllerMapping.Add("i", new InputThingy("a", "HorizontalDPad", true));
    controllerMapping.Add("j", new InputThingy("a", "HorizontalDPad", false));
    controllerMapping.Add("k", new InputThingy("a", "VerticalDPad", true));
    controllerMapping.Add("l", new InputThingy("a", "VerticalDPad", false));
    controllerMapping.Add("m", new InputThingy("a", "LeftStickClick"));
    controllerMapping.Add("n", new InputThingy("a", "RightStickClick"));
    //combinations = new string[] { "abc", "khr", "wpo", "tzc", "jsi", "rok", "qmc", "hop", "rvx", "bkg", "vrt", "hai", "ula", "get", "kab", "dav", "joe", "ste", "sil" };
    //_combinuse = new bool[_numberofkeycombinations];
    /*_comids = new int[4];

    for (int i = 0; i<_numberofkeycombinations; i++)
    {
        _combinuse[i] = false;
    }*/


    /*_monster0keys = new string[4];
    _monster1keys = new string[4];
    _monster2keys = new string[4];
    _monster3keys = new string[4];*/

    _monsterKeys = new string[4][];

        for (int i = 0; i < 4; i++)
        {
            _monsterKeys[i] = new string[3];
            SetKeys(i);
        }

        _monsterKeysPressed = new bool[4][];

        for (int i = 0; i < 4; i++)
        {
            _monsterKeysPressed[i] = new bool[3];
            
            for(int j = 0; j < 3; j++)
            {
                _monsterKeysPressed[i][j] = false;
            }
        }
    }

    // Update is called once per frame
    void Update() {

		foreach(InputThingy inth in controllerMapping.Values){
			inth.Update ();
		}
		
        for (int i = 0; i < 4; i++)
        {
            if (CheckControllerInput(_monsterKeys[i][0]) && !_monsterKeysPressed[i][0])
            {
                _monsterKeysPressed[i][0] = true;
                
                DeleteKey(i);
            }
            else if (_monsterKeysPressed[i][0] && !_monsterKeysPressed[i][1] && (CheckControllerInput(_monsterKeys[i][1])))
            {
                _monsterKeysPressed[i][1] = true;
               
                DeleteKey(i);
            }
            else if (_monsterKeysPressed[i][1] && !_monsterKeysPressed[i][2] && (CheckControllerInput(_monsterKeys[i][2])))
            {
                _monsterKeysPressed[i][2] = true;
                
                DeleteKey(i);
                Debug.Log("Monster " + i + " spawned");
                GameObject monster = Instantiate(_monsterPrefabs[i], _startPoint.transform.position, Quaternion.identity) as GameObject;
                for (int j = 0; j < 3; j++)
                {
                    _monsterKeysPressed[i][j] = false;
                }
                SetKeys(i);
                //success!
            }
			else if (Input.anyKeyDown || anyAxisDown())
            {
                //reset
                for (int j = 0; j < 3; j++)
                {
                    _monsterKeysPressed[i][j] = false;
                }

                SetKeys(i);
            }
        }        
    }

	private bool anyAxisDown(){
		foreach (InputThingy inth in controllerMapping.Values) {
			if (inth.isAxis ()) {
				if (inth.isPressed ()) {
					return true;
				}
			}
		}
		return false;
	}

  private bool CheckControllerInput(string monsterKeyCode) {
    if (Input.GetKeyDown(monsterKeyCode)) {
      return true;
    } else {
      foreach(string code in controllerMapping.Keys){
        if (code.Equals(monsterKeyCode)) {
          return controllerMapping[code].isDown();
        }
      }
    }
    return false;
  }

  void SpawnMonster(int id)
    {
        Debug.Log("SpawnMonster " + id);
    }

    void DeleteKey(int id)
    {
        string txt = _keyTexts[id].text;
        bool one = false;
        string newtext = "";

        for (int i = 0; i < _keyTexts[id].text.Length; i++)
        {
            if ((txt[i] != ' ' && !one))
            {
                newtext += ' ';
                one = true;
            } 
            else
            {
                newtext += txt[i];
            }
        }
        _keyTexts[id].text = newtext;
    }

    void SetText(string comb, int id)
    {
        _keyTexts[id].text = " ";

        for (int i = 0; i < _textLength; i++)
        {
            _keyTexts[id].text += comb[i] + " ";
        }
    }


    void SetKeys(int id)
    {
        string comb = GetRandomComb();

        SetText(comb, id);

        for (int i = 0; i < _textLength; i++)
        {
            _monsterKeys[id][i] = "" + comb[i];
            //_monsterKeysPressed[id][i] = false;
        }

    }
    

    string GetRandomComb()
    {
        string erg = "";
        char[] keysInUse = new char[_textLength];
        int i = 0;
        int rnd = 0;
        bool fail = false;

        while (i < 3)
        {
            rnd = (int)(UnityEngine.Random.value * 14) + 97;
            fail = false;
            for(int j = 0; j < _textLength; j++)
            {
                if((keysInUse[j] == System.Convert.ToChar(rnd)) || rnd < 97 || rnd > 110)
                {
                    fail = true;
                } 
            }
            if (!fail)
            {
                keysInUse[i] = System.Convert.ToChar(rnd);
                i++;
                erg += System.Convert.ToChar(rnd);
            }
        }
        return erg;
    }
}

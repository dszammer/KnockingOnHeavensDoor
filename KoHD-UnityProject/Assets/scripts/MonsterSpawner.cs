using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class MonsterSpawner : MonoBehaviour {

  ControllerInputManager controllerInputManager;

    [SerializeField]
    private ParticleSystem ps;

    [SerializeField]
    private GameObject[] _monsterPrefabs;

    [SerializeField]
    private Text [] _keyTexts;
    [SerializeField]
    private Sprite[] _buttonSprites;
  [SerializeField]
  private Image[] _sequenceButtonsNull;
  [SerializeField]
  private Image[] _sequenceButtonsOne;
  [SerializeField]
  private Image[] _sequenceButtonsTwo;
  [SerializeField]
  private Image[] _sequenceButtonsThree;

  private Image[][] _sequenceButtons;

  [SerializeField]
  private Image invisImage;

  [SerializeField]
  private Text counterText;

  public int spawnCounter;
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
    spawnCounter = 0;
    counterText.text = "Spawned Minions: 0";
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


    ControllerInputManager controllerInputManager = new ControllerInputManager();


    /*_monster0keys = new string[4];
    _monster1keys = new string[4];
    _monster2keys = new string[4];
    _monster3keys = new string[4];*/
    _sequenceButtons = new Image[4][];
    _sequenceButtons[0] = _sequenceButtonsNull;
    _sequenceButtons[1] = _sequenceButtonsOne;
    _sequenceButtons[2] = _sequenceButtonsTwo;
    _sequenceButtons[3] = _sequenceButtonsThree;

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

//    if(controllerInputManager.)

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
                ps.Stop();
                ps.Play();
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
    GameObject monster = Instantiate(_monsterPrefabs[id], _startPoint.transform.position, Quaternion.identity) as GameObject;
    ++spawnCounter;
    counterText.text = "Spawned minions: " + spawnCounter.ToString();
    Debug.Log("SpawnMonster " + id);
    }

    void DeleteKey(int id)
    {
        string txt = _keyTexts[id].text;
        bool one = false;
    int j = 0;
        string newtext = "";
        for (int i = 0; i < _keyTexts[id].text.Length; i++)
        {
            if ((txt[i] != ' ' && !one))
            {
        if (i == 1) {
          j = 0;
        } else if (i == 3) {
          j = 1;
        } else if (i == 5) {
          j = 2;
        }
        _sequenceButtons[id][j].enabled = false;
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
      _sequenceButtons[id][i].enabled = true;
            _sequenceButtons[id][i].sprite = (Sprite)_buttonSprites.GetValue((int)comb[i] - 97 );
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

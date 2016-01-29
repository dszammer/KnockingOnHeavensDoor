using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] _monsterPrefabs;

    [SerializeField]
    private Text [] _keyTexts;

    private string[] _monster0keys;
    private string[] _monster1keys;
    private string[] _monster2keys;
    private string[] _monster3keys;


    //private string[] combinations;
    //private bool[] _combinuse;
   // private int[] _comids;
   // private int _numberofkeycombinations = 19;

    // Use this for initialization
    void Start () {

        //combinations = new string[] { "abc", "khr", "wpo", "tzc", "jsi", "rok", "qmc", "hop", "rvx", "bkg", "vrt", "hai", "ula", "get", "kab", "dav", "joe", "ste", "sil" };
        //_combinuse = new bool[_numberofkeycombinations];
        /*_comids = new int[4];

        for (int i = 0; i<_numberofkeycombinations; i++)
        {
            _combinuse[i] = false;
        }*/



        _monster0keys = new string[4];
        _monster1keys = new string[4];
        _monster2keys = new string[4];
        _monster3keys = new string[4];

        SetKeys(0);
        SetKeys(1);
        SetKeys(2);
        SetKeys(3);
    }

    // Update is called once per frame
    void Update() {
       

        if (Input.GetKey(_monster0keys[0]) && Input.GetKey(_monster0keys[1]) && Input.GetKey(_monster0keys[2]))
        {
            SpawnMonster(0);
            SetKeys(0);
        }
        if (Input.GetKey(_monster1keys[0]) && Input.GetKey(_monster1keys[1]) && Input.GetKey(_monster1keys[2]))
        {
            SpawnMonster(1);
            SetKeys(1);
        }
        if (Input.GetKey(_monster2keys[0]) && Input.GetKey(_monster2keys[1]) && Input.GetKey(_monster2keys[2]))
        {
            SpawnMonster(2);
            SetKeys(2);
        }
        if (Input.GetKey(_monster3keys[0]) && Input.GetKey(_monster3keys[1]) && Input.GetKey(_monster3keys[2]))
        {
            SpawnMonster(3);
            SetKeys(3);
        }
    }

    void SpawnMonster(int id)
    {
        Debug.Log("SpawnMonster " + id);
    }

    void SetKeys(int id)
    {
        

        string comb = GetRandomComb();
        _keyTexts[id].text = " ";

        for (int i = 0; i < 3; i++)
        {
            _keyTexts[id].text += comb[i] + " ";
        }

        switch (id)
        {
            case 0:
                for (int i = 0; i < 3; i++)
                {
                    _monster0keys[i] = "" + comb[i];
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    _monster1keys[i] = "" + comb[i];
                }
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    _monster2keys[i] = "" + comb[i];
                }
                break;
            case 3:
                for (int i = 0; i < 3; i++)
                {
                    _monster3keys[i] = "" + comb[i];
                }
                break;
        }
    }

    string GetRandomComb()
    {
        string erg = "";
        char[] keysInUse = new char[3];
        int i = 0;
        int rnd = 0;
        bool fail = false;

        while (i < 3)
        {
            rnd = (int)(Random.value * 26) + 97;
            fail = false;
            for(int j = 0; j < 3; j++)
            {
                if((keysInUse[j] == System.Convert.ToChar(rnd)) || rnd < 97 || rnd > 122)
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

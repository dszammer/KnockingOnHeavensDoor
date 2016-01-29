using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] _monsterPrefabs;

    private string[] _monster0keys;
    private string[] _monster1keys;
    private string[] _monster2keys;
    private string[] _monster3keys;


    private string[] combinations;

    // Use this for initialization
    void Start () {

        combinations = new string[] { "abcd", "khro", "wpob", "tzcd", "jsip", "ropkn", "qmcu", "hopl", "rvxt", "bkgr", "vrtr", "haid", "ulaf", "gert", "kabo" };

        _monster0keys = new string[5];
        _monster1keys = new string[5];
        _monster2keys = new string[5];
        _monster3keys = new string[5];

        SetKeys(0);
        SetKeys(1);
        SetKeys(2);
        SetKeys(3);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(_monster1keys[0]))
        {
            Debug.Log(_monster0keys[0] + _monster0keys[1] + _monster0keys[2] + _monster0keys[3]);
        }
        if (Input.GetKey(_monster1keys[0]) && Input.GetKey(_monster1keys[1]) && Input.GetKey(_monster1keys[2]) && Input.GetKey(_monster1keys[3]))
        {
            Debug.Log("fuuuuuu");
        }
        if (Input.GetKey(_monster2keys[0]) && Input.GetKey(_monster2keys[1]) && Input.GetKey(_monster2keys[2]) && Input.GetKey(_monster2keys[3]))
        {
        }
        if (Input.GetKey(_monster3keys[0]) && Input.GetKey(_monster3keys[1]) && Input.GetKey(_monster3keys[2]) && Input.GetKey(_monster3keys[3]))
        {
        }
    }

    void SpawnMonster(int id)
    {

    }

    void SetKeys(int id)
    {
        int comid = (int) Random.value * 15;
        Debug.Log(comid);
        switch (id)
        {
            case 0:
                for (int i = 0; i < 4; i++)
                {
                    _monster0keys[i] = "" + combinations[comid][i];
                }
                break;
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    _monster1keys[i] = "" + combinations[comid][i];
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    _monster2keys[i] = "" + combinations[comid][i];
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    _monster3keys[i] = "" + combinations[comid][i];
                }
                break;
        }
    }
}

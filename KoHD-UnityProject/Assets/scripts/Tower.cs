using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    [SerializeField]
    private int _damage = 1;

    [SerializeField]
    private float _firedelay = 1.0f;

    GameObject[] _targets;
    int _numberOfTargetsAquired = 5;

	// Use this for initialization
	void Start () {
        _targets = new GameObject[_numberOfTargetsAquired];
        StartCoroutine("DealDamage");
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
       for (int i = 0; i < _numberOfTargetsAquired; i++)
        {
            if (_targets[i] == null)
            {
                _targets[i] = other.gameObject;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        for(int i = 0; i < _numberOfTargetsAquired; i++)
        {
            if (_targets[i].gameObject.GetInstanceID() == other.gameObject.GetInstanceID())
            {
                RemoveTarget(i);
            }
        }
    }

    void RemoveTarget(int id)
    {
        for (int i = id; i < _numberOfTargetsAquired - 1; i++)
        {
            _targets[i] = _targets[i + 1];
        }

        _targets[_numberOfTargetsAquired - 1] = null;
    }

    IEnumerator DealDamage()
    {
        while (true)
        {
            if (_targets[0] != null)
            {
                if (!_targets[0].GetComponent<Monster>().DealDamage(_damage))
                {
                    RemoveTarget(0);
                }
            }
            yield return new WaitForSeconds(_firedelay);
        }
    }

}

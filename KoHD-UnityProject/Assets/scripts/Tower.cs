using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    [SerializeField]
    private int _damage = 1;

    [SerializeField]
    private float _firedelay = 1.0f;

    [SerializeField]
    private ParticleSystem ps;

    GameObject[] _targets;
    int _numberOfTargetsAquired = 5;



	// Use this for initialization
	void Start () {
        _targets = new GameObject[_numberOfTargetsAquired];

        for (int i = 0; i < _numberOfTargetsAquired; i++)
        {
            _targets[i] = null;
        }

        StartCoroutine("DealDamage");
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
       for (int i = 0; i < _numberOfTargetsAquired; i++)
        {
            if (_targets[i] != null)
            {
                if (_targets[i].GetInstanceID() == other.gameObject.GetInstanceID())
                {
                    break;
                }
            }

            if (_targets[i] == null)
            {
                Debug.Log("target " + i + " aqired");
                
                _targets[i] = other.gameObject;
                break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject != null)
        {
            for (int i = 0; i < _numberOfTargetsAquired; i++)
            {
                if (_targets[i] != null)
                {
                    Debug.Log("compare " + _targets[i].gameObject.GetInstanceID() + " == " + other.gameObject.GetInstanceID());
                    if (_targets[i].gameObject.GetInstanceID() == other.gameObject.GetInstanceID())
                    {
                        Debug.Log("target " + i + " removed");
                        RemoveTarget(i);
                    }
                }
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
                ps.Play();
                if (!_targets[0].GetComponent<Monster>().DealDamage(_damage))
                {
                    RemoveTarget(0);
                }
            }
            yield return new WaitForSeconds(_firedelay);
        }
    }

}

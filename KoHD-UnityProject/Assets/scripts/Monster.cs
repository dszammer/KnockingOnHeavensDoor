using UnityEngine;
using System.Collections;
using System;

public class Monster : MonoBehaviour {

    [SerializeField]
    private int health = 1000;
    [SerializeField]
    private float speed = 0.5f;

    private Transform nextWaypoint;
    private GameObject[] WaypointsArray;
    private Animator anim;
    private bool moving = true;
    private bool flipcd;
    // Use this for initialization
    void Start () {

        WaypointsArray = WaypointManager.Instance.GetWaypoints();

        nextWaypoint = WaypointsArray[0].transform;

        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(KillOnAnimationEnd());
        MoveToNextWaypoint();
	}

    private void MoveToNextWaypoint()
    {
        Vector3 actualPos = gameObject.transform.position;
        Vector3 destinationPos = nextWaypoint.position;

        if (moving)
        {
            actualPos += (destinationPos - actualPos).normalized * speed * Time.deltaTime;

            gameObject.transform.position = actualPos;
        }
    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(1.25f);
        
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(nextWaypoint.gameObject))
        {
 
            SetNextWaypoint();
          
        }
    }

    void SetNextWaypoint()
    {
        if (nextWaypoint.GetSiblingIndex() >= WaypointsArray.Length - 1)
        {
            nextWaypoint = WaypointsArray[0].transform;
        }
        else
        {
            nextWaypoint = WaypointsArray[nextWaypoint.GetSiblingIndex() + 1].transform;
        }
    }

    public bool DealDamage(int damage)
    {
        anim.SetTrigger("MonsterHit");
        health -= damage;
        if(health <= 0)
        {
            moving = false;

            Debug.Log(anim.GetCurrentAnimatorClipInfo(0).Length);

            StartCoroutine(KillOnAnimationEnd());
            anim.SetBool("MonsterDeath", true);
            return false;
        }
        return true;
    }

    public void Flipme()
    {   
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    

}

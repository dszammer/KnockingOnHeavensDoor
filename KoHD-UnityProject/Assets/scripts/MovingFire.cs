using UnityEngine;
using System.Collections;

public class MovingFire : MonoBehaviour
{

    // Use this for initialization

    private GameObject[] WaypointsArray = new GameObject[5];

    private int speed = 10;
    private Vector3 nextPoint;
    private int index = 0;

    private Transform nextWaypoint;

    [SerializeField]
    private GameObject _firePrefab;

    [SerializeField]
    GameObject _startPoint;

    private bool moving = true;
    private bool loop = false;

    void Start()
    {
        index++;
        WaypointsArray[0] = GameObject.Find("Waypoint");
        WaypointsArray[1] = GameObject.Find("Waypoint (1)");
        WaypointsArray[2] = GameObject.Find("Waypoint (2)");
        WaypointsArray[3] = GameObject.Find("Waypoint (3)");
        WaypointsArray[4] = GameObject.Find("Waypoint (4)");

        nextWaypoint = WaypointsArray[1].transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 actualPos = gameObject.transform.position;
            Vector3 destinationPos = nextWaypoint.position;

            actualPos += (destinationPos - actualPos).normalized * speed * Time.deltaTime;

            gameObject.transform.position = actualPos;

            GameObject fire = Instantiate(_firePrefab, actualPos, Quaternion.identity) as GameObject;
          
        }


    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Coll");
        if(other.gameObject.Equals(GameObject.Find("Waypoint")) && loop)
        {
            moving = false;
            StartCoroutine(KillOnAnimationEnd());
        }
        if (other.gameObject.Equals(nextWaypoint.gameObject))
        {
            loop = true;
            SetNextWaypoint();

        }
    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
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



}

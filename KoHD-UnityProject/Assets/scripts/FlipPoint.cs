using UnityEngine;
using System.Collections;

public class FlipPoint : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Monster>().Flipme();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporter : MonoBehaviour
{
    [SerializeField] GameObject otherEnd;
    [SerializeField] GameObject otherEndPoint;
    [SerializeField] GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

           player.transform.position = new Vector3(otherEndPoint.transform.position.x, otherEndPoint.transform.position.y, otherEndPoint.transform.position.z);
        }

    }
}

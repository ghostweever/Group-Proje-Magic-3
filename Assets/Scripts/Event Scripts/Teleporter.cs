using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleporter : MonoBehaviour
{
    [SerializeField] GameObject otherEnd;
    [SerializeField] GameObject otherEndPoint;
    [SerializeField] GameObject player;
    public AudioClip teleport;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(teleport, otherEnd.transform.GetChild(0).transform.position, 1f);
           player.transform.position = new Vector3(otherEndPoint.transform.position.x, otherEndPoint.transform.position.y, otherEndPoint.transform.position.z);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    private void Update()
    {


        Destroy(gameObject, 1);


    }


    public void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);


        }



    }



}

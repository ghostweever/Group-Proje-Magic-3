using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public float speed;
    public Rigidbody Fireball;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(1))
        {

            var clone = Instantiate(Fireball, transform.position, transform.rotation);

            clone.velocity = Vector3.forward * speed;



        }
    }



}

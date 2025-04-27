using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LavaLevelEvent : MonoBehaviour
{

    public Rigidbody fireBall;
    private float speed;
    private bool canSpawnFireBall;
    public AudioClip eruption;
    
    void Start()
    {
        //Spawns fireball at a random time with a random speed
        speed = Random.Range(20, 40);
        InvokeRepeating("FireBalls", 5, Random.Range(5.0f, 20f));
        
    }

  
    public void FireBalls()
        //Sends fireballs down from eruption point
    {
        var clone = Instantiate(fireBall, this.transform.position, this.transform.rotation);

        clone.velocity = -this.transform.up * speed;

        AudioSource.PlayClipAtPoint(eruption, transform.position, 1);

    }

}

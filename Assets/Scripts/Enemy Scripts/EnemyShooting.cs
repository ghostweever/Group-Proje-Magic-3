using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float speed;
    public Rigidbody enemyProjectile;
    Rigidbody rb;

    [Header("Transforms")]
    public Transform player;
    public Transform shootArea;

    private Vector3 direction;

    public float rotateSpeed = 100f;


    void Start()
    {
        speed = 55;

        rb = enemyProjectile.GetComponent<Rigidbody>();
       
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    public void EnemyShoot()
    {
        var clone = Instantiate(enemyProjectile, shootArea.position, transform.rotation);


        direction = (player.position - shootArea.position).normalized;
       
        Vector3 rotateAmount = Vector3.Cross(direction, transform.position);

        clone.angularVelocity = rotateAmount * rotateSpeed;

        clone.velocity = direction * speed;

        Destroy(clone, 200f);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public float speed;
    public Rigidbody Fireball;
    public Rigidbody FireballAmplifier;
    public GameObject player;
    Vector3 mouseWorldPosition;
    private PlayerInputHandler inputHandler;



    // Start is called before the first frame update
    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }

    // Update is called once per frame
    void Update()
    {


       
    }

    public void FireSpell()
    {
        speed = 25f;

    Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 1;

        Vector3 mouseScreenPosition = Input.mousePosition;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

        if (Physics.Raycast(ray, out hit)) {

            var clone = Instantiate(Fireball, spawnPos, Quaternion.identity);
           mouseScreenPosition = hit.point;

            clone.velocity = Vector3.forward * speed;

            Destroy(clone, 2f);
        }

    }

    public void FireComboSpell()
    {
        speed = 35f;

        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 1;

        Vector3 mouseScreenPosition = Input.mousePosition;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(mouseScreenPosition);

        if (Physics.Raycast(ray, out hit))
        {

            var clone = Instantiate(FireballAmplifier, spawnPos, Quaternion.identity);
            mouseScreenPosition = hit.point;

            clone.velocity = Vector3.forward * speed;

            Destroy(clone, 2f);
        }

    }
}

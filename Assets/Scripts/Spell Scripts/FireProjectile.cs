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

    public AudioClip fireSpell;

    // Start is called before the first frame update
    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }
    //Primary spell
    public void FireSpell()
    {
        speed = 25f;

        Vector3 playerPos =  new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 1;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        AudioSource.PlayClipAtPoint(fireSpell, transform.position, 2f);

        var clone = Instantiate(Fireball, spawnPos, Quaternion.identity);

        clone.velocity = this.transform.forward * speed;

        Destroy(clone, 5f);

    }
    //Powered up secondary spell
    public void FireComboSpell()
    {
        speed = 35f;

        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float spawnDistance = 1;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        var clone = Instantiate(FireballAmplifier, spawnPos, Quaternion.identity);

        AudioSource.PlayClipAtPoint(fireSpell, transform.position, 2f);

        clone.velocity = this.transform.forward * speed;

        Destroy(clone, 2f);
        
    }
}

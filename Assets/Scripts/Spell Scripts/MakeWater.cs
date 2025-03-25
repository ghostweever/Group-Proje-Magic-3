using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWater : MonoBehaviour
{
    [SerializeField] private GameObject water;
    Rigidbody rb;
    public GameObject user;
    private bool canCastWater = true;

    float magnitude = 20;

    void Start()
    {
        rb = water.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WaterSpell()
    {
        //gets player position and rotation so it is shot in front
        Vector3 playerPos = user.transform.position;
        Vector3 playerDirection = user.transform.forward;
        Quaternion playerRotation = user.transform.rotation;
        float spawnDistance = 1;

        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;

        if (canCastWater == true)
        {

            GameObject currentWater = Instantiate(water, spawnPos, playerRotation);
            currentWater.GetComponent<Rigidbody>().AddForce(Vector3.forward * magnitude, ForceMode.Impulse);

            water.transform.Translate(new Vector3(0, 2, 0) * Time.deltaTime * 2f);

            canCastWater = false;

            Destroy(currentWater, .5f);

            StartCoroutine(WaterWallCooldown());
        }
    }

    private IEnumerator WaterWallCooldown()
    {
        yield return new WaitForSeconds(5f);
        canCastWater = true;
    }
}

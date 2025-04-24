using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeWater : MonoBehaviour
{
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject waterAmplifier;
    Rigidbody rb;
    public GameObject user;
   
    public AudioClip waterSound;

    float magnitude = 20;

    void Start()
    {
        rb = water.GetComponent<Rigidbody>();
    }

    public void WaterSpell()
    {

        Quaternion playerRotation = user.transform.rotation;

        Vector3 spawnPos = new(user.transform.position.x+ 2, user.transform.position.y, user.transform.position.z + 2.5f);

            AudioSource.PlayClipAtPoint(waterSound, transform.position, 2f);

            GameObject currentWater = Instantiate(water, spawnPos, playerRotation);

            //Sends out the water prefab with force applied
            currentWater.GetComponent<Rigidbody>().AddForce(this.transform.forward * magnitude, ForceMode.Impulse);

            water.transform.Translate(new Vector3(0, 2, 0) * Time.deltaTime * 2f);

       

            Destroy(currentWater, .5f);

        
    }

    //Powered up secondary spell
    public void WaterComboSpell()
    {
        Quaternion playerRotation = user.transform.rotation;

        Vector3 spawnPos = new (user.transform.position.x, user.transform.position.y + 2, user.transform.position.z + 1.5f);

      
            AudioSource.PlayClipAtPoint(waterSound, transform.position, 2f);

            GameObject currentWater = Instantiate(waterAmplifier, spawnPos, playerRotation);

            //Sends out the water prefab with force applied
            currentWater.GetComponent<Rigidbody>().AddForce(this.transform.forward * magnitude, ForceMode.Impulse);

            water.transform.Translate(new Vector3(0, 2, 0) * Time.deltaTime * 2f);

         

            Destroy(currentWater, .5f);

        
    }

}

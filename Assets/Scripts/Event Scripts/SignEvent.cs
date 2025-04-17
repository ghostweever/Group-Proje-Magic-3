using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignEvent : MonoBehaviour
{
    Quaternion startRotation;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.rotation;
        time = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            transform.rotation = Quaternion.Slerp(startRotation, Quaternion.Euler(0, 0, -90), time);
            time += Time.deltaTime;
            StartCoroutine(SignReset());
        }
    }

    private IEnumerator SignReset()
    {
        yield return new WaitForSeconds(5f);
        transform.rotation = startRotation;
    }

}

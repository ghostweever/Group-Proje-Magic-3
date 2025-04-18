using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    private BackToHub backToHub;



    void Start()
    {
        backToHub = GetComponent<BackToHub>();
    }

    // Update is called once per frame
    void Update()
    {
        EditCamera();
}

    public void EditCamera()
    {
        if (GameObject.Find("PortalManager").transform.GetChild(1).GetComponent<BackToHub>().canBeatLevel == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(ResetCamera());
        } 
        
    }


    private IEnumerator ResetCamera()
    {
        yield return new WaitForSeconds(6);
        GameObject.Find("PortalManager").transform.GetChild(1).GetComponent<BackToHub>().canBeatLevel = false;
    }

    }

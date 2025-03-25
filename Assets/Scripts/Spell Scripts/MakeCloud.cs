using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCloud : MonoBehaviour
{

    public GameObject cloud;
    private int cloudAmount = 2;
    private bool canMakeCloud = true;
    
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CloudSpell()
    {
        if (cloudAmount <= 0 || cloudAmount > 2 )
        {
            canMakeCloud = false;
        }
        else
        {
            canMakeCloud = true;
        }

        

        if (canMakeCloud == true)
        {
            

           var cloudCopy = Instantiate(cloud, transform.position, transform.rotation);
            
            cloudAmount--;

            Destroy(cloudCopy, 3f);

            StartCoroutine(RegainCloud());

            Debug.Log(cloudAmount);
        }
    }

    private IEnumerator RegainCloud()
    {
        yield return new WaitForSeconds(5f);
        cloudAmount++;
    }

}

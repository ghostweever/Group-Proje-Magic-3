using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCloud : MonoBehaviour
{

    public GameObject cloud;
    public GameObject player;
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
            
            //Spawns cloud slightly below player so they dont get caught in it
           var cloudCopy = Instantiate(cloud, new Vector3(player.transform.position.x, player.transform.position.y - .5f, player.transform.position.z), transform.rotation);
            
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

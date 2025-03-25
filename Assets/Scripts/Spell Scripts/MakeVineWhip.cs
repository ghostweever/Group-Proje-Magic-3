using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVineWhip : MonoBehaviour
{
    public GameObject vine;
    public GameObject player;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VineSpell()
    {
        player.transform.GetChild(0).gameObject.SetActive(true);
        StartCoroutine(DestroyVine());
    }


    private IEnumerator DestroyVine()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    


}

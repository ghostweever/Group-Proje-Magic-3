using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeVineWhip : MonoBehaviour
{
    public GameObject vine;
    public GameObject vineAmplifier;
    public GameObject player;

    public AudioClip vineSpell;


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
        AudioSource.PlayClipAtPoint(vineSpell, transform.position, 5f);
        StartCoroutine(DestroyVine());
    }

    public void VineComboSpell()
    {
        player.transform.GetChild(1).gameObject.SetActive(true);
        AudioSource.PlayClipAtPoint(vineSpell, transform.position, 5f);
        StartCoroutine(DestroyComboVine());
    }

    private IEnumerator DestroyVine()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    private IEnumerator DestroyComboVine()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

}

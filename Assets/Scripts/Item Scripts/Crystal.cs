using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public GameObject crystalHolder;
    public GameObject crystalIcon;
    private PlayerCrystalManager playerCrystalManager;
    public int whatCrystalAmI;

    public AudioClip crystalClip;

    private bool canCollect;

    void Start()
    {
        playerCrystalManager = GetComponent<PlayerCrystalManager>();
    }

    public void ActivateCrystal()
    {
        canCollect = true;
        crystalHolder.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void DeactivateCrystal() {
        crystalHolder.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void ActivateCrystalIcon()
    {
    crystalIcon.transform.GetChild(1).gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && whatCrystalAmI == 0 && canCollect)
        {
            AudioSource.PlayClipAtPoint(crystalClip, transform.position, 2f);
            DeactivateCrystal();
            ActivateCrystalIcon();
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
        } else if (collision.tag == "Player" && whatCrystalAmI == 1)
        {
            DeactivateCrystal();
            ActivateCrystalIcon();

            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
        }
        else if (collision.tag == "Player" && whatCrystalAmI == 2)
        {
            DeactivateCrystal();
            ActivateCrystalIcon();
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
        }
    }
}

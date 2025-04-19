using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public GameObject crystalHolder;
    public GameObject crystalIcon;
    private PlayerCrystalManager playerCrystalManager;
    public int whatCrystalAmI;

    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void Generateguid()
    {
        id = System.Guid.NewGuid().ToString();
    }


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
        Destroy(crystalHolder);
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
            GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
            canCollect = false;
        } else if (collision.tag == "Player" && whatCrystalAmI == 1 && canCollect)
        {
            AudioSource.PlayClipAtPoint(crystalClip, transform.position, 2f);
            DeactivateCrystal();
            ActivateCrystalIcon();
            canCollect = false;
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
        }
        else if (collision.tag == "Player" && whatCrystalAmI == 2 && canCollect)
        {
            AudioSource.PlayClipAtPoint(crystalClip, transform.position, 2f);
            DeactivateCrystal();
            ActivateCrystalIcon();
            canCollect = false;
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
        }
    }

}

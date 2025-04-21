using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public GameObject crystalHolder;
    public GameObject crystalIcon;
    private PlayerCrystalManager playerCrystalManager;
    public int whatCrystalAmI;
    public CrystalType crystal;


    public enum CrystalType
    {
        CrystalGrass_One,
        CrystalGrass_Two,
        CrystalGrass_Three,
        CrystalWater_One,
        CrystalWater_Two,
        CrystalWater_Three,
        CrystalLava_One,
        CrystalLava_Two,
        CrystalLava_Three,
    }


    public AudioClip crystalClip;

    public bool canCollect;

    void Start()
    {
        playerCrystalManager = GetComponent<PlayerCrystalManager>();
    }

    private void Update()
    {
        DoIHaveCrystal();
    }

    public void DoIHaveCrystal()
    {
        switch (crystal) {

        case CrystalType.CrystalGrass_One:
        if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal1_1"] == true)
        {
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            DeactivateCrystal();
            ActivateCrystalIcon();
          }
        break;

        case CrystalType.CrystalGrass_Two:
        if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal1_2"] == true)
        {
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            DeactivateCrystal();
            ActivateCrystalIcon();
          }
        break;
        
        case CrystalType.CrystalGrass_Three:
        if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal1_3"] == true)
        {
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            DeactivateCrystal();
            ActivateCrystalIcon();
         }
        break;

        case CrystalType.CrystalWater_One:
        if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal2_1"] == true)
        {
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            DeactivateCrystal();
            ActivateCrystalIcon();
          }
        break;

        case CrystalType.CrystalWater_Two:
        if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal2_2"] == true)
        {
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            DeactivateCrystal();
            ActivateCrystalIcon();
          }
        break;
        
        case CrystalType.CrystalWater_Three:
        if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal2_3"] == true)
        {
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            DeactivateCrystal();
            ActivateCrystalIcon();
         }
        break;

        case CrystalType.CrystalLava_One:
        if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal3_1"] == true)
        {
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            DeactivateCrystal();
            ActivateCrystalIcon();
          }
        break;

        case CrystalType.CrystalLava_Two:
        if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal3_2"] == true)
        {
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            DeactivateCrystal();
            ActivateCrystalIcon();
          }
        break;
        
        case CrystalType.CrystalLava_Three:
        if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal3_3"] == true)
        {
            GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
            DeactivateCrystal();
            ActivateCrystalIcon();
         }
        break;
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag  == "Player" && canCollect)
        {
            AudioSource.PlayClipAtPoint(crystalClip, transform.position, 2f);

            switch (crystal)
            {
                case CrystalType.CrystalGrass_One:
                    DeactivateCrystal();
                    ActivateCrystalIcon();
                    GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
                    GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal1_1"] = true;
                    GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
                    canCollect = false;
                    
                 break;

                case CrystalType.CrystalGrass_Two:
                    DeactivateCrystal();
                    ActivateCrystalIcon();
                    GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
                    GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal1_2"] = true;
                    GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
                    canCollect = false;
                    break;

                case CrystalType.CrystalGrass_Three:
                    DeactivateCrystal();
                    ActivateCrystalIcon();
                    GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
                    GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal1_3"] = true;
                    GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
                    canCollect = false;
                    break;

                case CrystalType.CrystalWater_One:
                    DeactivateCrystal();
                    ActivateCrystalIcon();
                    GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
                    GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal2_1"] = true;
                    GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
                    canCollect = false;
                    break;

                case CrystalType.CrystalWater_Two:
                    DeactivateCrystal();
                    ActivateCrystalIcon();
                    GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
                    GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal2_2"] = true;
                    GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
                    canCollect = false;
                    break;

                case CrystalType.CrystalWater_Three:
                    DeactivateCrystal();
                    ActivateCrystalIcon();
                    GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
                    GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal2_3"] = true;
                    GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
                    canCollect = false;
                    break;

                case CrystalType.CrystalLava_One:
                    DeactivateCrystal();
                    ActivateCrystalIcon();
                    GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
                    GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal3_1"] = true;
                    GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
                    canCollect = false;
                    break;

                case CrystalType.CrystalLava_Two:
                    DeactivateCrystal();
                    ActivateCrystalIcon();
                    GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
                    GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal3_2"] = true;
                    GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
                    canCollect = false;
                    break;

                case CrystalType.CrystalLava_Three:
                    DeactivateCrystal();
                    ActivateCrystalIcon();
                    GameObject.Find("Player").GetComponent<PlayerCrystalManager>().EarnCrystal(1);
                    GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().crystalDict["Crystal3_3"] = true;
                    GameObject.Find("Player").GetComponent<PlayerLives>().playerLives = 3;
                    canCollect = false;
                    break;
            }

               

        }
    }

}

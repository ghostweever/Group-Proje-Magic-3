using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    private PlayerCrystalManager playerCrystalManager;
    public GameObject portal;


    public int portalType;

    void Start()
    {
        playerCrystalManager = GetComponent<PlayerCrystalManager>();
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    void Update()
    {
        WhatPortalAmI();
    }

    public void WhatPortalAmI()
    {
        if (portalType == 0)
        {
            if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().grassCompleted == true)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else if (portalType == 1)
        {
            if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().waterCompleted == true)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else if (portalType == 2)
        {
            if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().lavaCompleted == true)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        else if (portalType == 3)
        {
            if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().gameCompleted == true)
            {
                portal.gameObject.SetActive(true);
            }
        }
        if (portalType == 4)
        {
            if (GameObject.Find("Player").GetComponent<PlayerCrystalManager>().playerCrystalCount == 3)
            {
                portal.SetActive(true);
            }
        }
        if (portalType == 5)
        {
            portal.SetActive(true);
        }
    }

    }



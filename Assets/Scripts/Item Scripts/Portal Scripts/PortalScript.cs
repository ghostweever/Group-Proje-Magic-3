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
    }

    // Update is called once per frame
    void Update()
    {
        WhatPortalAmI(); 

    }

    public void WhatPortalAmI()
    {
        if (portalType == 0)
        {

        }
        else if (portalType == 1)
        {

        }
        else if (portalType == 2)
        {

        }
        else if (portalType == 3)
        {
            ActivatePortal();
        }
        else if (portalType == 4)
        {
            ActivatePortal();
        }
    }

    void ActivatePortal()
    //If win condition is true the portal activates
    {
        if (GameObject.Find("Player").GetComponent<PlayerCrystalManager>().playerCrystalCount == 3)
        {

            portal.gameObject.SetActive(true);
        }
        else
        {
            portal.gameObject.SetActive(false);
        }

    }
    }



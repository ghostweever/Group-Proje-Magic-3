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

        }
        else if (portalType == 4)
        {

        }
    }

    }



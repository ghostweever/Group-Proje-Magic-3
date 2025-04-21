using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    private PlayerCrystalManager playerCrystalManager;
    public GameObject portal;
    public PortalType portalTypes;

    void Start()
    {
        playerCrystalManager = GetComponent<PlayerCrystalManager>();
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    void Update()
    {
        PortalEvents();
    }

    public enum PortalType
    {
        Grass,
        Water,
        Lava,
        Hub,
        Oasis,
        Win
    }

    private void PortalEvents()
    {
        switch (portalTypes)
        {
            case PortalType.Grass:
                if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().grassCompleted == true)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                }
             break;

            case PortalType.Water:
                if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().waterCompleted == true)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                }
             break;

            case PortalType.Lava:
                if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().lavaCompleted == true)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                }
            break;

            case PortalType.Hub:
                if (GameObject.Find("Player").GetComponent<PlayerCrystalManager>().playerCrystalCount == 3)
                {
                    portal.SetActive(true);
                }
            break;

            case PortalType.Win:
                if (GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().gameCompleted == true)
                {
                    portal.gameObject.SetActive(true);
                }
            break;

            case PortalType.Oasis:
                portal.SetActive(true);
            break;
        }
    }


    }



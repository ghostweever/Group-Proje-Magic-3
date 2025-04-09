//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class PortalScript : MonoBehaviour
//{
//    private PlayerCrystalManager playerCrystalManager;
//    public GameObject portal;
    

//    void Start()
//    {
//        playerCrystalManager = GetComponent<PlayerCrystalManager>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        ActivatePortal();
        
//    }

//    void ActivatePortal()
//    {
//        if (GameObject.Find("Player").GetComponent<PlayerCrystalManager>().WinCondition()){ 
        
//            portal.gameObject.SetActive(true);
//        } 
//        else
//        {
//            portal.gameObject.SetActive(false);
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if(other.tag == "Player" && GameObject.Find("Player").GetComponent<PlayerCrystalManager>().WinCondition())
//        {
//            SceneManager.LoadScene("Win");
//        }
//    }

//}

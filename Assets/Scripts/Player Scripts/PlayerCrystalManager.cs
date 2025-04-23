//using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCrystalManager : MonoBehaviour
{

    public int playerCrystalCount;
    public bool winCon = true;
    private int crystalsNeeded;
    public int playerCrystalInHand;
    public GameObject mainCamera;
    public GameObject portalCamera;
    private bool canShowPortal;
    private Timer timer;
    private float pausedTime;

    void Start()
    {
        
        crystalsNeeded = 3;
        canShowPortal = true;
        timer = GameObject.Find("Canvas").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowCrystal();
        pausedTime = timer.remainingTime;
    }

    public void SaveCrystal()
    {
        PlayerPrefs.SetInt("PlayerCrystal", playerCrystalCount);
    }

    public void LoadCrystal()
    {
        playerCrystalCount = PlayerPrefs.GetInt("PlayerCrystal");
    }

    public void EarnCrystal(int amount)
    {
        playerCrystalCount += amount;
    }

    public void AddToCrystal()
    {
        playerCrystalInHand += 3;
    }

    public void ShowCrystal()
    {
        if(playerCrystalCount == 3 && canShowPortal)
        {
          
            mainCamera.SetActive(false);
            portalCamera.SetActive(true);
            StartCoroutine(ResetCamera());
        }
    }

    private IEnumerator ResetCamera() {

        timer.remainingTime = pausedTime;
        yield return new WaitForSeconds(5);
        
        mainCamera.SetActive(true);
        portalCamera.SetActive(false);
        canShowPortal = false;
        
    }
}

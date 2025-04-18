using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{

    public int playerLives;
    public bool isInvincible;

    void Start()
    {
        playerLives = 3;        
    }

    void Update()
    {
        FlashFrames();
    }

    public void Damage(int amount)
    {
        playerLives -= amount;

        if (playerLives <= 0)
        {
            GameObject.Find("Void").GetComponent<InGameSettings>().Death();
        }

    }

    public void FlashFrames()
    {
        if (isInvincible)
        {
            StartCoroutine(Flash());
        } else
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
    }

   public IEnumerator Invincible()
    {
        isInvincible = true;
        Debug.Log(isInvincible);
        yield return new WaitForSeconds(3);
        isInvincible = false;
        Debug.Log(isInvincible);
    }



    private IEnumerator Flash()
    {
        for (int i = 0; i < 20; i++) {
            i++;
        transform.GetChild(3).gameObject.SetActive(false);
            yield return new WaitForSeconds(.1f);
            transform.GetChild(3).gameObject.SetActive(true);
            yield return new WaitForSeconds(.1f);
        }
    }
}

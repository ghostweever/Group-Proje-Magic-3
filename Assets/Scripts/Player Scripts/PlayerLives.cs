using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{

    public int playerLives;
    public bool isInvincible;
    private int maxLives = 3;

    public Image originalPrimary;
    public Sprite[] sprites;
    void Start()
    {
        playerLives = maxLives;
        originalPrimary.sprite = sprites[0];
    }

    void Update()
    {
        FlashFrames();
        ChangeLives();
    }

    void ChangeLives()
    {
        if (playerLives == 3)
        {
            originalPrimary.sprite = sprites[0];
        }
        else if (playerLives == 2)
        {
            originalPrimary.sprite = sprites[1];
        }
        else if (playerLives == 1)
        {
            originalPrimary.sprite = sprites[2];
        }
    }
    public void Damage(int amount)
    {
        playerLives -= amount;

        if (playerLives <= 0)
        {
            GameObject.Find("Void").GetComponent<InGameSettings>().Death();
        }

    }

    public void Heal(int amount)
    {
        playerLives += amount;

        if (playerLives <= 3)
        {
            playerLives = maxLives;
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

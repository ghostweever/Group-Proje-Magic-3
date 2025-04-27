using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
     [SerializeField] internal float remainingTime;
    public AudioClip clockClip;
    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        } else if (remainingTime < 0)
        {
            remainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}",minutes, seconds);

        if (remainingTime <= 10)
        {
            AudioSource.PlayClipAtPoint(clockClip, transform.position, 1);
        }

        PlayerDeath();
    }

    void PlayerDeath()
    {
        if(remainingTime == 0)
        {
            Debug.Log("hi");
            GameObject.Find("Void").GetComponent<InGameSettings>().Death();
        }
    }


}

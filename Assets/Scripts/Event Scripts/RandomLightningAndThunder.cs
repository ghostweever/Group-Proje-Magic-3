using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightningAndThunder : MonoBehaviour
{
    public Light lightningLight;  // Light source to simulate lightning (can be a point light or directional light)
    public AudioSource thunderSound;  // Audio source to play the thunder sound
    public float minTimeBetweenStrikes = 8f;  // Minimum time between lightning strikes (in seconds)
    public float maxTimeBetweenStrikes = 12f;  // Maximum time between lightning strikes (in seconds)
    public float lightningFlickerDuration = 1f;  // Duration of the flickering lightning (in seconds)
    public float thunderDelay = 3f;  // Delay before playing thunder sound after lightning

    private void Start()
    {
        StartCoroutine(LightningThunderCycle());
    }

    private IEnumerator LightningThunderCycle()
    {
        while (true)
        {
            // Wait for a random time between the lightning strikes
            float waitTime = Random.Range(minTimeBetweenStrikes, maxTimeBetweenStrikes);
            yield return new WaitForSeconds(waitTime);

            // Trigger lightning and thunder
            TriggerLightningThunder();

            // Wait for the lightning to finish before the next strike
            yield return new WaitForSeconds(lightningFlickerDuration);
        }
    }

    private void TriggerLightningThunder()
    {
        // Start a coroutine to make the lightning flicker
        StartCoroutine(LightningFlicker());

        // Start a coroutine to play the thunder after a delay
        StartCoroutine(PlayThunderWithDelay());
    }

    private IEnumerator LightningFlicker()
    {
        float flickerEndTime = Time.time + lightningFlickerDuration; // Time when flickering stops

        // Keep flickering the light until the flicker duration ends
        while (Time.time < flickerEndTime)
        {
            lightningLight.enabled = !lightningLight.enabled;  // Toggle light on/off
            yield return new WaitForSeconds(0.05f);  // Adjust the time interval between flickers (flickers every 0.05 seconds)
        }

        // After flickering, make sure the light stays off
        lightningLight.enabled = false;
    }

    private IEnumerator PlayThunderWithDelay()
    {
        // Wait for the delay before playing the thunder sound
        yield return new WaitForSeconds(thunderDelay);

        // Play the thunder sound
        thunderSound.Play();
    }
}

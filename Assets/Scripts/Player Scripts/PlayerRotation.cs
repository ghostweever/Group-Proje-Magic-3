using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    private PlayerInputHandler inputHandler;

    public float mouseSensitivity = 3.5f;
    private float upDownRange = 40.0f;
    private float verticalRotation;

    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }

    // Update is called once per frame
    public void Rotation()
    {
        if (GameObject.Find("PauseMenuUI").GetComponent<PauseMenu>().isPaused == false)
        {

            float mouseXRotation = inputHandler.LookInput.x * mouseSensitivity;
            transform.Rotate(0, mouseXRotation, 0);

            verticalRotation -= inputHandler.LookInput.y * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

        }
    }
}

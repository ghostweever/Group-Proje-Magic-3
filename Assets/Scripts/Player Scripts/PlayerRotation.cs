using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    private PlayerInputHandler inputHandler;

    private float mouseSensitivity = .35f;
    private float upDownRange = 80.0f;
    private float verticalRotation;

    void Start()
    {
        inputHandler = PlayerInputHandler.Instance;
    }

    // Update is called once per frame
    public void Rotation()
    {
        float mouseXRotation = inputHandler.LookInput.x * mouseSensitivity * .7f;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= inputHandler.LookInput.y * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);


    }
}

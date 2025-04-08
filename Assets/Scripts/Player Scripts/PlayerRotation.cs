using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    private PlayerInputHandler inputHandler;

    public float mouseSensitivity = 2f;
    private float upDownRange = 40.0f;
    private float verticalRotation;
    private float speed = 5;

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

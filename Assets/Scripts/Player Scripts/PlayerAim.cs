using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject aimCamera;
    public GameObject aimReticle;

    void Start()
    {
        aimReticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AimCamera();
    }


    void AimCamera()
    {
        if (Input.GetButtonDown("KeyboardAim") || Input.GetButtonDown("XboxAim"))
        {
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);
            StartCoroutine(Reticle());
        }

        if (Input.GetButtonUp("KeyboardAim") || Input.GetButtonUp("XboxAim"))
        {
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
            aimReticle.SetActive(false);
            StopAllCoroutines();
        }
    }

    private IEnumerator Reticle()
    {
        yield return new WaitForSeconds(.5f);
        aimReticle.SetActive(true);
    }
}

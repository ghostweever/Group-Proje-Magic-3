using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject spawnPos;
    public GameObject player;
    private Animator animator;
    public AudioClip checkPoint;

    private bool canHit = true;
    private void Start()
    {
        animator = this.transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            if (canHit)
            {
                animator.SetTrigger("GotCheckPoint");
                AudioSource.PlayClipAtPoint(checkPoint, transform.position);
                spawnPos.transform.position = this.transform.position;
                StartCoroutine(ResetAnimation());
            }
        }
    }

    private IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(2);
        animator.ResetTrigger("GotCheckPoint");
        canHit = false;
    }
}

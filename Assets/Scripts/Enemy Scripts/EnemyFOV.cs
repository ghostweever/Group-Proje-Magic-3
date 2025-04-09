using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFOV : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject player;

    public AudioClip enemyAlert;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    private int canPlayAudio = 1;

    public bool canSeePlayer;

    private NavMeshAgent enemy;
    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOV());
        enemy = GetComponent<NavMeshAgent>();
    }

    //Runs function to check if player is in FOV+
    private IEnumerator FOV()
    {
        float delay = 0.2f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    //Sends out a raycast that if the target (player) is inside will cause enemy to chase until they're outside of radius
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask))
                {
                    if (canPlayAudio == 1)
                    {
                        AudioSource.PlayClipAtPoint(enemyAlert, transform.position, 2f);
                        canPlayAudio--;
                        StartCoroutine(resetAudio());
                    }
                    canSeePlayer = true;
                    enemy.SetDestination(player.transform.position);
                }
                else
                {
                    canSeePlayer = false;

                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }

    }


    private IEnumerator resetAudio()
    {
        yield return new WaitForSeconds(2f);
        canPlayAudio = 1;
    }
}


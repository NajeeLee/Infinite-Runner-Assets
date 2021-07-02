using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class FlyingEnemy : MonoBehaviour
{

    private fos_controller_script player;

    public float moveSpeed;

    public float attackingSpeed;


    public float playerRange;

    public LayerMask playerLayer;

    public bool playerInRange;

    public float distance;

    public float distanceToAttack;

    public float attackRange;

    public bool hurtingPlayer = false;

    public bool attacking = false;

    public Transform target;

    // Use this for initialization

    void Start()
    {

        player = FindObjectOfType<fos_controller_script>();

    }

    // Update is called once per frame
    void Update()
    {

        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        distance = Vector3.Distance(transform.position, target.transform.position);

        distanceToAttack = Vector3.Distance(transform.position, target.transform.position);


        if (playerInRange)
        {   ///<---- this checks if the player is inside the gizmo


            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime); ///<--- then when he is InRange the enemy moves with moveSpeed Velocity


            if (distanceToAttack < attackRange)
            { ////<--- and when the player is closer then enters to the attackRange

                StartCoroutine("waitForNextAttack");


            }
        }

    }

    void OnDrawGizmosSelected()
    {

        Gizmos.DrawSphere(transform.position, playerRange);


    }


    IEnumerator waitForNextAttack()
    {


        attacking = true;

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, attackingSpeed * Time.deltaTime);  ////<---- and when he is in attackRange the speed changes to attackingSpeed which is faster

        yield return new WaitForSeconds(1f);

        attacking = false;


    }

}
 

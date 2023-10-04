using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using StarterAssets;

public class BruteProximityActions : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] NavMeshAgent navMeshAgent;
    ThirdPersonControllerAI thirdPersonControllerAI;
    private Animator animator;
    private float timeBetweenAttacks = 3.5f;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        thirdPersonControllerAI = GetComponent<ThirdPersonControllerAI>();

    }

    // Update is called once per frame
    void Update()
    {
        bool inDistance = Vector3.Distance(transform.position, playerPos.position) < 2.5f;

        if (inDistance && timeBetweenAttacks < .5f)
        {
            thirdPersonControllerAI.MoveSpeed = 0;
            animator.SetTrigger("Attack Combo 1");
            timeBetweenAttacks = 3.4f;
        }
        if (timeBetweenAttacks < .1f)
        {
            thirdPersonControllerAI.MoveSpeed = 3;
        }
        timeBetweenAttacks -= Time.deltaTime;
    }
}

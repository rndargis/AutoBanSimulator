using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTargetComponent : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    private float elapsedTime = 0;

    // Update is called once per frame
    void Start()
    {
        if (agent != null && target != null)
            agent.SetDestination(target.transform.position);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1)
        {
            agent.SetDestination(target.transform.position);
            elapsedTime -= 1;
        }
    }
}

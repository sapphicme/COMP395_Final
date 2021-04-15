using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAI : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent _agent;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        _agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<evade>().isDead == false)
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                _agent.SetDestination(newPos);
                timer = 0;
            }
        }

        if(this.gameObject.GetComponent<evade>().isDead == true)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("trigerred3");
        if(other.gameObject.CompareTag("Victim"))
        {
            Debug.Log("trigerred2");
            if(this.gameObject.GetComponent<evade>().isInfected == true && other.gameObject.GetComponent<evade>().isInfected == false)
            {
                Debug.Log("trigerred");
                other.gameObject.GetComponent<Renderer>().material = other.gameObject.GetComponent<evade>().infected;
                other.gameObject.GetComponent<evade>().isInfected = true;
            }
        }
    }
}

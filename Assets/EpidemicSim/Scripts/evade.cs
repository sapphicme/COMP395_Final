using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class evade : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject player;
    public float EnemyDistanceRun = 4.0f;
    public Material infected;
    public Material dead;
    public bool isInfected;
    public bool isDead;
    private double countdown;
    //public GameObject

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        isInfected = false;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInfected)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if(distance < EnemyDistanceRun)
            {
                Vector3 dirToPlayer = transform.position - player.transform.position;

                Vector3 newPos = transform.position + dirToPlayer;

                _agent.SetDestination(newPos);

            }
        }

        if (isInfected)
        {
            countdown += Time.deltaTime;
            if(countdown >= 10)
            {
                this.gameObject.GetComponent<Renderer>().material = dead;
                isDead = true;
            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<Renderer>().material = infected;
            isInfected = true;
        }
    }
}

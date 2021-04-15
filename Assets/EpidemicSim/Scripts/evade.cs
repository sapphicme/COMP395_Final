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
    private bool isInfected = false;
    private double countdown;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInfected)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            Debug.Log("distance:" + distance);

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
            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Renderer>().material = infected;
            isInfected = true;
        }
    }
}

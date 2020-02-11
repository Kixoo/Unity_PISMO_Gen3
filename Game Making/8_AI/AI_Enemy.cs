using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Kada koristimo AI

[RequireComponent(typeof(NavMeshAgent))]
public class AI_Enemy : MonoBehaviour
{
    public Transform player; //Objekt do kojeg trebam doći
    Vector3 final_destination;
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<CharacterController>().gameObject.transform;
        final_destination = agent.destination;
    }

    private void LateUpdate()
    {
        if(Vector3.Distance(final_destination, player.position) > 2.0f)
        {
            final_destination = player.position;
            agent.destination = final_destination;
        }
    }
}

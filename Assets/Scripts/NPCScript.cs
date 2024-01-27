using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Interaction;
 
    public class NPCScript : MonoBehaviour, IInteraction
{
    public NPC_SO NpcData;
    NavMeshAgent NavAgent;
    public Transform Destination;
    public Vector3 Position => transform.position;

    public ItemID Interact(ItemID id)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        NavAgent.updateRotation = false;
        NavAgent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        NavAgent.SetDestination(Destination.position);
    }
}

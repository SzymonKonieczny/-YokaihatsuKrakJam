using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;


using Interaction;
 
    public class NPCScript : MonoBehaviour, IInteraction
{
    public NPC_SO NpcData;
    NavMeshAgent NavAgent;
    Animator animator;
    public Transform Destination;

    public Vector3 Position => transform.position;


    public float MoveDir;

    public ItemID Interact(ItemID id)
    {
        if (GameManager.Instance.ItemsContainer.Get(id).Type == NpcData.Type)
        {
            //to do, affect the happiness inflience bar 
            // GameManager.Instance.ItemsContainer.Get(id).Infuence
            return ItemID.Empty;
        }
        else return id;

    }

    // Start is called before the first frame update
    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        NavAgent.updateRotation = false;
        NavAgent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        NavAgent.SetDestination(Destination.position);
        animator.SetFloat("MoveDir", NavAgent.velocity.y);
        animator.SetBool("IsMoving", (NavAgent.velocity.magnitude > 0.05f));
    }
}

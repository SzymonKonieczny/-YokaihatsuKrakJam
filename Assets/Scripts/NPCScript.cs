using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;


using Interaction;
 enum NPC_State
{
    Wondering,
    GoingAway
}
    public class NPCScript : MonoBehaviour, IInteraction
{
    NPC_State State = NPC_State.Wondering;
    public float TimeAlive = 0.0f;
    public NPC_SO NpcData;
    NavMeshAgent NavAgent;
    Animator animator;
    BoundingArea area;
    public Vector3 Destination;

    public Vector3 Position => transform.position;


    public float MoveDir;
    public void SetData(NPC_SO Data, BoundingArea _area)
    {
        NpcData = Data;
        area = _area;
    }
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
    
    public void Highlight()
    {
    }

    public void Unhighlight()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        NavAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        NavAgent.updateRotation = false;
        NavAgent.updateUpAxis = false;

    }

    void Update()
    {
        TimeAlive += Time.deltaTime;

        switch(State)
        {
            case NPC_State.Wondering:
                if (Vector3.Distance(transform.position, Destination) < 0.1f)
                {
                    Destination = area.getRandomSpot();
                }
                NavAgent.SetDestination(Destination);
                if(TimeAlive>10.0f)
                {
                    State = NPC_State.GoingAway;
                    NavAgent.SetDestination(GameManager.Instance.DestinationPoints[UnityEngine.Random.Range(0,
                        GameManager.Instance.DestinationPoints.Count-1)].position);

                }

                break;
            case NPC_State.GoingAway:

                

           break;
        }

        animator.SetFloat("MoveDir", NavAgent.velocity.y);
        animator.SetBool("IsMoving", (NavAgent.velocity.magnitude > 0.05f));
    }
}

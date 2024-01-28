using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.ParticleSystemJobs;


using Interaction;
 enum NPC_State
{
    Wondering,
    GoingAway
}
enum Mood
{
    Sad=-1,
    Neutral,
    Happy
}
    public class NPCScript : MonoBehaviour, IInteraction
{
    Mood mood = Mood.Neutral;
    NPC_State State = NPC_State.Wondering;
    public float TimeAlive = 0.0f;
    public NPC_SO NpcData;
    NavMeshAgent NavAgent;
    public List<Sprite> HappyFrames = new List<Sprite>();
    public List<Sprite> SadFrames = new List<Sprite>();

    [SerializeField] Animator animator;
    BoundingArea area;
    public Vector3 Destination;
    [SerializeField] ParticleSystem Particles;

    public Vector3 Position => transform.position;


    public float MoveDir;
    public void SetData(NPC_SO Data, BoundingArea _area)
    {
        NpcData = Data;
        area = _area;
        animator.runtimeAnimatorController = Data.AnimationOverride;
    }
    public ItemID Interact(ItemID id)
    {
        Item_SO item = GameManager.Instance.ItemsContainer.Get(id);
        if (item.Type == NpcData.Type)
        {
            mood = (item.Infuence == HappinessInfluence.Positive) ? Mood.Happy : Mood.Sad;

            for (int i = Particles.textureSheetAnimation.spriteCount-1; i >=0 ; i--)
            {
                Particles.textureSheetAnimation.RemoveSprite(i);
            }

            List<Sprite> Frames = (mood == Mood.Happy) ? HappyFrames : SadFrames;
            for (int i = 0; i < Frames.Count; i++)
            {
                Particles.textureSheetAnimation.AddSprite(Frames[i]);
            }
            Particles.Play();
            MusicManager.Instance.PlayItemMusic(id, transform.position);
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
        NavAgent.updateRotation = false;
        NavAgent.updateUpAxis = false;

        Particles.Pause();
        Destination = area.getRandomSpot();
    }

    void Update()
    {
        TimeAlive += Time.deltaTime;
        HappinessController.Instance.Change(0.005f * (int)mood * Time.deltaTime);

        switch (State)
        {
            case NPC_State.Wondering:
                if (Vector2.Distance(transform.position, Destination) < 0.1f)
                {
                    Destination = area.getRandomSpot();
                }
                NavAgent.SetDestination(Destination);
                if(TimeAlive>30.0f)
                {
                    State = NPC_State.GoingAway;
                    NavAgent.SetDestination(GameManager.Instance.DestinationPoints[UnityEngine.Random.Range(0,
                        GameManager.Instance.DestinationPoints.Count)].position);

                }

                break;
            case NPC_State.GoingAway:

                

           break;
        }

        animator.SetFloat("Vertical", NavAgent.velocity.y);
        animator.SetFloat("Horizontal", NavAgent.velocity.x);

        //animator.SetBool("IsMoving", (NavAgent.velocity.magnitude > 0.05f));
    }
}

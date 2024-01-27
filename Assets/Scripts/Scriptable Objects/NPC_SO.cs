using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum NpcType
{
    None,
    Hearing,
    Seeing,
    Smelling
}
[CreateAssetMenu(fileName = "NewNpc", menuName = "ScriptableObjects/NPC_Data")]
public class NPC_SO : ScriptableObject
{
   public NpcType Type;    
    public AnimatorOverrideController AnimationOverride;

}

using UnityEngine;

namespace Interaction
{
    public interface IInteraction
    {
        Vector3 Position { get; }
        ItemID Interact(ItemID id);
    }
}

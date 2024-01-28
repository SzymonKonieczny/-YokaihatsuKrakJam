using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interaction
{
    public class PlayerInteractionSystem : MonoBehaviour, IInteraction
    {
        private ItemID currentItem;
        public ItemID InteractItem;
        [SerializeField] private PlayerType type;

        [SerializeField] PlayerMovement movementScript;
        public float radius = 2f;
        private List<IInteraction> _currentInteractions  = new List<IInteraction>();
        private IInteraction _nearestInteraction;
        [SerializeField] public KeyCode interactionKey;
        [SerializeField] public KeyCode dropKey;
        private UnitManager _unitManager;

        private void Start()
        {
            CurrentItemUI.Instance.Set(currentItem, type);
            _unitManager = FindObjectOfType<UnitManager>();
        }

        private void Update()
        {
            _currentInteractions = _currentInteractions.Where(p => p != null).ToList();
            
            if (Input.GetKeyDown(interactionKey) && movementScript.stunTime<=0)
            {
                var newNearest = _currentInteractions.OrderBy(p => Vector3.Distance(p.Position, transform.position)).FirstOrDefault();
                if (_nearestInteraction != newNearest)
                    SetNearest(newNearest);
                
                if (_nearestInteraction != null && !_nearestInteraction.Equals(default))
                {
                    var newItem = _nearestInteraction.Interact(currentItem);
                    currentItem = newItem;
                    CurrentItemUI.Instance.Set(currentItem, type);
                }
            }

            if (Input.GetKeyDown(dropKey))
            {
                _unitManager.SpawnItem(currentItem, transform.position);
                currentItem = ItemID.Empty;
                CurrentItemUI.Instance.Set(currentItem, type);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteraction interaction))
            {
                if (interaction != this)
                    _currentInteractions.Add(interaction);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteraction interaction))
            {
                if (interaction != this)
                    _currentInteractions.Remove(interaction);
            }
        }

        private void SetNearest(IInteraction newNearest)
        {
            if(_nearestInteraction != null)
                _nearestInteraction.Unhighlight();
            _nearestInteraction = newNearest;
            _nearestInteraction?.Highlight();
        }

        public Vector3 Position => transform.position;
        public ItemID Interact(ItemID id)
        {
            if(id == InteractItem)
            {
                movementScript.stunTime = 1.5f;
                return ItemID.Empty;
            }

            return id;
        }

        public void Highlight()
        {
        }

        public void Unhighlight()
        {
        }
    }
}

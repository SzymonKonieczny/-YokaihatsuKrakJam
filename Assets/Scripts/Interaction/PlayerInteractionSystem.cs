using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interaction
{
    public class PlayerInteractionSystem : MonoBehaviour, IInteraction
    {
        private ItemID currentItem;
        public float radius = 2f;
        private List<IInteraction> _currentInteractions  = new List<IInteraction>();
        private IInteraction _nearestInteraction;
        [SerializeField] public KeyCode interactionKey;

        private void Start()
        {
            CurrentItemUI.Instance.Set(currentItem);
        }

        private void Update()
        {
            var newNearest = _currentInteractions.OrderBy(p => Vector3.Distance(p.Position, transform.position)).FirstOrDefault();
            if (_nearestInteraction != newNearest)
                SetNearest(newNearest);
            
            if (Input.GetKeyDown(interactionKey))
            {
                if (_nearestInteraction != null && !_nearestInteraction.Equals(default))
                {
                    var newItem = _nearestInteraction.Interact(currentItem);
                    if (newItem == ItemID.Empty)
                    {
                        HappinessController.Instance.Change(currentItem);
                        currentItem = newItem;
                        CurrentItemUI.Instance.Set(currentItem);
                    }
                }
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteraction interaction))
            {
                if ((PlayerInteractionSystem)interaction != this)
                    _currentInteractions.Add(interaction);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteraction interaction))
            {
                if ((PlayerInteractionSystem)interaction != this)
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
            Debug.Log($"Interaction {id} on {transform.name}");
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

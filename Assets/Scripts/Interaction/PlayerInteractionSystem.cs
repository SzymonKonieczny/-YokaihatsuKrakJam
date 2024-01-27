using UnityEngine;

namespace Interaction
{
    public class PlayerInteractionSystem : MonoBehaviour
    {
        public float radius = 2f;
        
        void Update()
        {
            var asd = Physics2D.OverlapCircleAll(transform.position, radius);

        }
    }
}

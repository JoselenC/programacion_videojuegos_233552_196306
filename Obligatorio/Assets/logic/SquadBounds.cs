using UnityEngine;

namespace logic
{
    public class SquadBounds : MonoBehaviour
    {
        [SerializeField] private float width, height;

        public Vector2 size => new Vector2(width * transform.localScale.x, height *
                                                                           transform.localScale.y);

        public bool Collides(CircleBounds bounds)
        {
            float distX = transform.position.x - bounds.transform.position.x;
            float distY = transform.position.y - bounds.transform.position.y;
        
            var p = width*height + bounds.radius;
            if (Mathf.Abs(distX) < p)
                return false;
            if (Mathf.Abs(distY) > p)
                return false;
            return true;
        }
        
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, size);
        }
    }
}
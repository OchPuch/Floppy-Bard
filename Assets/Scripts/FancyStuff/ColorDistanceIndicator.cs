using UnityEngine;

namespace FancyStuff
{
    public class ColorDistanceIndicator : MonoBehaviour
    {
        [SerializeField] private Color baseColor;
        [SerializeField] private Color dangerColor;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float maxDistance;
    
        private void Start()
        {
            if (!spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = baseColor;
        }
    
        private void FixedUpdate()
        {
            Vector2 playerPosition = transform.position;
            RaycastHit2D hit = Physics2D.Raycast(playerPosition, transform.right, maxDistance);
            Debug.DrawRay(playerPosition, transform.right * maxDistance, Color.green);
            if (hit.collider)
            {
        
                float progress = 1- Mathf.Clamp01(hit.distance / maxDistance);
                Color lerpedColor = Color.Lerp(baseColor, dangerColor, progress);
                spriteRenderer.color = lerpedColor;
            }
            else
            {
                spriteRenderer.color = baseColor;
            }
        }


    }
}

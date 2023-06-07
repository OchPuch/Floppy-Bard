using UnityEngine;

namespace PrefabsLogic
{
    public class PillarStructure : MonoBehaviour
    {
        [Header("Pillars")]
        [SerializeField] GameObject upperPillar;
        [SerializeField] GameObject lowerPillar;
        [Header("Components")] 
        [SerializeField] private Rigidbody2D rb;
        void Start()
        {
            if (!rb) rb = GetComponent<Rigidbody2D>();
            upperPillar.transform.position += new Vector3(0, GameManager.Instance.CurrentDifficulty.PillarSpace, 0);
            lowerPillar.transform.position -= new Vector3(0, GameManager.Instance.CurrentDifficulty.PillarSpace, 0);
            float addPillarHeight = Random.Range(-0.5f * GameManager.Instance.CurrentDifficulty.PillarHeightRange,
                0.5f * GameManager.Instance.CurrentDifficulty.PillarHeightRange);
            transform.position += new Vector3(0, addPillarHeight, 0);
            rb.velocity = new Vector2(-GameManager.Instance.CurrentDifficulty.PillarSpeed, 0);
        }

    
    }
}

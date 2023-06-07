using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flySound;
    [SerializeField] private AudioClip deathSound;
    public bool invincible = false;
    private void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        if (!audioSource) audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(rb.velocity.y, 1) * Mathf.Rad2Deg);
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    
    public void Fly()
    {
        if (!GameManager.Instance.isGameStarted) GameManager.Instance.OnGameStarted?.Invoke();
        rb.velocity = new Vector2(rb.velocity.x, 5f);
        audioSource.PlayOneShot(flySound);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("wall"))
        {
            GameManager.Instance.OnGameOver?.Invoke();
            audioSource.PlayOneShot(deathSound);
        }
    }
}

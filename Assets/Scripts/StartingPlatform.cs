using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPlatform : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
   
    private void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        GameManager.Instance.OnGameStarted += OnGameStarted;

    }

    private void OnGameStarted()
    {
        rb.velocity = -Vector2.right * GameManager.Instance.CurrentDifficulty.PillarSpeed;
    }
}

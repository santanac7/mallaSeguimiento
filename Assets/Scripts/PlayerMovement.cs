using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D pRb;
    [SerializeField] float xSpeed;
    float xMove;

    void Start()
    {
        pRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        pRb.velocity = new Vector2(xMove * xSpeed, pRb.velocity.y);
    }
}

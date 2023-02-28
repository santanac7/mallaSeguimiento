using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D pRb;
    [SerializeField] float xSpeed;
    float xMove;

    // Jump
    [SerializeField] float jumpPower;
    [SerializeField] float ratioDetect;
    [SerializeField] Transform centerDetect;
    [SerializeField] LayerMask maskDetect;
    bool jumpActive;
    bool grounded;



    void Start()
    {
        pRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // xMove
        xMove = Input.GetAxisRaw("Horizontal");
        pRb.velocity = new Vector2(xMove * xSpeed, pRb.velocity.y);

        // Jump
        if ( Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jumpActive = true;
        }
    }

    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(centerDetect.position, ratioDetect, maskDetect);

        if (jumpActive) {
            pRb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpActive = false;
        }
        
    }




    // Gizmo grounded detection
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(centerDetect.position, ratioDetect);
    }
}

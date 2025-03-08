using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    public float health = 100f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        if(Input.GetKey(KeyCode.A)) {
            Vector3 newRotasi = transform.eulerAngles;
            newRotasi.y = 180;
            transform.eulerAngles = newRotasi;
        }else if(Input.GetKey(KeyCode.D)) {
            Vector3 newRotasi = transform.eulerAngles;
            newRotasi.y = 0;
            transform.eulerAngles = newRotasi;
        }

        animator.SetBool("Run", moveX != 0 || moveY != 0);

    }

    
    
}

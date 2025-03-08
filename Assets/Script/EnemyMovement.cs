using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform Player;
    
    private GameManager GM;
    private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Animator animator;
    private float stopDistance = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        GameObject GMObject = GameObject.FindWithTag("GM");
        rb = GetComponent<Rigidbody2D>();
        Player = playerObject.transform;
        animator = GetComponent<Animator>();
        GM = GMObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(rb.transform.position, Player.position);

        if(distance > stopDistance) {
            animator.SetBool("RunEnemy", true);
            transform.position = Vector2.MoveTowards(rb.transform.position, Player.position, moveSpeed * Time.deltaTime);
        }else {
            animator.SetBool("RunEnemy", false);
            rb.velocity = Vector2.zero;
        }

        if(rb.transform.position.x > Player.position.x ) {
            Vector3 newRotasi = transform.eulerAngles;
            newRotasi.y = 180;
            transform.eulerAngles = newRotasi;
        }else if(rb.transform.position.x < Player.position.x ) {
            Vector3 newRotasi = transform.eulerAngles;
            newRotasi.y = 0;
            transform.eulerAngles = newRotasi;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Bullet") {
            GM.AddScore(1);
            Destroy(gameObject);
        }
    }

    

    
}

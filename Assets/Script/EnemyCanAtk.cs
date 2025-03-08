using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyCanAtk : MonoBehaviour
{
    private PlayerMovement PM;
    private GameObject gameover;
    public Transform EnemyArea;
    public LayerMask layer;
    private bool canAtk = true;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        PM = playerObject.GetComponent<PlayerMovement>();

    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(PM.transform.position, transform.position);
        if(canAtk && distance <= 1.2) {
            StartCoroutine(AtkEnemy());
        }

    }

    IEnumerator AtkEnemy() {
        canAtk = false;
        Collider2D enemyAtkArea = Physics2D.OverlapCircle(EnemyArea.position, layer);
        if(enemyAtkArea) {
            PM.health -= 10;
            
            Debug.Log(PM.health);
            if(PM.health <= 0) {
                
                Debug.Log("Player mati");
            }
        }
        yield return new WaitForSeconds(2f);
        canAtk = true;
    }
    
}

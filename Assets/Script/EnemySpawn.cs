using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform Enemy;
    public GameObject[] EnemyPrefabs;
    private List<GameObject> EnemySpawned = new List<GameObject>();
    private int enemyRandomSpawn = 0;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy),0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.score >= 20) {
            enemyRandomSpawn = Random.Range(0,2);
            //Debug.Log("Kill diatas 20 dan enemy yg ke 2 akan muncul ");
        }
    }

    private void SpawnEnemy() {
        Vector2 spawnEnemy = new Vector2(Random.Range(-18, 18), Random.Range(-10,10));

        GameObject spawnedEnemy = Instantiate(EnemyPrefabs[enemyRandomSpawn], spawnEnemy, Quaternion.identity);
        EnemySpawned.Add(spawnedEnemy);
    }
}

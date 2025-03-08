using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOut : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public Transform posisi;
    //private float spawnInterval = 1f;
    private float moveSpeed = 5f;
    private bool isBullet = true;
    private List<GameObject> SpawnedBullet = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0) && isBullet) {
        ShootBullet();
        StartCoroutine(TimeBulletOut());

       }
    }

    IEnumerator TimeBulletOut() {
        yield return new WaitForSeconds(0.5f);
        isBullet = true;
    }

    void ShootBullet()
    {
        isBullet = false;
        // Dapatkan posisi kursor di dunia
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Set z ke 0 karena kita bekerja dalam 2D

        // Instansiasi peluru di posisi spawn
        GameObject bullet = Instantiate(bulletPrefabs, posisi.position, Quaternion.identity);

        // Hitung arah dari spawn ke posisi mouse
        Vector2 direction = (mousePosition - bullet.transform.position).normalized;

        // Berikan kecepatan ke peluru
        bullet.GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
        
    }
}

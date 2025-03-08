using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    public Transform Player;
    private Vector3 offset = new Vector3(0, 0.7f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(Player.position + offset);
        transform.position = screenPosition;
        // transform.position = new Vector3(Player.position.x, Player.position.y + 3, 0);
    }
}

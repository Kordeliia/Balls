using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody _rigidBody;
    public float moveForce;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
        _rigidBody.AddForce(lookDirection * moveForce, ForceMode.Force);
        if(this.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}

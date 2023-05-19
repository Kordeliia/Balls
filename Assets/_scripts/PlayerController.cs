using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rbPlayer;
    public float moveForce;
    public GameObject center;
    public GameObject[] powerUpIndicators;
    public GameObject balloon;
    // Start is called before the first frame update
    void Start()
    {
        _rbPlayer = GetComponent<Rigidbody>();
        // Es mejor poner en un futuro private la variable center
        //y aquí escribir center = GameObject.Find("Center");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        //Fuerza = masa * aceleración
        _rbPlayer.AddForce(center.transform.forward * moveForce * forwardInput, ForceMode.Force);
        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position + 0.5f * Vector3.down;
        }
        balloon.transform.position = this.transform.position + 3f * Vector3.up;
        if(this.transform.position.y < -10)
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPowerUp : MonoBehaviour
{
    private PlayerController playerController;
    public bool isPickedUpPowerUp = false;
    public bool isPickedUpPowerUp2 = false;
    public float powerUp;
    public float powerUpTime1;
    public float powerUpTime2;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            isPickedUpPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
        }
        if (other.CompareTag("PowerUp2"))
        {
            isPickedUpPowerUp2 = true;
            Destroy(other.gameObject);
            playerController.balloon.gameObject.SetActive(true);
            StartCoroutine(PowerUpCountDown2());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && isPickedUpPowerUp)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;
            enemyRB.AddForce(awayFromPlayer * powerUp, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Enemy") && isPickedUpPowerUp2)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Destroy(enemyRB.gameObject);
        }
    }

    IEnumerator PowerUpCountDown()
    {
        foreach (GameObject indicator in playerController.powerUpIndicators)
        {
            indicator.gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime1 / playerController.powerUpIndicators.Length);
            indicator.gameObject.SetActive(false);
        }
        isPickedUpPowerUp = false;
    }
    IEnumerator PowerUpCountDown2()
    {
        yield return new WaitForSeconds(powerUpTime2);
        playerController.balloon.gameObject.SetActive(false);
        isPickedUpPowerUp2 = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    private float fwdInput;
    private bool hasPowerup;
    private float powerupStrength;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        speed = 5.0f;
        powerupStrength = 15.0f;
        hasPowerup = false;
    }

    void Update()
    {
        fwdInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * fwdInput);
        if (fwdInput == 0)
        {
            playerRb.AddForce(playerRb.velocity * -1);
        }
        //Sistema de refer�ncia local (baseado na c�mera) e n�o global (b�ssola).
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if(transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup == true)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            hasPowerup = false;
            powerupIndicator.gameObject.SetActive(false);
            Debug.Log("Collided with enemy: " + collision.gameObject.name + " with powerup!");
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}

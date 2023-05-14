using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private float _speed = 3f; 
    [SerializeField]
    private int _powerupID;

    private AudioSource _audioSrc;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        _audioSrc = GameObject.Find("PowerupEffect").GetComponent<AudioSource>();
        if(_audioSrc == null)
        {
            Debug.Log("NULL AudioSource::Powerup");
        }

        if(transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                switch (_powerupID)
                {
                    case 0:
                        player.TripleShotActivate();
                        break;
                    case 1:
                        player.SpeedBoostActivate();
                        break;
                    case 2:
                        player.ShieldActivate();
                        break;
                }

                _audioSrc.Play();
            }

            Destroy(this.gameObject);

        }
    }

    
}

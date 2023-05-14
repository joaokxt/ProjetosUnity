using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{ 
    private AudioSource _audioSrc;
    [SerializeField]
    private AudioClip _somMoeda;
    [SerializeField]
    private bool _estouAqui = false;

    private void Start()
    {
        _audioSrc = GetComponent<AudioSource>();
        if (_audioSrc == null)
        {
            Debug.Log("AudioSrc NULL::Coin");
        }
        else
        {
            _audioSrc.clip = _somMoeda;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                player.AddCoins();
                AudioSource.PlayClipAtPoint(_somMoeda, transform.position, 1f);
                Destroy(this.gameObject);
            }
          
        }
    }

}

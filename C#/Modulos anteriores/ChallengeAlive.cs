using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeAlive : MonoBehaviour
{
    public int saude = 100;
    public bool taMorto;

    private void Dano(int valorAtaque)
    {
        saude -= valorAtaque;
        if(IsDead())
        {
            saude = 0;
            Debug.Log("Você morreu!");
            Destroy(this.gameObject);
        }
    }

    public bool IsDead()
    {
        return saude < 1;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsDead() == false)
        {
            int golpe = UnityEngine.Random.Range(1, 10);
            Dano(golpe);
        }
    }
   
}

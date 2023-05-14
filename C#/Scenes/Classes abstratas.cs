using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

namespace OutroTeste
{
    public abstract class Enemy : MonoBehaviour
    {
        public int speed;
        public int health;
        public int loot;

        public abstract void Attack();

        public virtual void Die()
        {
            Destroy(this.gameObject);
        }
    }

    public class MossGiant : Enemy
    {
        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override void Die()
        {
            //Outras ações
            base.Die();
        }
    }
}



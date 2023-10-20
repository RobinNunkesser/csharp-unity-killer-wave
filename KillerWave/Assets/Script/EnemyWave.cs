using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyWave : MonoBehaviour, IActorTemplate
{
    int health;
    int travelSpeed;
    int fireSpeed;
    int hitPower;

    [SerializeField]
    float verticalSpeed = 2;
    [SerializeField]
    float verticalAmplitude = 1;
    UnityEngine.Vector3 sineVer;
    float time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        time += Time.deltaTime;
        sineVer.y = Mathf.Sin(time * verticalSpeed) * verticalAmplitude;
        transform.position = new UnityEngine.Vector3(transform.position.x + travelSpeed * Time.deltaTime,
            transform.position.y + sineVer.y, transform.position.z);
    }

    public void ActorStats(SOActorModel actorModel)
    {
        health = actorModel.health;
        travelSpeed = actorModel.speed;
        hitPower = actorModel.hitPower;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (health >= 1)
            {
                health -= other.GetComponent<IActorTemplate>().SendDamage();
            }
            if (health <= 0)
            {
                Die();
            }
        }
    }

}

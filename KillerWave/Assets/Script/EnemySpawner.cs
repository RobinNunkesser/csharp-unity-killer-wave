using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    SOActorModel actorModel;
    [SerializeField]
    float spawnRate;
    [SerializeField]
    [Range(0, 10)]
    int quantity;
    GameObject enemies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        Debug.unityLogger.Log("Enter Awake");
        enemies = GameObject.Find("_Enemies");
        StartCoroutine(FireEnemy(quantity, spawnRate));
    }

    IEnumerator FireEnemy(int quantity, float spawnRate)
    {
        for (int i = 0; i < quantity; i++)
        {
            var enemyUnit = CreateEnemy();
            enemyUnit.gameObject.transform.SetParent(this.transform);
            enemyUnit.transform.position = transform.position;
            yield return new WaitForSeconds(spawnRate);
        }
        yield return null;
    }

    GameObject CreateEnemy()
    {
        var enemy = GameObject.Instantiate(actorModel.actor) as GameObject;
        enemy.GetComponent<IActorTemplate>().ActorStats(actorModel);
        enemy.name = actorModel.actorName.ToString();
        return enemy;
    }
}

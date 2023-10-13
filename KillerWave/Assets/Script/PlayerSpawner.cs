using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    SOActorModel actorModel;
    GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    void CreatePlayer()
    {
        actorModel = Object.Instantiate(Resources.Load("Player_Default")) as SOActorModel;
        playerShip = GameObject.Instantiate(actorModel.actor);
        playerShip.GetComponent<Player>().ActorStats(actorModel);

        playerShip.transform.rotation = Quaternion.Euler(0, 180, 0);
        playerShip.transform.localScale = new Vector3(60, 60, 60);
        playerShip.name = "Player";
        playerShip.transform.SetParent(this.transform);
        playerShip.transform.position = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {

    }
}

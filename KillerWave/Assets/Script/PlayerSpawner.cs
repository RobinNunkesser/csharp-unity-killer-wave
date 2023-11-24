using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    SOActorModel actorModel;
    GameObject playerShip;
    bool upgradedShip = false;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
        GetComponentInChildren<Player>().enabled = true;
        GameManager.Instance.CameraSetup();
    }

    void CreatePlayer()
    {
        if (GameObject.Find("UpgradedShip"))
        {
            upgradedShip = true;
        }
        if (!upgradedShip || GameManager.Instance.Died)
        {
            GameManager.Instance.Died = false;
            actorModel = Object.Instantiate(Resources.Load("Player_Default")) as SOActorModel;
            playerShip = GameObject.Instantiate(actorModel.actor, this.transform.position, Quaternion.Euler(270, 180, 0));
            playerShip.GetComponent<Player>().ActorStats(actorModel);
        }
        else
        {
            playerShip = GameObject.Find("UpgradedShip");
        }
        playerShip.transform.rotation = Quaternion.Euler(0, 180, 0);
        playerShip.transform.localScale = new Vector3(60, 60, 60);
        playerShip.GetComponentInChildren<ParticleSystem>().transform.localScale = new Vector3(25, 25, 25);
        playerShip.name = "Player";
        playerShip.transform.SetParent(this.transform);
        playerShip.transform.position = Vector3.zero;
        GameManager.Instance.CameraSetup();

    }

    // Update is called once per frame
    void Update()
    {

    }
}

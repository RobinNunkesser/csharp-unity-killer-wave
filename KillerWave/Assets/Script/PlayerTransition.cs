using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransition : MonoBehaviour
{
    Vector3 transitionToEnd = new Vector3(-100, 0, 0);
    Vector3 transitionToCompleteGame = new Vector3(7000, 0, 0);
    Vector3 readyPos = new Vector3(900, 0, 0);
    Vector3 startPos;

    float distCovered;
    float journeyLength;

    bool levelStarted = true;
    bool speedOff = false;
    public bool LevelEnds { get; set; } = false;
    public bool GameCompleted { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localPosition = Vector3.zero;
        startPos = transform.position;
        Distance();
    }

    private void Distance()
    {
        journeyLength = Vector3.Distance(startPos, readyPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelStarted)
        {
            PlayerMovement(transitionToEnd, 10);
        }
        if (LevelEnds)
        {
            GetComponent<Player>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            Distance();
            PlayerMovement(transitionToEnd, 200);
        }
        if (GameCompleted)
        {
            GetComponent<Player>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            PlayerMovement(transitionToEnd, 200);
        }
        if (speedOff)
        {
            Invoke("SpeedOff", 1f);
        }
    }

    private void PlayerMovement(Vector3 point, float transitionSpeed)
    {
        if (Mathf.Round(transform.localPosition.x) >= readyPos.x - 5 &&
            Mathf.Round(transform.localPosition.x) <= readyPos.x + 5 &&
            Mathf.Round(transform.localPosition.y) >= readyPos.y - 5 &&
            Mathf.Round(transform.localPosition.y) <= readyPos.y + 5)
        {
            if (LevelEnds)
            {
                LevelEnds = false;
                speedOff = true;
            }
            if (levelStarted)
            {
                levelStarted = false;
                distCovered = 0;
                GetComponent<Player>().enabled = true;
            }
        }
        else
        {
            distCovered += Time.deltaTime * transitionSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, point, fractionOfJourney);
        }
    }

    void SpeedOff()
    {
        transform.Translate(Vector3.left * Time.deltaTime * 800);
    }
}

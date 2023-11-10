using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipBuild : MonoBehaviour
{
    [SerializeField]
    GameObject[] shopButtons;
    GameObject target;
    GameObject tmpSelection;
    GameObject textBoxPanel;

    [SerializeField]
    GameObject[] visualWeapons;
    [SerializeField]
    SOActorModel defaultPlayerShip;
    GameObject playerShip;
    GameObject buyButton;
    GameObject bankObj;
    int bank = 600;
    bool purchaseMade = false;

    // Start is called before the first frame update
    void Start()
    {
        textBoxPanel = GameObject.Find("textBoxPanel");
        TurnOffSelectionHighlights();

        purchaseMade = false;
        bankObj = GameObject.Find("bank");
        bankObj.GetComponentInChildren<TextMesh>().text = bank.ToString();
        buyButton = textBoxPanel.transform.Find("BUY ?").gameObject;

        TurnOffPlayerShipVisuals();
        PreparePlayerShipForUpgrade();
    }

    private void PreparePlayerShipForUpgrade()
    {
        playerShip = GameObject.Instantiate(defaultPlayerShip.actor);

        playerShip.GetComponent<Player>().enabled = false;
        playerShip.transform.position = new Vector3(0, 10000, 0);
        playerShip.GetComponent<IActorTemplate>().ActorStats(defaultPlayerShip);
    }

    private void TurnOffPlayerShipVisuals()
    {
        foreach (var weapon in visualWeapons)
        {
            weapon.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        AttemptSelection();
    }

    private void AttemptSelection()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);
            if (target != null)
            {
                var itemText = target.transform.Find("itemText");
                if (itemText)
                {
                    TurnOffSelectionHighlights();
                    Select();
                    UpdateDescriptionBox();

                    if (itemText.GetComponent<TextMesh>().text != "SOLD")
                    {
                        Affordable();
                    }
                    else
                    {
                        SoldOut();
                    }

                }
            }
        }
    }

    private void SoldOut()
    {
        Debug.Log("SOLD OUT");
    }

    private void Affordable()
    {
        var cost = Int32.Parse(target.transform.GetComponent<ShopPiece>().ShopSelection.cost);
        if (bank >= cost)
        {
            Debug.Log("CAN BUY");
            buyButton.SetActive(true);
        }
        else
        {
            Debug.Log("CAN'T BUY");
        }

    }

    private void UpdateDescriptionBox()
    {
        var shopSelection = tmpSelection.GetComponentInParent<ShopPiece>().ShopSelection;
        textBoxPanel.transform.Find("name").gameObject.GetComponent<TextMesh>().text =
            shopSelection.iconName;
        textBoxPanel.transform.Find("desc").gameObject.GetComponent<TextMesh>().text =
            shopSelection.description;

    }

    private void Select()
    {
        tmpSelection = target.transform.Find("SelectionQuad").gameObject;
        tmpSelection.SetActive(true);
    }

    private void TurnOffSelectionHighlights()
    {
        var i = 0;
        foreach (var button in shopButtons)
        {
            button.SetActive(false);
            i++;
        }
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 100, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}

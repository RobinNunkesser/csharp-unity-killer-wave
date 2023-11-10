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

    // Start is called before the first frame update
    void Start()
    {
        textBoxPanel = GameObject.Find("textBoxPanel");
        TurnOffSelectionHighlights();
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
                if (target.transform.Find("itemText"))
                {
                    TurnOffSelectionHighlights();
                    Select();
                    UpdateDescriptionBox();
                }
            }
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

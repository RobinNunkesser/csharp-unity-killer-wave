using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPiece : MonoBehaviour
{

    [SerializeField]
    public SOShopSelection shopSelection;
    public SOShopSelection ShopSelection {
get => shopSelection;
set {shopSelection = value;}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        if (GetComponentInChildren<SpriteRenderer>() != null) {
            GetComponentInChildren<SpriteRenderer>().sprite = shopSelection.icon; 
        }
        if (transform.Find("itemText")) {
            GetComponentInChildren<TextMesh>().text = shopSelection.cost;
        }

    }
}

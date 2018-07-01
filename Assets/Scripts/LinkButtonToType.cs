using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkButtonToType : MonoBehaviour {

    public BuildingType buildingType;

    private void Awake()
    {
        buildingType.buyingButton = gameObject.GetComponent<Button>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "BuildingType", menuName = "Buildings/BasicBuilding", order = 0)]
public class BuildingType : ScriptableObject
{

    public float price;
    public Building building;
    public float powerRate;
    public float happinesRate;

    [HideInInspector]
    public Button buyingButton;

    public virtual void SetValues()
    {
        building.SetValues(powerRate, happinesRate);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class BuildingType : ScriptableObject {

    public float price;
    public Button buyingButton;
    public Building building;
    public float powerRate;
    public float happinesRate;

    public virtual void SetValues()
    {
        building.SetValues(powerRate, happinesRate);
    }
}

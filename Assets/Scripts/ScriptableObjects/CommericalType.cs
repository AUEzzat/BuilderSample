using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommericalType : BuildingType
{
    public new CommercialBuilding building;
    public float moneyRate;

    public override void SetValues()
    {
        base.SetValues();
        building.SetValues(moneyRate);
    }
}

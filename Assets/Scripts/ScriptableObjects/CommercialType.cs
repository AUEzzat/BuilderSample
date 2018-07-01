using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CommercialType", menuName = "Buildings/CommercialBuilding")]
public class CommercialType : BuildingType
{
    public CommercialBuilding commercialBuilding;
    public float moneyRate;
    public int employeesNum;

    public override void SetValues()
    {
        base.SetValues();
        building = commercialBuilding;
        commercialBuilding.SetValues(moneyRate, employeesNum);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AccommodationType", menuName = "Buildings/AccommodationBuilding", order = 0)]
public class AccommodationType : BuildingType {

    public AccommodationBuilding accommodationBuilding;
    public int accommodatorsNum;

    public override void SetValues()
    {
        base.SetValues();
        building = accommodationBuilding;
        accommodationBuilding.SetValues(accommodatorsNum);
    }
}

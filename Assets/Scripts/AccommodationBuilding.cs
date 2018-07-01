using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccommodationBuilding : Building {

    [HideInInspector]
    public int accommodatorsNum;

    protected override void OnEnable()
    {
        base.OnEnable();
        GameManager.instance.inhibitors += accommodatorsNum;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.instance.inhibitors -= accommodatorsNum;
    }

    public void SetValues(int accommodatorsNum)
    {
        this.accommodatorsNum = accommodatorsNum;
    }
}

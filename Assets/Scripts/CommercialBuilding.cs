using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialBuilding : Building {

    protected float moneyRate;

    protected override void OnEnable()
    {
        base.OnEnable();
        GameManager.instance.commercialList.Add(this);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.instance.commercialList.Remove(this);
    }

    public void SetValues(float moneyRate)
    {
        this.moneyRate = moneyRate;
    }

    public float GetMoney()
    {
        return moneyRate;
    }
}

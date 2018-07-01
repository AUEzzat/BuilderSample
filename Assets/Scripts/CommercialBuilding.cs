using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialBuilding : Building
{
    [HideInInspector]
    public float moneyRate;
    [HideInInspector]
    public int employeesNum;

    protected override void OnEnable()
    {
        base.OnEnable();
        GameManager.instance.commercialList.Add(this);
        GameManager.instance.requiredEmps += employeesNum;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.instance.commercialList.Remove(this);
        GameManager.instance.requiredEmps -= employeesNum;
    }

    public void SetValues(float moneyRate, int employeesNum)
    {
        this.moneyRate = moneyRate;
        this.employeesNum = employeesNum;
    }

    public float GetMoney()
    {
        return moneyRate;
    }
}

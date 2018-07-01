using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    [HideInInspector]
    public float powerRate;
    [HideInInspector]
    public float happinesRate;

    protected virtual void OnEnable()
    {
        GameManager.instance.buildingsList.Add(this);
    }

    protected virtual void OnDisable()
    {
        GameManager.instance.buildingsList.Remove(this);
    }

    public void SetValues(float powerRate, float happinesRate)
    {
        this.powerRate = powerRate;
        this.happinesRate = happinesRate;
    }

    public virtual float GetPower()
    {
        return powerRate;
    }

    public virtual float GetHappiness()
    {
        return happinesRate;
    }
}

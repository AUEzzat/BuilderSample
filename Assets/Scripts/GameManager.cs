using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public List<Building> buildingsList = new List<Building>();
    public List<CommercialBuilding> commercialList = new List<CommercialBuilding>();
    public Text happinesText;
    public Text powerText;
    public Text moneyText;
    public Text inhibitorsText;
    public Text employeesText;
    public Button removeButton;
    float happines;
    float power;
    [HideInInspector]
    public float money;
    [HideInInspector]
    public bool disableButtons = false;
    [HideInInspector]
    public int inhibitors;
    [HideInInspector]
    public int requiredEmps;

    //used to disable buildings with price higher than available money
    [SerializeField]
    List<BuildingType> availableBuildings;

    void Awake()
    {
        instance = this;
        StartCoroutine(CalculateResources());
        money = 50;
        for (int i = 0; i < availableBuildings.Count; i++)
        {
            availableBuildings[i].SetValues();
        }
    }

    private void Update()
    {
        for (int i = 0; i < availableBuildings.Count; i++)
        {
            if (disableButtons || availableBuildings[i].price > money)
            {
                availableBuildings[i].buyingButton.interactable = false;
            }
            else
            {
                availableBuildings[i].buyingButton.interactable = true;
            }
        }
        if (!disableButtons)
        {
            removeButton.interactable = false;
        }
        else
        {
            removeButton.interactable = true;
        }
    }

    IEnumerator CalculateResources()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            float workersToAvailableJobsRatio = requiredEmps > 0 ? (float)inhibitors / requiredEmps : 0;

            workersToAvailableJobsRatio = workersToAvailableJobsRatio > 1 ? 1 : workersToAvailableJobsRatio;

            int employees = (int)(workersToAvailableJobsRatio * requiredEmps);

            for (int i = 0; i < buildingsList.Count; i++)
            {
                happines += buildingsList[i].GetHappiness();
                power += buildingsList[i].GetPower();
            }

            float newMoneySum = 0;

            for (int i = 0; i < commercialList.Count; i++)
                newMoneySum += commercialList[i].GetMoney();

            newMoneySum *= workersToAvailableJobsRatio;

            money += newMoneySum;

            happinesText.text = "Happines: " + happines;
            powerText.text = "Power: " + power;
            moneyText.text = "Money: " + money;
            inhibitorsText.text = "Inhibitors: " + inhibitors;
            employeesText.text = "Employees: " + employees;
        }
    }
}

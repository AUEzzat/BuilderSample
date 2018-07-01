using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    private GridMap grid;
    private Building carriedBuilding;
    private Vector3 finalPosition;

    Ray ray;
    RaycastHit hitInfo;

    bool movingBuilding = false;
    BuildingType latestBuildingType;

    private void Awake()
    {
        grid = FindObjectOfType<GridMap>();
    }

    private void Update()
    {
        GameManager.instance.disableButtons = movingBuilding;

        if (movingBuilding)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.CompareTag("Ground"))
                {
                    MoveBuilding(hitInfo.point);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (movingBuilding)
                {
                    if (hitInfo.collider.CompareTag("Ground"))
                    {
                        carriedBuilding.GetComponent<BoxCollider>().enabled = true;
                        StoppedCarrying();
                    }
                }
                else if (hitInfo.collider.CompareTag("Building"))
                {
                    carriedBuilding = hitInfo.collider.GetComponent<Building>();
                    StartedCarrying();
                }
            }
        }
    }

    void MoveBuilding(Vector3 hitPoint)
    {
        Vector3 newPos = grid.GetNearestPointOnGrid(hitPoint);
        newPos.y = carriedBuilding.transform.position.y;
        carriedBuilding.transform.position = newPos;
    }

    public void CreateNewBuilding(BuildingType buildingType)
    {
        latestBuildingType = buildingType;
        carriedBuilding = Instantiate(buildingType.building);
        StartedCarrying();
    }

    void StartedCarrying()
    {
        carriedBuilding.GetComponent<BoxCollider>().enabled = false;
        movingBuilding = true;
    }

    void StoppedCarrying()
    {
        carriedBuilding = null;
        movingBuilding = false;
        if (latestBuildingType != null)
        {
            GameManager.instance.money -= latestBuildingType.price;
            latestBuildingType = null;
        }
    }

    public void RemoveBuilding()
    {
        if (movingBuilding)
        {
            Destroy(carriedBuilding.gameObject);
            movingBuilding = false;
        }
    }
}

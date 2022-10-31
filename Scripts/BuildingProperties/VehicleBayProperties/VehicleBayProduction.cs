using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class VehicleBayProduction : MonoBehaviour
{
    public Transform vehicleBaySpawnOrigin;
    public GameObject photonTankPrefab;
    public GameObject photonTankSpawnEffect;
    public GameObject ballistaVXPrefab;
    public GameObject ballistaVXSpawnEffect;

    public GameObject buildOptionMenu;
    public GameObject productionMenu;
    public GameObject buildingIndicator;

    public TextMeshProUGUI photonTankCost;
    public int photonTankBuildCount;
    public TextMeshProUGUI photonTankCountText;
    public TextMeshProUGUI ballistaVXCost;
    public int ballistaVXBuildCount;
    public TextMeshProUGUI ballistaVXCountText;

    private float cost;
    private int artifactCost;
    private bool notBuildingUnit = true;
    RaycastHit hit;
    private List<string> buildQueue = new List<string>();

    void Start()
    {
        photonTankCost.text = photonTankPrefab.GetComponent<PhotonTankCost>().photonTankCost.ToString();
        photonTankBuildCount = 0;
        photonTankCountText.text = "";
        ballistaVXCost.text = ballistaVXPrefab.GetComponent<BallistaVXCost>().ballistaVXCost.ToString();
        ballistaVXBuildCount = 0;
        ballistaVXCountText.text = "";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.GetComponent<Health>().health > 0)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.collider.gameObject != gameObject && hit.collider.gameObject.tag == "EnemyTarget") || !BuildToggle.onProductionMenu)
                {
                    buildOptionMenu.SetActive(false);
                    productionMenu.SetActive(false);
                }
                if (BuildToggle.isBuilding == true && !BuildToggle.onPlayerInterface && ((hit.collider.gameObject == gameObject && !BuildToggle.onProductionMenu) || (BuildToggle.onProductionMenu && BuildToggle.currentProductionMenu == productionMenu)))
                {
                    buildOptionMenu.SetActive(true);
                    productionMenu.SetActive(true);
                    BuildToggle.currentProductionMenu = productionMenu;
                }
            }
        }

        if (BuildToggle.isBuilding == false || gameObject.GetComponent<Health>().health < 0 || TimeManager.isPaused)
        {
            buildOptionMenu.SetActive(false);
        }

        if (buildOptionMenu.activeSelf)
        {
            buildingIndicator.SetActive(true);
        }
        else
        {
            buildingIndicator.SetActive(false);
        }

        if (buildQueue.Count != 0)
        {
            ManageProduction();
        }
    }

    public void BuildPhotonTank()
    {
        cost = photonTankPrefab.GetComponent<PhotonTankCost>().photonTankCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            photonTankBuildCount ++;
            photonTankCountText.text = photonTankBuildCount.ToString();
            buildQueue.Add("PhotonTank");
            ResourceManager.credits -= cost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    IEnumerator SpawnPhotonTank()
    {
        notBuildingUnit = false;
        Instantiate(photonTankSpawnEffect, vehicleBaySpawnOrigin.position, vehicleBaySpawnOrigin.rotation);
        yield return new WaitForSeconds(photonTankPrefab.GetComponent<PhotonTankCost>().photonTankProductionTime);
        notBuildingUnit = true;
        photonTankBuildCount --;
        if (photonTankBuildCount == 0)
        {
            photonTankCountText.text = "";
        }
        else
        {
            photonTankCountText.text = photonTankBuildCount.ToString();
        }
        Instantiate(photonTankPrefab, vehicleBaySpawnOrigin.position, vehicleBaySpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    public void BuildBallistaVX()
    {
        cost = ballistaVXPrefab.GetComponent<BallistaVXCost>().ballistaVXCost;
        if (cost <= ResourceManager.credits && !ResourceManager.insufficientWorkers)
        {
            ballistaVXBuildCount ++;
            ballistaVXCountText.text = ballistaVXBuildCount.ToString();
            buildQueue.Add("BallistaVX");
            ResourceManager.credits -= cost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    IEnumerator SpawnBallistaVX()
    {
        notBuildingUnit = false;
        Instantiate(ballistaVXSpawnEffect, vehicleBaySpawnOrigin.position, vehicleBaySpawnOrigin.rotation);
        yield return new WaitForSeconds(ballistaVXPrefab.GetComponent<BallistaVXCost>().ballistaVXProductionTime);
        notBuildingUnit = true;
        ballistaVXBuildCount --;
        if (ballistaVXBuildCount == 0)
        {
            ballistaVXCountText.text = "";
        }
        else
        {
            ballistaVXCountText.text = ballistaVXBuildCount.ToString();
        }
        Instantiate(ballistaVXPrefab, vehicleBaySpawnOrigin.position, vehicleBaySpawnOrigin.rotation);
        buildQueue.RemoveAt(0);
    }

    void ManageProduction()
    {
        if (buildQueue[0] == "PhotonTank" && notBuildingUnit)
        {
            StartCoroutine(SpawnPhotonTank());
        }
        if (buildQueue[0] == "BallistaVX" && notBuildingUnit)
        {
            StartCoroutine(SpawnBallistaVX());
        }
    }

    public void CloseProductionMenu()
    {
        BuildToggle.currentProductionMenu = null;
    }
}
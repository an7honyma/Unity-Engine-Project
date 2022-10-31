using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ArtifactGeneratorProduction : MonoBehaviour
{
    public GameObject buildOptionMenu;
    public GameObject productionMenu;
    public GameObject buildingIndicator;
    public GameObject artifactOneVisual;
    public GameObject artifactTwoVisual;
    public GameObject artifactThreeVisual;

    private int artifactOneProductionCost = 10;
    private int artifactTwoProductionCost = 10;
    private int artifactThreeProductionCost = 10;
    public TextMeshProUGUI artifactOneProduceCost;
    public TextMeshProUGUI artifactTwoProduceCost;
    public TextMeshProUGUI artifactThreeProduceCost;
    private string artifactProduction = null;
    private float productionRate = 10f;

    private int artifactCost;
    RaycastHit hit;

    void Awake()
    {
        artifactOneVisual.SetActive(false);
        artifactTwoVisual.SetActive(false);
        artifactThreeVisual.SetActive(false);
    }
    void Start()
    {
        artifactOneProduceCost.text = artifactOneProductionCost.ToString();
        artifactTwoProduceCost.text = artifactTwoProductionCost.ToString();
        artifactThreeProduceCost.text = artifactThreeProductionCost.ToString();
        InvokeRepeating("ProduceArtifact", productionRate, productionRate);
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
    }

    public void SelectArtifactOne()
    {
        artifactCost = artifactOneProductionCost;
        if (artifactCost <= ResourceManager.artifactOneCount && !ResourceManager.insufficientWorkers)
        {
            artifactOneVisual.SetActive(true);
            artifactTwoVisual.SetActive(false);
            artifactThreeVisual.SetActive(false);
            artifactProduction = "ArtifactOne";
            ResourceManager.artifactOneCount -= artifactCost;
        }
        else if (artifactCost > ResourceManager.artifactOneCount)
        {
            NotificationManager.insufficientArtifacts = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    public void SelectArtifactTwo()
    {
        artifactCost = artifactTwoProductionCost;
        if (artifactCost <= ResourceManager.artifactTwoCount && !ResourceManager.insufficientWorkers)
        {
            artifactTwoVisual.SetActive(true);
            artifactOneVisual.SetActive(false);
            artifactThreeVisual.SetActive(false);
            artifactProduction = "ArtifactTwo";
            ResourceManager.artifactTwoCount -= artifactCost;
        }
        else if (artifactCost > ResourceManager.artifactTwoCount)
        {
            NotificationManager.insufficientArtifacts = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    public void SelectArtifactThree()
    {
        artifactCost = artifactThreeProductionCost;
        if (artifactCost <= ResourceManager.artifactThreeCount && !ResourceManager.insufficientWorkers)
        {
            artifactThreeVisual.SetActive(true);
            artifactOneVisual.SetActive(false);
            artifactTwoVisual.SetActive(false);
            artifactProduction = "ArtifactThree";
            ResourceManager.artifactThreeCount -= artifactCost;
        }
        else if (artifactCost > ResourceManager.artifactThreeCount)
        {
            NotificationManager.insufficientArtifacts = true;
        }
        else if (ResourceManager.insufficientWorkers)
        {
            NotificationManager.insufficientWorkers = true;
        }
    }

    void ProduceArtifact()
    {
        if (ResourceManager.excessPower > 0)
        {
            if (artifactProduction == "ArtifactOne")
            {
                ResourceManager.artifactOneCount ++;
            }
            else if (artifactProduction == "ArtifactTwo")
            {
                ResourceManager.artifactTwoCount ++;
            }
            else if (artifactProduction == "ArtifactThree")
            {
                ResourceManager.artifactThreeCount ++;
            }
        }
    }
}
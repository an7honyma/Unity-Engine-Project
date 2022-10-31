using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlatformCannonRepair : MonoBehaviour
{
    public GameObject buildOptionMenu;
    public GameObject productionMenu;
    public GameObject buildingIndicator;
    public TextMeshProUGUI platformCannonRepairCost;
    private float cost;
    private float platformCannonRepairPower;
    RaycastHit hit;

    Renderer rend;
    public Material[] optionMaterials;
    public Material[] materials;
    public AudioSource platformCannonRepair;
    public AudioSource platformCannonOnline;

    void Start()
    {
        platformCannonRepairPower = gameObject.GetComponent<PlatformCannonNeeds>().platformCannonPower;
        cost = gameObject.GetComponent<PlatformCannonNeeds>().platformCannonRepairCost;
        platformCannonRepairCost.text = gameObject.GetComponent<PlatformCannonNeeds>().platformCannonRepairCost.ToString();
        rend = gameObject.GetComponent<Renderer>();
        materials = rend.materials;
        materials[2] = optionMaterials[1];
        rend.materials = materials;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.collider.gameObject != gameObject && (hit.collider.gameObject.tag == "EnemyTarget" || hit.collider.gameObject.tag == "Untagged")) || !BuildToggle.onProductionMenu)
                {
                    buildOptionMenu.SetActive(false);
                    productionMenu.SetActive(false);
                }
                if (BuildToggle.isBuilding == true && ((hit.collider.gameObject == gameObject && !BuildToggle.onProductionMenu) || (BuildToggle.onProductionMenu && BuildToggle.currentProductionMenu == productionMenu)))
                {
                    buildOptionMenu.SetActive(true);
                    productionMenu.SetActive(true);
                    BuildToggle.currentProductionMenu = productionMenu;
                }
            }
        }

        if (BuildToggle.isBuilding == false || TimeManager.isPaused)
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

    public void RepairPlatformCannon()
    {
        if (cost <= ResourceManager.credits && platformCannonRepairPower <= ResourceManager.excessPower && gameObject.GetComponent<PlatformCannonHealth>().isDead)
        {
            platformCannonRepair.Play();
            platformCannonOnline.Play();
            gameObject.GetComponent<PlatformCannonHealth>().health = gameObject.GetComponent<PlatformCannonHealth>().maxHealth;
            gameObject.GetComponent<PlatformCannon>().enabled = true;
            gameObject.GetComponent<PlatformCannonHealth>().isDead = false;
            materials[2] = optionMaterials[0];
            rend.materials = materials;
            gameObject.tag = "EnemyTarget";
            ResourceManager.excessPower -= platformCannonRepairPower;
            ResourceManager.credits -= cost;
        }
        else if (cost > ResourceManager.credits)
        {
            NotificationManager.insufficientCredits = true;
        }
        else if (platformCannonRepairPower > ResourceManager.excessPower)
        {
            NotificationManager.insufficientPower = true;
        }
    }

    public void CloseProductionMenu()
    {
        BuildToggle.currentProductionMenu = null;
    }

    public void DeactivatePlatformCannonMaterials()
    {
        materials[2] = optionMaterials[1];
        rend.materials = materials;
    }
}
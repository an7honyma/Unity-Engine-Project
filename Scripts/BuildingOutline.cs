using UnityEngine;
using UnityEngine.UI;

public class BuildingOutline : MonoBehaviour
{
    RaycastHit hit;
    public string buildingName;
    public Sprite buildingImage;
    private bool isSelected = false;

    void Update()
    {
        if (BuildToggle.isBuilding)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50000f))
            {
                if (hit.transform.gameObject == gameObject && Input.GetMouseButtonDown(0) && !BuildToggle.onProductionMenu && !BuildToggle.onPlayerInterface)
                {
                    gameObject.GetComponent<Outline>().enabled = true;
                    BuildingStatusPanel.buildingName = buildingName;
                    BuildingStatusPanel.buildingImage = buildingImage;
                    BuildingStatusPanel.buildingHealth = gameObject.GetComponent<Health>().health;
                    isSelected = true;
                }
                else if (hit.transform.gameObject.tag != "EnemyTarget" && Input.GetMouseButtonDown(0))
                {
                    gameObject.GetComponent<Outline>().enabled = false;
                    BuildingStatusPanel.buildingName = null;
                    isSelected = false;
                }
                else if (hit.transform.gameObject != gameObject && Input.GetMouseButtonDown(0))
                {
                    gameObject.GetComponent<Outline>().enabled = false;
                    isSelected = false;
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                gameObject.GetComponent<Outline>().enabled = false;
                BuildingStatusPanel.buildingName = null;
                isSelected = false;
            }

            if (isSelected)
            {
                BuildingStatusPanel.buildingHealth = gameObject.GetComponent<Health>().health;
            }
        }
        else
        {
            gameObject.GetComponent<Outline>().enabled = false;
            BuildingStatusPanel.buildingName = null;
            isSelected = false;
        }
    }

    void OnDestroy()
    {
        BuildingStatusPanel.buildingName = null;
    }
}

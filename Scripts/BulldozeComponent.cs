using UnityEngine;

public class BulldozeComponent : MonoBehaviour
{
    public string buildingName;
    public Sprite buildingImage;
    RaycastHit hit;

    void Update()
    {
        if (BuildToggle.bulldozeMode && Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BulldozeComponent bulldozable = hit.transform.gameObject.GetComponent<BulldozeComponent>();
                if (hit.collider.gameObject == gameObject && BuildToggle.onProductionMenu == false)
                {
                    BuildToggle.buildingToDelete = gameObject;
                    BuildToggle.buildingToDeleteImage = buildingImage;
                    BuildToggle.buildingToDeleteName = buildingName;
                    BuildToggle.setBulldozeDetails = false;
                }
                else if (bulldozable == null && BuildToggle.onProductionMenu == false)
                {
                    BuildToggle.buildingToDelete = null;
                }
            }
        }
    }
}

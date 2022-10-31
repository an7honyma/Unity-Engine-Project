using UnityEngine;
using System;

public class Blueprints : MonoBehaviour
{
    RaycastHit hit;
    public GameObject buildingPrefab;
    private int cellSize = 1;
    private bool isColliding = false;

    public void Start()
    {
        Ray ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50000.0f, (13)))
        {
            transform.position = hit.point;
        }
    }

    public void Update()
    {
        Ray ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 13)))
        {
            transform.position = new Vector3((float)Math.Round(hit.point.x/cellSize) * cellSize, (float)Math.Round(hit.point.y), (float)Math.Round(hit.point.z/cellSize) * cellSize);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, -90f, 0f, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 90f, 0f, Space.World);
        }
        
        if (Input.GetMouseButton(0) && !isColliding && !BuildToggle.onProductionMenu && !BuildToggle.onPlayerInterface)
        {
            PlaceBuilding();
        }
        else if (Input.GetMouseButton(0) && BuildToggle.onPlayerInterface)
        {
            Destroy(gameObject);
        }
        else if (Input.GetMouseButton(0) && isColliding)
        {
            NotificationManager.cannotBuildHere = true;
            Destroy(gameObject);
        }
        else if (Input.GetMouseButton(1))
        {
            Destroy(gameObject);
        }

        if (!BuildToggle.isBuilding)
        {
            Destroy(gameObject);
        }
    }

    public virtual void PlaceBuilding()
    {
        return;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnemyTarget" || other.gameObject.tag == "Environment")
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isColliding = false;
    }

}

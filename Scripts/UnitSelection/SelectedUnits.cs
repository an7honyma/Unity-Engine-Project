using System.Collections.Generic;
using UnityEngine;

public class SelectedUnits : MonoBehaviour
{
    public static bool selectUnits = false;
    public static bool onEnemyUnit = false;
    public static List<GameObject> selectedUnits = new List<GameObject>();
    public AudioSource gameMenuButton;

    public void addSelected(GameObject unit)
    {
        if (!(selectedUnits.Contains(unit)))
        {
            selectedUnits.Add(unit);
            unit.GetComponent<Outline>().enabled = true;
        }
    }

    public void deselect(GameObject unit)
    {
        unit.GetComponent<Outline>().enabled = false;
        selectedUnits.Remove(unit);
    }

    public void deselectAll()
    {
        foreach(GameObject unit in selectedUnits)
        {
            if (unit != null)
            {
                unit.GetComponent<Outline>().enabled = false;
            }
        }
        selectedUnits.Clear();
    }

    void Start()
    {
        selectUnits = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !selectUnits)
        {
            gameMenuButton.Play();
            selectUnits = true;
            BuildToggle.isBuilding = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && selectUnits)
        {
            gameMenuButton.Play();
            selectUnits = false;
        }
    }

    public void ToggleUnitSelection()
    {
        if (!selectUnits)
        {
            gameMenuButton.Play();
            selectUnits = true;
        }
        else if (selectUnits)
        {
            gameMenuButton.Play();
            selectUnits = false;
        }
    }
}
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
 
public class BuildButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject infoPanel;
    public GameObject blueprint;
    public AudioSource interfaceMenuButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        infoPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        infoPanel.SetActive(false);
    }

    public void SpawnBlueprint()
    {
        interfaceMenuButton.Play();
        Instantiate(blueprint);
    }

}
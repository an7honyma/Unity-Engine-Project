using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AvatarDroneButton : MonoBehaviour
{
    private Transform avatarOrigin;
    public GameObject dronePrefab;
    private bool buttonDisabled = false;
    public float cooldownTime = 20f;

    public void DeployDrone()
    {
        if (!buttonDisabled)
        {
            float requiredEnergy = dronePrefab.GetComponent<DroneMovement>().requiredEnergy;
            if (AvatarRequirements.energy > requiredEnergy)
            {
                GameObject avatar = GameObject.FindGameObjectWithTag("AvatarFocus");
                Instantiate(dronePrefab, avatar.transform.position, avatar.transform.rotation);
                StartCoroutine(DisableButton());
                AvatarRequirements.energy -= requiredEnergy;
            }
        }
    }

    IEnumerator DisableButton()
    {
        buttonDisabled = true;
        gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(dronePrefab.GetComponent<DroneMovement>().lifetime + cooldownTime);
        buttonDisabled = false;
        gameObject.GetComponent<Button>().interactable = true;
    }
}

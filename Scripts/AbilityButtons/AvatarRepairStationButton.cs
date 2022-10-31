using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AvatarRepairStationButton : MonoBehaviour
{
    public Transform avatarDeployOrigin;
    public GameObject repairStationPrefab;
    private bool buttonDisabled = false;
    private float requiredEnergy = 400f;
    public float cooldownTime = 40f;

    public void DeployRepairStation()
    {
        if (!buttonDisabled)
        {
            if (AvatarRequirements.energy > requiredEnergy)
            {
                Instantiate(repairStationPrefab, avatarDeployOrigin.position, Quaternion.identity);
                StartCoroutine(DisableButton());
                AvatarRequirements.energy -= requiredEnergy;
            }
        }
    }

    IEnumerator DisableButton()
    {
        buttonDisabled = true;
        gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(cooldownTime);
        buttonDisabled = false;
        gameObject.GetComponent<Button>().interactable = true;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AvatarShieldButton : MonoBehaviour
{
    private Transform avatarOrigin;
    public GameObject shieldPrefab;
    private bool buttonDisabled = false;
    public float cooldownTime = 10f;

    public void DeployShield()
    {
        if (!buttonDisabled)
        {
            float requiredEnergy = shieldPrefab.GetComponent<AvatarShield>().requiredEnergy;
            if (AvatarRequirements.energy > requiredEnergy)
            {
                GameObject avatar = GameObject.FindGameObjectWithTag("AvatarFocus");
                Instantiate(shieldPrefab, avatar.transform.position, avatar.transform.rotation);
                StartCoroutine(DisableButton());
                AvatarRequirements.energy -= requiredEnergy;
            }
        }
    }

    IEnumerator DisableButton()
    {
        buttonDisabled = true;
        gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(shieldPrefab.GetComponent<AvatarShield>().lifetime + cooldownTime);
        buttonDisabled = false;
        gameObject.GetComponent<Button>().interactable = true;
    }
}

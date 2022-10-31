using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VFX;

public class AvatarTractorBeamButton : MonoBehaviour
{
    private bool buttonDisabled = false;
    private float requiredEnergy = 500f;
    private float lifetime = 5f;
    public float cooldownTime = 30f;

    public void DeployTractorBeam()
    {
        if (!buttonDisabled)
        {
            if (AvatarRequirements.energy > requiredEnergy)
            {
                AvatarAbilities.tractorBeamEnabled = true;
                StartCoroutine(DisableButton());
                AvatarRequirements.energy -= requiredEnergy;
            }
        }
    }

    IEnumerator DisableButton()
    {
        buttonDisabled = true;
        gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(lifetime * AvatarAbilities.tractorBeamLevel);
        AvatarAbilities.tractorBeamEnabled = false;
        yield return new WaitForSeconds(cooldownTime);
        buttonDisabled = false;
        gameObject.GetComponent<Button>().interactable = true;
    }
}

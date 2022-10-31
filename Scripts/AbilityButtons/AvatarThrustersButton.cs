using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.VFX;

public class AvatarThrustersButton : MonoBehaviour
{
    private Transform avatarOrigin;
    public GameObject avatar;
    private bool buttonDisabled = false;
    private float requiredEnergy = 300f;
    private float lifetime = 10f;
    public float cooldownTime = 30f;
    public GameObject thrustersEffect1;
    public GameObject thrustersEffect2;
    public GameObject thrustersEffect3;
    public GameObject thrustersEffect4;

    void Start()
    {
        thrustersEffect1.SetActive(false);
        thrustersEffect2.SetActive(false);
        thrustersEffect3.SetActive(false);
        thrustersEffect4.SetActive(false);
    }

    public void DeployThrusters()
    {
        if (!buttonDisabled)
        {
            if (AvatarRequirements.energy > requiredEnergy)
            {
                avatar.GetComponent<PlayerMovement>().speed += 5f;
                thrustersEffect1.SetActive(true);
                thrustersEffect2.SetActive(true);
                thrustersEffect3.SetActive(true);
                thrustersEffect4.SetActive(true);
                StartCoroutine(DisableButton());
                AvatarRequirements.energy -= requiredEnergy;
            }
        }
    }

    IEnumerator DisableButton()
    {
        buttonDisabled = true;
        gameObject.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(lifetime * AvatarAbilities.thrustersLevel);
        avatar.GetComponent<PlayerMovement>().speed -= 5f;
        thrustersEffect1.GetComponent<VisualEffect>().Stop();
        thrustersEffect2.GetComponent<VisualEffect>().Stop();
        thrustersEffect3.GetComponent<VisualEffect>().Stop();
        thrustersEffect4.GetComponent<VisualEffect>().Stop();
        yield return new WaitForSeconds(cooldownTime);
        thrustersEffect1.SetActive(false);
        thrustersEffect2.SetActive(false);
        thrustersEffect3.SetActive(false);
        thrustersEffect4.SetActive(false);
        buttonDisabled = false;
        gameObject.GetComponent<Button>().interactable = true;
    }
}

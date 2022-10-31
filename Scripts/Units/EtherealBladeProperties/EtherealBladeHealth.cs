using UnityEngine;
using System.Collections;

public class EtherealBladeHealth : Health
{
    Renderer rend;
    private Material[] defaultMaterials;
    private Material[] modifiedmaterials;
    public Material cloakingMaterial;
    private bool cloakActivated = false;

    public EtherealBladeHealth()
    {
        maxHealth = 1250f;
        health = 1250f;
    }

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        defaultMaterials = rend.materials;
        modifiedmaterials = rend.materials;
    }
    void Update()
    {
        if (health/maxHealth <= 0.5 && cloakActivated == false)
        {
            StartCoroutine(ActivateCloakingField());
        }
        if (health/maxHealth >= 0.75)
        {
            cloakActivated = false;
        }
    }

    IEnumerator ActivateCloakingField()
    {
        cloakActivated = true;
        gameObject.tag = "Cloaked";
        for (int i  = 0; i < modifiedmaterials.Length; i++)
        {
            modifiedmaterials[i] = cloakingMaterial;
        }
        rend.materials = modifiedmaterials;
        yield return new WaitForSeconds(10);
        gameObject.tag = "Ship";
        rend.materials = defaultMaterials;
    }
}
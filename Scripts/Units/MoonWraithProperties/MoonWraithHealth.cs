using UnityEngine;
using System.Collections;

public class MoonWraithHealth : Health
{
    Renderer rend;
    private Material[] defaultMaterials;
    private Material[] modifiedmaterials;
    public Material cloakingMaterial;
    private bool cloakActivated = false;

    public MoonWraithHealth()
    {
        maxHealth = 2500f;
        health = 2500f;
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
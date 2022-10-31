using UnityEngine;
using System.Collections;

public class PhantomHealth : EnemyHealth
{
    private float maxHealth;
    Renderer rend;
    private Material[] defaultMaterials;
    private Material[] modifiedmaterials;
    public Material cloakingMaterial;
    private bool cloakActivated = false;
    public GameObject artifactPrefab;

    public PhantomHealth()
    {
        enemyHealth = 1500f;
    }

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        defaultMaterials = rend.materials;
        modifiedmaterials = rend.materials;
        maxHealth = enemyHealth;
    }
    void Update()
    {
        if (enemyHealth/maxHealth <= 0.5 && cloakActivated == false)
        {
            StartCoroutine(ActivateCloakingField());
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
        gameObject.tag = "Enemy";
        rend.materials = defaultMaterials;
    }

    public override void DropItem()
    {
        Instantiate(artifactPrefab, gameObject.transform.position, Quaternion.identity);
    }
}

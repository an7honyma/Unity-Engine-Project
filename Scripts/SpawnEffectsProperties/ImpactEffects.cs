using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class ImpactEffects : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(StopEffect());
        Destroy(gameObject, 2f);
    }

    IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<VisualEffect>().Stop();
    }
}
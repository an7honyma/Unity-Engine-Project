using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class ExplosionEffect : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    IEnumerator StopEffect()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<VisualEffect>().Stop();
    }
}

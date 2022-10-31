using UnityEngine;

public class PhaseOutShaderController : MonoBehaviour
{
    private Material[] mats;
    Renderer rend;
    private float progress = 0f;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        mats = GetComponent<MeshRenderer>().materials;
        foreach (Material material in mats)
        {
            material.SetFloat("_Progression", 0);
        }
    }

    void Update()
    {
        foreach (Material material in mats)
        {
            material.SetFloat("_FadeStartTime", progress + 0.01f);
        }
        rend.materials = mats;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class ArtifactThree : MonoBehaviour
{

    public GameObject artifactFlash;

    void Start()
    {
        Destroy(gameObject, 60f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(artifactFlash, transform.position, transform.rotation);
        Destroy(gameObject);
        ResourceManager.artifactThreeCount ++;
        ResourceManager.UpdateResources();
    }
}
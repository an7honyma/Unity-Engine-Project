using UnityEngine;

public class AvatarShield : MonoBehaviour
{
    private Transform avatarOrigin;
    public float lifetime = 10f;
    public float requiredEnergy = 150f;

    void Start()
    {
        Destroy(gameObject, lifetime * AvatarAbilities.shieldLevel);
    }
   
    void LateUpdate()
    {
        GameObject avatar = GameObject.FindGameObjectWithTag("AvatarFocus");
        transform.position = avatar.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelayTime = 0.3f;
    [SerializeField] Color32 hasPackageColor;
    [SerializeField] Color32 noPackageColor;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("I picked up the : " + other.gameObject.name);
            hasPackage = true;
            Destroy(other.gameObject, destroyDelayTime);
            spriteRenderer.color = hasPackageColor;
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("I delivered package to : " + other.gameObject.name);
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}

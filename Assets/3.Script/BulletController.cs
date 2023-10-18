using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bullet_r;

    private void Start()
    {
        //bullet_r = GetComponent<Rigidbody>();

        if (TryGetComponent(out bullet_r))
        {
            bullet_r.velocity = transform.forward * speed;
        }
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.TryGetComponent(out PlayerController controller))
            {
                Debug.Log("ºÒ·¿¾Ø µé¾î¿À³ª??");
                controller.Die();
            }
        }
    }
}

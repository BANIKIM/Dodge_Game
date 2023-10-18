using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [Range(10f,100f)]//�����̴� â ����
    [SerializeField] private float Rotate_speed = 60f;

    private void Update()
    {
        transform.Rotate(0f, Rotate_speed*Time.deltaTime, 0f);
    }

}

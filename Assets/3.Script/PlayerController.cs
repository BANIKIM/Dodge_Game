using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody Player_r;
    [SerializeField] private float speed = 8f;

    private void Start()
    {
        Player_r = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //AddForce vs Velocity
        /*
         * AddForce ���� ��� �������� ���� �����Ͽ� �ӵ��� ������Ű��,
         * �̵�, ����, ����, ������ ����޴� �޼���(�Ѿ� ���� ��)
         * 
         * Velocity�� �ӵ��� ��Ÿ���ִ� ����������, ���� ������ �����ϰ� �־��� �ӵ��� �̵�
         * 
         * 
         */
        /* if (Input.GetKey(KeyCode.W))
         {
             Player_r.AddForce(0, 0, speed);
         }
         if(Input.GetKey(KeyCode.S))
         {
             Player_r.AddForce(0, 0, -speed);
         }
         if (Input.GetKey(KeyCode.A))
         {
             Player_r.AddForce(-speed, 0, 0);
         }
         if (Input.GetKey(KeyCode.D))
         {
             Player_r.AddForce(speed, 0, 0);
         }*/

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 value = new Vector3(x, 0f, z) * speed;
        Player_r.velocity = value;


    }


    public void Die()
    {
        Debug.Log("Dieȣ��!");
        gameObject.SetActive(false);
        if(GameManager.FindObjectOfType<GameManager>().TryGetComponent(out GameManager gm))
        {
            Debug.Log("���� �ȵ�� ���µ�?");
            gm.EndGame();
        }
    }


}

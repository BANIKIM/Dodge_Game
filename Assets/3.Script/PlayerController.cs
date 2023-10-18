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
         * AddForce 같은 경우 가해지는 힘을 누적하여 속도를 증가시키고,
         * 이동, 물리, 질량, 관성을 영향받는 메서드(총알 같은 것)
         * 
         * Velocity는 속도를 나타내주는 변수임으로, 질량 관성은 무시하고 주어진 속도로 이동
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
        Debug.Log("Die호출!");
        gameObject.SetActive(false);
        if(GameManager.FindObjectOfType<GameManager>().TryGetComponent(out GameManager gm))
        {
            Debug.Log("여길 안들어 오는듯?");
            gm.EndGame();
        }
    }


}

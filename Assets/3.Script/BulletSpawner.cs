using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    [SerializeField] private GameObject Bullet;

    [SerializeField] private float SpawnRate_Min = 0.5f;
    [SerializeField] private float SpawnRate_Max = 3f;
    [SerializeField] private float Rotate_speed = 60f;

    public Transform Target; //Player
    private float SpawnRate;
    private float TimeAfterSpawn;

    RaycastHit hit;


    private void Start()
    {
        TimeAfterSpawn = 0;
        SpawnRate = Random.Range(SpawnRate_Min, SpawnRate_Max);
        Target = FindObjectOfType<PlayerController>().transform;
    }
    private void Update()
    {
        /*  TimeAfterSpawn += Time.deltaTime;
          if (TimeAfterSpawn >= SpawnRate)
          {
              TimeAfterSpawn = 0;
              GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);

              bullet.transform.LookAt(Target);

              SpawnRate = Random.Range(SpawnRate_Min, SpawnRate_Max);
          }*/

        TimeAfterSpawn += Time.deltaTime;
        transform.Rotate(0f, Rotate_speed * Time.deltaTime, 0f);

        Debug.DrawRay(transform.position, transform.forward * 9f, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward,9f, LayerMask.GetMask("Player"))&& TimeAfterSpawn >= SpawnRate)
        {
            Debug.Log("맞음");
            TimeAfterSpawn = 0;
            GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
            SpawnRate = Random.Range(SpawnRate_Min, SpawnRate_Max);

        }
        else if(Physics.Raycast(transform.position, transform.forward, 9f, LayerMask.GetMask("Wall")))
        {
            Debug.Log("반대로 돌자");
            Rotate_speed= Rotate_speed *- 1;

        }


    }


}

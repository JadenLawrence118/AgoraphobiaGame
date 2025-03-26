using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;
    [SerializeField] private int minimumCooldown = 2;
    [SerializeField] private float YRotationOffset = 0;
    [SerializeField] private Vector3 spawnedDirection;
    void Start()
    {
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        yield return new WaitForSeconds(Random.Range(minimumCooldown, 10));
        int carIndex = Random.Range(0, cars.Length - 1);
        GameObject spawnedCar =  Instantiate(cars[carIndex], gameObject.transform.position, cars[carIndex].transform.rotation);
        spawnedCar.GetComponent<CarMovement>().moveDirection = spawnedDirection;
        spawnedCar.transform.rotation = new Quaternion(spawnedCar.transform.rotation.x, spawnedCar.transform.rotation.y + YRotationOffset, spawnedCar.transform.rotation.z, spawnedCar.transform.rotation.w);
        StartCoroutine(SpawnCar());
    }
}

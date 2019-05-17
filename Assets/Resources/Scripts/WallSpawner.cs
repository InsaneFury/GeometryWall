using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public List<GameObject> wallsSpawned;
    public GameObject wall;
    public int amountOfWalls = 2;
    public Vector3 startPosition;
    public Vector3 resetPosition;
    public float spaceBetween = 40f;
    public float moveSpeed = 1f;
    void Start()
    {
        wallsSpawned = new List<GameObject>();
        for (int i = 0; i < amountOfWalls; i++)
        {
            wallsSpawned.Add(Instantiate(wall,wall.transform.position,Quaternion.Euler(new Vector3(0f,90f,90f))));
            wallsSpawned[i].SetActive(true);
            if (i == 0)
            {
                wallsSpawned[i].transform.localPosition = startPosition;
            }
            else
            {
                wallsSpawned[i].transform.localPosition = new Vector3(wallsSpawned[i].transform.localPosition.x,
                                                                 wallsSpawned[i].transform.localPosition.y,
                                                                 wallsSpawned[i].transform.localPosition.z + spaceBetween);
            }
           
        }
    }

    void Update()
    {
        foreach (GameObject go in wallsSpawned)
        {
            go.transform.Translate(Vector3.up * -moveSpeed * Time.deltaTime);
            if (go.transform.position.z <= resetPosition.z)
            {
                go.transform.position = startPosition;
            }
        }
    }
}

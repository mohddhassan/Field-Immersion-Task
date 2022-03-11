using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] playerPrefab;
    
    void Start()
    {
        Instantiate(playerPrefab[0], new Vector3(8, 0.5f, 34), Quaternion.Euler(0, -90, 0));        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerPrefab[1], playerPrefab[0].transform.position, playerPrefab[0].transform.rotation);
            Destroy(GameObject.FindGameObjectWithTag("Player1"));

        }
        
    }

   
}


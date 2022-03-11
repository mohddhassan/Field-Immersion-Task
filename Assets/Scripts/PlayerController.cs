using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public GameObject[] playerPrefab;
    private Rigidbody playerRb;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20f;
    public float turnSpeed = 300f;
    public Transform playerTransform;
    private bool firstPlayer = true;
    private bool secondPlayer = false;
    private bool thirdPlayer = false;
    void Start()
    {
        
        playerRb = gameObject.GetComponent<Rigidbody>();
        playerTransform = gameObject.GetComponent<Transform>();
        
    }

    void Update()
    {
        PlayerMovement();
        PlayerSize();
    }

    public void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.left * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontalInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EmptyCollisionDetector"))
        {
            playerRb.AddForce(Vector3.back * 30, ForceMode.Impulse);
        }          
        
            
    }

    public void PlayerSize()
    {
        if (Input.GetKeyDown(KeyCode.Space) && firstPlayer && !secondPlayer && !thirdPlayer)
        {
            Debug.Log("1space pressed");
            playerTransform.localScale = new Vector3(0.278539985f, 1, 0.198476061f);
            firstPlayer = false;
            secondPlayer = true;
            thirdPlayer = false;

        }

        else if (Input.GetKeyDown(KeyCode.Space) && secondPlayer && !firstPlayer && !thirdPlayer)
        {
            Debug.Log("2space pressed");
            playerTransform.localScale = new Vector3(0.278539985f, 0.256350011f, 1.01339996f);
            firstPlayer = false;
            secondPlayer = false;
            thirdPlayer = true;

        }

        else if (Input.GetKeyDown(KeyCode.Space) && thirdPlayer && !firstPlayer && !secondPlayer)
        {
            Debug.Log("3space pressed");
            playerTransform.localScale = new Vector3(0.191440538f, 0.899878502f, 0.687300026f);            
            firstPlayer = true;
            secondPlayer = false;
            thirdPlayer = false;
        }




    }
}


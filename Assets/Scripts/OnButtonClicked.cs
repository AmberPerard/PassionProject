using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonClicked : MonoBehaviour
{
    public GameObject foodItem;
    private GameObject spawnedObject;
    public GameObject arCameraObject;
    public float distance;
    private Rigidbody rb;
    private GameObject[] Player;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFoodItemClicked()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        if (Player.Length > 0)
        {
            spawnedObject = Instantiate(foodItem, Camera.main.transform.position + Camera.main.transform.forward * distance, Camera.main.transform.rotation);
            rb = spawnedObject.GetComponent<Rigidbody>();
            rb.useGravity = false;
            spawnedObject.transform.Rotate(Vector3.left * 90);
            Debug.Log("You clicked to spawn food");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class SelectObject : MonoBehaviour
{

    [SerializeField]
    private Camera arCamera;


    private Vector2 touchPosition = default;

    private ARRaycastManager arRaycastManager;

    private GameObject SelectedObject;
    private GameObject[] Player;


    private Rigidbody rb;

    private MovingFood foodObject;

    private Animator anim;

    private int dancingHash = Animator.StringToHash("IsHit");


    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;


                if (Physics.Raycast(ray, out hitObject))
                {

                    SelectedObject = hitObject.collider.gameObject;
                 

                    if (SelectedObject.tag == "Player")
                    {
                        anim = SelectedObject.GetComponentInParent<Animator>();
                        anim.SetTrigger(dancingHash);
                        Debug.Log("You clicked on the Cactus");

                    }
                    if (SelectedObject.tag == "Food")
                    {
                        Player = GameObject.FindGameObjectsWithTag("Player");
                  

                        if (Player.Length > 0)
                        {
                          
                            foodObject = SelectedObject.GetComponent<MovingFood>();
                            foodObject.moving = true;
                        }
                        Debug.Log("You clicked on the Food");
                    }
                }
            }
        }
    }
}
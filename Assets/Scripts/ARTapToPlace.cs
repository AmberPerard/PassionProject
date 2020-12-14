using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject placementIndicator;
    public GameObject nameOverlay;

    private GameObject objectToPlace;
    private ARRaycastManager aRRaycastManager;
    private Pose PlacementPose;
    private bool placementPoseIsValid = false;
    private GameObject spawnedObject;
    private string characterName;
    private int SpawnObjectPost;

    public GameObject[] SpawnObjects;
    int index;


    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        nameOverlay.SetActive(false);
        characterName = PlayerPrefs.GetString("User");
        SpawnObjectPost = PlayerPrefs.GetInt("SpawnObjectPos");
    }

    void Update()
    {
        //first time
        if (SpawnObjectPost < 0)
        {

            index = Random.Range(0, SpawnObjects.Length);
            objectToPlace = SpawnObjects[index];
            Debug.Log(objectToPlace.name);
            PlayerPrefs.SetInt("SpawnObjectPos", index);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt("SpawnObjectPos"));
         }
        else
        {
        
            objectToPlace = SpawnObjects[SpawnObjectPost];
        }

        if (spawnedObject == null)
        {

            UpdatePlacementPose();
            UpdatePlacementIndicator();

            if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //second time
                if (SpawnObjectPost < 0)
                {

                    index = Random.Range(0, SpawnObjects.Length);
                    objectToPlace = SpawnObjects[index];
                    Debug.Log(objectToPlace.name);
                    PlayerPrefs.SetInt("SpawnObjectPos", index);
                    PlayerPrefs.Save();
                    Debug.Log(PlayerPrefs.GetInt("SpawnObjectPos"));
                }
                else
                {

                    objectToPlace = SpawnObjects[SpawnObjectPost];
                }

                spawnedObject = Instantiate(objectToPlace, PlacementPose.position, PlacementPose.rotation);
                spawnedObject.transform.LookAt(Camera.main.transform);
                if (string.IsNullOrEmpty(characterName) == true)
                {
                    nameOverlay.SetActive(true);
                }
            }
        }
        else
        {
            placementIndicator.SetActive(false);
            //nameOverlay.SetActive(true);

        }

    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneEstimated);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
           PlacementPose = hits[0].pose;
           
        }
    }
}


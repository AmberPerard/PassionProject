using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    private float currentFood;
    private float currentSteps;
    private float currentChat;

    public int food = 100;
    public int steps = 100;
    public int chat = 100;

    public StatsBar statbars;
    private Canvas Can;
    private GameObject tempobject;

    // Start is called before the first frame update
    void Start()
    {

        //tempobject = GameObject.Find("canvas");
        //if (tempobject != null)
        //{
        //    //If we found the object , get the Canvas component from it.
        //    Can = tempobject.GetComponent<Canvas>();
        //    if (Can == null)
        //    {
        //        Debug.Log("Could not locate Canvas component on " + tempobject.name);
        //    }
        //    else
        //    {
        //        statbars = Can.GetComponent<StatBars>();
        //    }
        //}

        //statbars = gameObject.GetComponent<Transform>().Find("Stats").GetComponent<StatBars>();

        currentFood = food;
        currentSteps = steps;
        currentChat = chat;

        PlayerPrefs.SetFloat("Food", currentFood);
        PlayerPrefs.SetFloat("Steps", currentSteps);
        PlayerPrefs.SetFloat("Chat", currentChat);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFood >= 0)
        {
            currentFood -= Time.deltaTime * 1;
            PlayerPrefs.SetFloat("Food", currentFood);
            statbars.setFoodbar(currentFood);
            PlayerPrefs.Save();
        }
        if (currentSteps >= 0)
        {
            currentSteps -= Time.deltaTime * 1;
            PlayerPrefs.SetFloat("Steps", currentSteps);
            statbars.setStepbar(currentFood);
            PlayerPrefs.Save();
        }
        if (currentChat >= 0)
        {
            currentChat -= Time.deltaTime * 1;
            PlayerPrefs.SetFloat("Chat", currentChat);
            statbars.setChatbar(currentFood);
            PlayerPrefs.Save();
        }
        if (currentFood == 10)
        {
            currentFood = 10;
            PlayerPrefs.SetFloat("Food", currentFood);
            statbars.setFoodbar(currentFood);
            PlayerPrefs.Save();
        }
        if (currentSteps == 10)
        {
            currentSteps = 10;
            PlayerPrefs.SetFloat("Steps", currentSteps);
            statbars.setStepbar(currentFood);
            PlayerPrefs.Save();
        }
        if (currentChat == 10)
        {
            currentChat = 10;
            PlayerPrefs.SetFloat("Chat", currentChat);
            statbars.setChatbar(currentFood);
            PlayerPrefs.Save();
        }
        PlayerPrefs.Save();
    }
}

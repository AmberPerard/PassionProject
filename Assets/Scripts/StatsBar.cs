using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{

    public Slider Foodbar;
    public Slider Stepbar;
    public Slider Chatbar;


    public void setFoodbar(float food)
    {
        Foodbar.value = food;
    }
    public void setStepbar(float step)
    {
        Stepbar.value = step;
    }
    public void setChatbar(float chat)
    {
        Chatbar.value = chat;
    }
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    //public void ChangeScene(string sceneName) {
    //    SceneManager.LoadScene(sceneName, LoadSceneMode.single);
    //}

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

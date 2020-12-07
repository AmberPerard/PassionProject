using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractNameSave : MonoBehaviour
{ 

    public InputField Charactername_textBox;
    public GameObject CharacternameField;
    public GameObject nameOverlay;
    private string characterName;

    public void Start()
    {
        characterName = PlayerPrefs.GetString("User", string.Empty);
    }

    public void SaveCharacterName()
    {
        PlayerPrefs.SetString("User" , Charactername_textBox.text);
        PlayerPrefs.Save();
        nameOverlay.SetActive(false);
        //Debug.Log(PlayerPrefs.GetString("User"));
        CharacternameField.SetActive(false);
    }
}

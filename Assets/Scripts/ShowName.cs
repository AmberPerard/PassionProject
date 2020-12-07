using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowName : MonoBehaviour
{
    private string characterName;
    Text title;

    // Start is called before the first frame update
    void Start()
    {
        title = gameObject.GetComponent<UnityEngine.UI.Text>();
        characterName = PlayerPrefs.GetString("User", string.Empty);



        //if (characterName != null)
        //{
        //    print(characterName);
        //}
        Debug.Log(characterName);
    }

    // Update is called once per frame
    void Update()
    {
        if (string.IsNullOrEmpty(characterName) == true)
        {
            Debug.Log("empty");
            characterName = PlayerPrefs.GetString("User", string.Empty);
        }

        if (string.IsNullOrEmpty(characterName) == false)
        {
            //Debug.Log("Not Empty");
            //Debug.Log(characterName);
            title.text = "To ";
            title.text += characterName;
        }

    }
}

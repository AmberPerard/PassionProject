using UnityEngine;
using UnityEngine.UI;
using TextSpeech;

public class SampleSpeechToText : MonoBehaviour
{
    //public GameObject loading;
    Animator anim;
    int jumpHash = Animator.StringToHash("RecognizesName");

    private string characterName;

    void Start()
    {
        Setting("en-US");

        SpeechtToText.instance.onResultCallback = OnResultSpeech;
        anim = gameObject.GetComponentInParent<Animator>();

        characterName = PlayerPrefs.GetString("User", string.Empty);


    }

    public void StartRecording()
    {
#if UNITY_EDITOR
#else
        SpeechtToText.instance.StartRecording("Speak any");
#endif
    }

    public void StopRecording()
    {
#if UNITY_EDITOR
        OnResultSpeech("Not support in editor.");
#else
        SpeechtToText.instance.StopRecording();
#endif
#if UNITY_IOS
        //loading.SetActive(true);
#endif
    }
    void OnResultSpeech(string _data)
    {
        Debug.Log(characterName);
         if (_data.ToUpper() == characterName.ToUpper())
        {
            anim.SetTrigger(jumpHash);
        }

        //inputText.text = _data;
#if UNITY_IOS
        //loading.SetActive(false);
#endif
    }
    public void Setting(string code)
    {
        SpeechtToText.instance.Setting(code);
    }
}

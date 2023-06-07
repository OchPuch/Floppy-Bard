using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] AppsFlyerObjectScript appsFlyerObjectScript;
    [SerializeField] private Button button;
    void Start()
    {
        appsFlyerObjectScript.onConversionDataReceived += OnConversationDataReceived;
        button.interactable = false;
    }
    
    private void OnConversationDataReceived(string conversationData)
    {
        button.interactable = true;
    }

}

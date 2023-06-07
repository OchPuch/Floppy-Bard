using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConversationDataOutput : MonoBehaviour
{
    [SerializeField] AppsFlyerObjectScript appsFlyerObjectScript;
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI;
    
    void Start()
    {
        appsFlyerObjectScript.onConversionDataReceived += OnConversationDataReceived;
    }
    
    private void OnConversationDataReceived(string conversationData)
    {
        Debug.Log("Received conversation data:\n" + conversationData);
        TextMeshProUGUI.text += conversationData;
    }
}

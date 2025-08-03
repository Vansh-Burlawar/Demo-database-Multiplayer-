using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEditor.PackageManager;
using TMPro;


public class PlayFabManager : MonoBehaviour
{

    public TMP_Text Textmessage;
    public TMP_InputField EmailText;
    public TMP_InputField PasswordText;

    
   public void RegisterButton()
    {
        Debug.Log("Register button clicked");
        if (PasswordText.text.Length < 4)
        {
            Textmessage.text = "Its a small password ";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = EmailText.text,
            Password = PasswordText.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterError);
    }

    public void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Textmessage.text="Registration Successful !!!";
    }

    public void OnRegisterError(PlayFabError error)
    {
        Textmessage.text = error.ErrorMessage;
    }
     public void LoginButton()
    {

    }
    void Start()
    {
        PlayFabSettings.staticSettings.TitleId = "135FB8";
        Textmessage.text = "Hello from Start!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

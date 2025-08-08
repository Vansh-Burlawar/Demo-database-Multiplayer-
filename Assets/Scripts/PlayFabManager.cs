using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

using TMPro;
using System.IO;

using UnityEngine.SceneManagement;


public class PlayFabManager : MonoBehaviour
{

    public TMP_Text Textmessage;
    public TMP_InputField EmailText;
    public TMP_InputField PasswordText;
    public TMP_InputField AgeText;


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
        Textmessage.text = "Registration Successful !!!";
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Age", AgeText.text },
            }
        
        
    };
    PlayFabClientAPI.UpdateUserData(request, OnSussefulAgeUpdate, OnRegisterError);
}
    public void OnSussefulAgeUpdate(UpdateUserDataResult result)
    {
        Textmessage.text = "Age Updated Successfully !!!";
    }
    public void OnRegisterError(PlayFabError error)
    {
        Textmessage.text = error.ErrorMessage;
    }
     public void LoginButton() //eg email abcd@gmail.com and pass 123456789
    {
        var request= new LoginWithEmailAddressRequest{
           Email= EmailText.text,
                Password = PasswordText.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnRegisterError);
    }

    public void OnLoginSuccess(LoginResult result)
    {
        Textmessage.text = "Successfull Login !!";
        StartCoroutine(loadSceneafterDelay());
        
    }

    IEnumerator loadSceneafterDelay()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Game");
    }
    void Start()
    {
        PlayFabSettings.staticSettings.TitleId = "135FB8";
        Textmessage.text = "Please Login or Register to this game before starting ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

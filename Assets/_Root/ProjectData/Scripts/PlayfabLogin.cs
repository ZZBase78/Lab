using Photon.Pun;
using Photon.Realtime;
using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabLogin : MonoBehaviourPunCallbacks
{
    private const string AUTH_GUID_KEY = "AUTH_GUID_KEY";

    [SerializeField] private string _playFabTitle;

    private string guidID;

    void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
            PlayFabSettings.staticSettings.TitleId = _playFabTitle;

        bool keyPreset = PlayerPrefs.HasKey(AUTH_GUID_KEY);
        guidID = PlayerPrefs.GetString(AUTH_GUID_KEY, Guid.NewGuid().ToString());

        var request = new LoginWithCustomIDRequest
        {
            CustomId = guidID,
            CreateAccount = !keyPreset
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnLoginComplete, OnLoginError);
    }

    private void OnLoginComplete(LoginResult result)
    {
        PlayerPrefs.SetString(AUTH_GUID_KEY, guidID);
        Debug.Log("Complete login!!!");
    }

    private void OnLoginError(PlayFabError error)
    {
        string errorMessage = error.GenerateErrorReport();
        Debug.LogError(errorMessage);
    }
}

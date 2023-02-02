using TMPro;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayfabAccountManager : MonoBehaviour
{
    [SerializeField] TMP_Text _titleLabel;

    private void Start()
    {
        GetAccountInfoRequest request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, GetAccountInfoComplete, GetAccountInfoError);
    }

    private void GetAccountInfoComplete(GetAccountInfoResult result)
    {
        _titleLabel.text = $"Playfab id: {result.AccountInfo.PlayFabId}";
    }

    private void GetAccountInfoError(PlayFabError error)
    {
        string errorMessage = error.GenerateErrorReport();
        Debug.LogError(errorMessage);
    }
}

using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class CreateAccountWindow : AccountDataWindowBase
{
    [SerializeField] private InputField _mailField;

    [SerializeField] private Button _createAccountButton;

    private string _mail;

    protected override void SubscriptionsElementsUi()
    {
        base.SubscriptionsElementsUi();

        _mailField.onValueChanged.AddListener(UpdateMail);
        _createAccountButton.onClick.AddListener(CreateAccount);
    }

    private void UpdateMail(string mail)
    {
        _mail = mail;
    }

    private void CreateAccount()
    {
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest();
        request.Email = _mail;
        request.Username = _username;
        request.Password = _password;

        PlayFabClientAPI.RegisterPlayFabUser(request, CreateAccountComplete, CreateAccountError);
    }

    private void CreateAccountComplete(RegisterPlayFabUserResult result)
    {
        Debug.Log($"Success: {_username}");
        EnterInGameScene();
    }

    private void CreateAccountError(PlayFabError error)
    {
        Debug.LogError($"Fail: {error.ErrorMessage}");
    }
}

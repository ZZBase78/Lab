using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class SignInWindow : AccountDataWindowBase
{
    [SerializeField] private Button _signInButton;

    protected override void SubscriptionsElementsUi()
    {
        base.SubscriptionsElementsUi();

        _signInButton.onClick.AddListener(SignIn);
    }

    private void SignIn()
    {
        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest();
        request.Username = _username;
        request.Password = _password;

        PlayFabClientAPI.LoginWithPlayFab(request, SignInComplete, SignInError);
    }

    private void SignInComplete(LoginResult result)
    {
        Debug.Log($"Success: {_username}");
        EnterInGameScene();
    }

    private void SignInError(PlayFabError error)
    {
        Debug.LogError($"Fail: {error.ErrorMessage}");
    }
}

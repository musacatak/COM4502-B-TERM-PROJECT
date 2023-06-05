using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class AccountUI : MonoBehaviour
{

    public Button Btn_Login;
    public Button Btn_SilentLogin;
    public Button Btn_Logout;

    public Text AccountKitState;

    #region Monobehaviour

    private void Awake()
    {
        //Btn_Login = GameObject.Find("Button - LogIn").GetComponent<Button>();
        //Btn_SilentLogin = GameObject.Find("Button - SilentLogIn").GetComponent<Button>();
        //Btn_Logout = GameObject.Find("Button - LogOut").GetComponent<Button>();

        //AccountKitState = GameObject.Find("Text - Status").GetComponent<Text>();
    }

    private void OnEnable()
    {
        Btn_Login.onClick.AddListener(ButtonClick_Login);
        Btn_SilentLogin.onClick.AddListener(ButtonClick_SilentLogin);
        Btn_Logout.onClick.AddListener(ButtonClick_Logout);

        AccountManager.AccountKitLog += OnAccountKitLog;
    }

    private void OnDisable()
    {
        Btn_Login.onClick.RemoveListener(ButtonClick_Login);
        Btn_SilentLogin.onClick.RemoveListener(ButtonClick_SilentLogin);
        Btn_Logout.onClick.RemoveListener(ButtonClick_Logout);

        AccountManager.AccountKitLog -= OnAccountKitLog;
    }

    #endregion

    #region Callbacks

    private void OnAccountKitLog(string log)
    {
        AccountKitState.text = log;
    }

    #endregion

    #region Button Events

    private void ButtonClick_Login()
    {
        AccountManager.Instance.LogIn();
    }

    private void ButtonClick_SilentLogin()
    {
        AccountManager.Instance.SilentSignIn();
    }

    private void ButtonClick_Logout()
    {
        AccountManager.Instance.LogOut();
    }

    #endregion

}

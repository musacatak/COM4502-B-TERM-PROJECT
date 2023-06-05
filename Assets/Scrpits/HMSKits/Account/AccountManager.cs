using HuaweiMobileServices.Base;
using HuaweiMobileServices.Game;
using HuaweiMobileServices.Id;
using HuaweiMobileServices.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;
using HmsPlugin;

public class AccountManager : MonoBehaviour
{
    private readonly string TAG = "[HMS] AccountManager ";

    private const string NOT_LOGGED_IN = "No user logged in";
    private const string LOGGED_IN = "{0} is logged in";
    private const string LOGIN_ERROR = "Error or cancelled login";

    public static Action<string> AccountKitLog;

    #region Singleton

    public static AccountManager Instance { get; private set; }
    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    private void Awake()
    {
        Singleton();
    }
    void Start()
    {
        HMSAccountKitManager.Instance.OnSignInSuccess = OnLoginSuccess;
        HMSAccountKitManager.Instance.OnSignInFailed = OnLoginFailure;

        AccountKitLog?.Invoke(NOT_LOGGED_IN);
    }

    public void LogIn()
    {
        Debug.Log(TAG + "LogIn");

        HMSAccountKitManager.Instance.SignIn();
    }

    public void SilentSignIn()
    {
        Debug.Log(TAG + "SilentSignIn");

        HMSAccountKitManager.Instance.SilentSignIn();
    }

    public void LogOut()
    {
        Debug.Log(TAG + "LogOut");

        HMSAccountKitManager.Instance.SignOut();

        AccountKitLog?.Invoke(NOT_LOGGED_IN);
    }

    public void OnLoginSuccess(AuthAccount authHuaweiId)
    {
        AccountKitLog?.Invoke(string.Format(LOGGED_IN, authHuaweiId.DisplayName));
    }

    public void OnLoginFailure(HMSException error)
    {
        AccountKitLog?.Invoke(LOGIN_ERROR);
    }
}
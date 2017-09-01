using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 登录界面
public class LoginScreen : MonoBehaviour {

    #region 登录面板部分

    // 序列化变量，在面板中读取并保存
    [SerializeField]
    private InputField accountInput;

    [SerializeField]
    private InputField passwordInput;
   
    [SerializeField]
    private Button loginBtn;

    [SerializeField]
    private GameObject regPanel;
    #endregion

    #region 注册面板部分
    [SerializeField]
    private InputField regAccountInput;

    [SerializeField]
    private InputField regpwInput;

    [SerializeField]
    private InputField regpwlInput;
    #endregion

    // 登录
    public void loginOnClick()
    {
        if (accountInput.text.Length == 0 || accountInput.text.Length > 6)
        {
            WarningManager.errors.Add(new WarningModel("账号不合法", test));
            Debug.Log("账号不合法");
            return;
        }

        if (passwordInput.text.Length == 0 || passwordInput.text.Length > 6)
        {
            Debug.Log("密码不合法");
            return;
        }

        // 验证通过
        // loginBtn.enabled = false;  //loginBtn.gameObject.SetActive(false); 不可取

        // 按键返回激活状态
        loginBtn.interactable = true;
    }

    // 托管函数
    void test()
    {
        Debug.Log("回调测试");
    }

    // 点击注册
    public void regClick()
    {
        regPanel.SetActive(true);
    }

    // 关闭注册
    public void regCloseClick()
    {
        regPanel.SetActive(false);
    }

    // 提交注册
    public void regpanelregCleck()
    {
        if (regAccountInput.text.Length == 0 || regAccountInput.text.Length > 6)
        {
            Debug.Log("账号不合法");
        }

        if (regpwInput.text.Length == 0 || regpwInput.text.Length > 6)
        {
            Debug.Log("密码不合法");
            return;
        }

        if (!regpwInput.text.Equals(regpwlInput.text))
        {
            Debug.Log("两次输入密码不一致");
            return;
        }

        //验证通过 申请注册 关闭注册面板
    }
}

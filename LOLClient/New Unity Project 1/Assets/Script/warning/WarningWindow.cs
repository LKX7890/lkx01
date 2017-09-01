using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningWindow : MonoBehaviour {

    [SerializeField]
    private Text text;          // 警告内容
    WarningResult result;       // 警告托管

    // 激活警告
    public void active(WarningModel value)
    {
        text.text = value.value;
        this.result = value.result;
        gameObject.SetActive(true);
    }

    // 关闭警告界面
    public void close()
    {
        // 设置状态
        gameObject.SetActive(false);
        if (result != null)
        {
            result();
        }
    }

}

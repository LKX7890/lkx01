using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningManager : MonoBehaviour {

    public static List<WarningModel> errors = new List<WarningModel>();     // 错误列表

    [SerializeField]
    private WarningWindow window;
	
	void Update () {
	    if (errors.Count > 0)
        {
            WarningModel err = errors[0];
            errors.RemoveAt(0);                 // 删除索引指定的值
            window.active(err);                 // 激活警告
        }
	}
}

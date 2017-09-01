using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 托管
public delegate void WarningResult();
public class WarningModel
{
    public WarningResult result;        // 警告托管
    public string value;                // 警告内容

    // 构造函数
    public WarningModel(string value, WarningResult result = null)
    {
        this.value = value;
        this.result = result;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class InputUtil
{
    public static bool IsHoldingKey(KeyCode key)
    {
        return Input.GetKey(key);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelScreen { Start, Instruction, Gameplay, Gameover }
public abstract class Panel {
    public static PanelScreen CurrentScreen = PanelScreen.Start;
    public CanvasRenderer panel { get; set; }
    public Animator animator;
    public Panel(CanvasRenderer _panel)
    {
        panel = _panel;
    }
    public virtual void Start()
    {
        panel.gameObject.SetActive(false);
    }
    protected bool AnyJoyStickButtonPress()
    {
        KeyCode[] allJoyStickCodes = {KeyCode.JoystickButton0, KeyCode.JoystickButton1, KeyCode.JoystickButton2, KeyCode.JoystickButton3,
            KeyCode.JoystickButton4, KeyCode.JoystickButton5, KeyCode.JoystickButton6, KeyCode.JoystickButton7, KeyCode.JoystickButton8,
            KeyCode.JoystickButton9, KeyCode.JoystickButton10, KeyCode.JoystickButton11, KeyCode.JoystickButton12, KeyCode.JoystickButton13,
            KeyCode.JoystickButton14, KeyCode.JoystickButton15, KeyCode.JoystickButton16, KeyCode.JoystickButton17, KeyCode.JoystickButton18,
            KeyCode.JoystickButton19};
        for (int i = 0; i < allJoyStickCodes.Length; i++)
        {
            if (Input.GetKeyDown(allJoyStickCodes[i]))
            {
                return true;
            }
        }
        return false;
    }
    public abstract void Update();
}

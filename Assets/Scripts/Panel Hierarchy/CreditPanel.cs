using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanel : Panel {
    public CreditPanel(CanvasRenderer _panel):base(_panel)
    {

    }
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        panel.gameObject.SetActive(true);
        if (AnyJoyStickButtonPress())
        {
            animator.Play("FadeOut");
            CurrentScreen = PanelScreen.Instruction;
        }
    }
}

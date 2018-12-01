using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionPanel : Panel
{
    public InstructionPanel(CanvasRenderer _panel):base(_panel)
    {

    }
    public override void Start()
    {
        base.Start();
    }
    
    public override void Update()
    {
       
        if (AnyJoyStickButtonPress())
        {
            CurrentScreen = PanelScreen.Gameplay;
            //animator.Play("FadeOut");
        }
        
    }
}

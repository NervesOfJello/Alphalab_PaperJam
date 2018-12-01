using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : Panel{
    
    public StartPanel(CanvasRenderer _panel):base(_panel)
    {

    }
    // Use this for initialization
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
            CurrentScreen = PanelScreen.Credit;
        }
    }
}

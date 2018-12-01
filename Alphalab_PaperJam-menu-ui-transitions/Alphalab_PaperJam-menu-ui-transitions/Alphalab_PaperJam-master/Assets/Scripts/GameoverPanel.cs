using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverPanel : Panel {

    public GameoverPanel(CanvasRenderer _panel) : base(_panel)
    {

    }
    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        //TODO: What Scene comes after Game over?
        if (AnyJoyStickButtonPress())
        {
            CurrentScreen = PanelScreen.Gameover;
            animator.Play("FadeOut");
        }
    }
}

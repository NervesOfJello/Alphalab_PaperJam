using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : Panel {
    public GamePanel(CanvasRenderer _panel) : base(_panel)
    {

    }
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        //TODO: Must include something that will cause a transition to GameOver
        if (LivesLost.Lives == 0)
        {
            CurrentScreen = PanelScreen.Gameover;
            animator.Play("FadeOut");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelTransition : MonoBehaviour {
    [SerializeField]
    private CanvasRenderer StartPanel, InstructionPanel, GameplayPanel, GameoverPanel;
    [SerializeField]
    private string sceneName; //name of the scene loaded after the instruction panel
    private float startfadeOutInSeconds = 1.4f, instructionfadeOutInSeconds = 1.4f, gameplayfadeOutInSeconds = 1.4f, gameoverfadeOutInSeconds = 1.4f;
    StartPanel start;
    InstructionPanel instruction;
    GamePanel gameplay;
    GameoverPanel gameover;

	// Use this for initialization
	void Start () {
        
        start = new StartPanel(StartPanel);
        instruction = new InstructionPanel(InstructionPanel);
        gameplay = new GamePanel(GameplayPanel);
        gameover = new GameoverPanel(GameoverPanel);

        start.animator= StartPanel.GetComponent<Animator>();
        instruction.animator = InstructionPanel.GetComponent<Animator>();
        gameplay.animator = GameplayPanel.GetComponent<Animator>();
        gameover.animator = GameoverPanel.GetComponent<Animator>();

        start.Start();
        instruction.Start();
        gameplay.Start();
        gameover.Start();
       
	}
    private void Update()
    {
        switch (Panel.CurrentScreen)
        {
            case PanelScreen.Start:
                start.Update();
                if (Panel.CurrentScreen == PanelScreen.Instruction)
                {
                    StartCoroutine(AfterAnimationPlay());
                }
                break;
            case PanelScreen.Instruction:
                instruction.Update();
                if (Panel.CurrentScreen == PanelScreen.Gameplay)
                {
                    StartCoroutine(AfterAnimationPlay());
                }
                break;
            case PanelScreen.Gameplay:
                if (Panel.CurrentScreen == PanelScreen.Gameover)
                {
                    StartCoroutine(AfterAnimationPlay());
                }
                gameplay.Update();
                break;
            case PanelScreen.Gameover:
                if (Panel.CurrentScreen == PanelScreen.Gameplay)
                {
                    StartCoroutine(AfterAnimationPlay());
                }
                gameover.Update();
                break;
        }
    }
    IEnumerator AfterAnimationPlay()
    {
        switch (Panel.CurrentScreen)
        {
            case PanelScreen.Instruction:
                yield return new WaitForSeconds(startfadeOutInSeconds);
                start.panel.gameObject.SetActive(false);
                instruction.panel.gameObject.SetActive(true);
                instruction.animator.Play("FadeIn");
                break;
            case PanelScreen.Gameplay:
                yield return new WaitForSeconds(instructionfadeOutInSeconds);
                SceneManager.LoadScene(sceneName); //loads the game scene
                //LivesLost.state = LivesStatus.Reset;
                //gameover.panel.gameObject.SetActive(false);
                //instruction.panel.gameObject.SetActive(false);
                //gameplay.panel.gameObject.SetActive(true);
                //gameplay.animator.Play("FadeIn");
                break;
            case PanelScreen.Gameover:
                yield return new WaitForSeconds(gameplayfadeOutInSeconds);
                gameplay.panel.gameObject.SetActive(false);
                gameover.panel.gameObject.SetActive(true);
                gameover.animator.Play("FadeIn");
                break;

        }
        
    }
}

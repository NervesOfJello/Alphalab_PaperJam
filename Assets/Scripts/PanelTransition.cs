using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelTransition : MonoBehaviour {
    [SerializeField]
    private CanvasRenderer StartPanel, CreditPanel, InstructionPanel;
    [SerializeField]
    private string sceneNameForDesignScene = "Design Scene"; //name of the scene loaded after the instruction panel
    private float startfadeOutInSeconds = 1.4f, instructionfadeOutInSeconds = 1.4f;

    StartPanel start;
    InstructionPanel instruction;
    CreditPanel credit;
	// Use this for initialization
	void Start () {
        
        start = new StartPanel(StartPanel);
        credit = new CreditPanel(CreditPanel);
        instruction = new InstructionPanel(InstructionPanel);

        start.animator= StartPanel.GetComponent<Animator>();
        credit.animator = CreditPanel.GetComponent<Animator>();
        instruction.animator = InstructionPanel.GetComponent<Animator>();
        
        start.Start();
        credit.Start();
        instruction.Start();
       
	}
    private void Update()
    {
        switch (Panel.CurrentScreen)
        {
            case PanelScreen.Start:
                start.Update();
                if (Panel.CurrentScreen == PanelScreen.Credit)
                {
                    StartCoroutine(AfterAnimationPlay());
                }
                break;
            case PanelScreen.Credit:
                instruction.Update();
                if (Panel.CurrentScreen == PanelScreen.Instruction)
                {
                    StartCoroutine(AfterAnimationPlay());
                }
                break;
            case PanelScreen.Instruction:
                instruction.Update();
                if (Panel.CurrentScreen == PanelScreen.Gameplay)
                {
                    SceneManager.LoadScene(sceneNameForDesignScene);
                }
                break;
        }
    }
    IEnumerator AfterAnimationPlay()
    {
        switch (Panel.CurrentScreen)
        {
            case PanelScreen.Credit:
                yield return new WaitForSeconds(startfadeOutInSeconds);
                start.panel.gameObject.SetActive(false);
                credit.panel.gameObject.SetActive(true);
                credit.animator.Play("FadeIn");
                break;
            case PanelScreen.Instruction:
                yield return new WaitForSeconds(startfadeOutInSeconds);
                credit.panel.gameObject.SetActive(false);
                instruction.panel.gameObject.SetActive(true);
                instruction.animator.Play("FadeIn");
                break;
        }
        
    }
}

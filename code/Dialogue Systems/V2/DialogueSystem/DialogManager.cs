using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DS.ScriptableObjects;
public class DialogManager : MonoBehaviour
{
   public Textreveal Textreveal;
    private int CurLineNumber;
    public DSDialogueContainerSO MainDialogContainer;
    public DSDialogueGroupSO testgroup;
    public int DialogIndex;
    public bool canplay = true;
   public void InitiateDialog(DSDialogueGroupSO TriggeredDialog)
    {
        if(Textreveal.text.text == " ")
        {
            DialogIndex = 0;

            StartCoroutine(Dolines(MainDialogContainer, TriggeredDialog));
        }
    
    }
    void ProgressLine()
    {
        CurLineNumber++;
      //  Textreveal.RestartWithText(TriggeredDialog.Lines[CurLineNumber].Text);
}
    void Start()
    {
       // Textreveal.RestartWithText(dialogContainer.DialogueGroups[testgroup][0].Text);
    }
    IEnumerator Dolines(DSDialogueContainerSO dialogContainer, DSDialogueGroupSO TriggeredGroup)
    {
       
        while ( DialogIndex < dialogContainer.DialogueGroups[testgroup].Count)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            if (!Textreveal.IsRevealing && canplay)
            {
                Textreveal.RestartWithText(dialogContainer.DialogueGroups[TriggeredGroup][DialogIndex].Text);
             DialogIndex++;
            }
        }
        
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) && DialogIndex == dialogContainer.DialogueGroups[testgroup].Count && !Textreveal.IsRevealing);
       // print("end");
            Textreveal.text.text = " ";
        

    }
    // Update is called once per frame
    void Update()
    {
       
        //print(dialogContainer.GetDialogueGroupNames()[0]);
       
       
    }
}

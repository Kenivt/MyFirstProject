using UnityEngine;
using Knivt.Tools;
public class Panel_A : UIState
{
    public override void CloseInteraction()
    {
        CanvasGroup.interactable = false;
    }
}

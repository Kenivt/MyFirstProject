using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Knivt.Tools;

public class TwoOtherPanel : UIGroup
{
    private void Awake()
    {
        this.AddAllChildUIState();
        SetStartState(typeof(Panel_A).Name);
    }
    public override void CloseInteraction()
    {

    }
}

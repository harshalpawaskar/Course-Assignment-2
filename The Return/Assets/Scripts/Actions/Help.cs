﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Action/Help")]
public class Help : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        controller.currentText.text = "Type a Verb followed by a noun(eg-\"go North\")";
        controller.currentText.text += "\nAllowed verbs:\nGo, Get, Use, Inventory, TalkTo, Say, Help, Examine, Give, Read";
    }
}

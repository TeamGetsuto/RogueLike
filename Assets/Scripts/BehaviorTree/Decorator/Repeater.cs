using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���s�[�^�[
/// �m�[�h�̃��[�v����
/// </summary>
/// 

public class Repeater : DecorateNode
{
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }

    protected override State OnUpDate()
    {
        child.UpDate();
        return State.Running;
    }
}

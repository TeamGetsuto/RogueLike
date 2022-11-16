using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �f�o�b�O���O�m�[�h
/// �f�o�b�O���b�Z�[�W�̕\��
/// </summary>
namespace shirasu
{
    public class Debugger : ActionNode
    {
        public string message;
        protected override void OnStart()
        {
            Debug.Log($"OnStart{message}");
        }
        protected override State OnUpDate()
        {
            Debug.Log($"OnUpDate{message}");
            return State.Success;
        }
        protected override void OnStop()
        {
            Debug.Log($"OnStop{message}");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �V�[�N�G���T�[
/// �q�m�[�h�̐��ۂɊւ�炸���ׂĂ����s
/// </summary>
namespace shirasu
{
    public class Sequencer : CompositeNode
    {
        int current;
        protected override void OnStart()
        {
            current = 0;
        }

        protected override void OnStop()
        {

        }

        protected override State OnUpDate()
        {
            var child = children[current];

            switch (child.UpDate())
            {
                case State.Success:
                    current++;
                    break;
                case State.Running:
                    return State.Running;
                case State.Failure:
                    return State.Failure;
            }
            return current == children.Count ? State.Success : State.Running;
        }
    }
}

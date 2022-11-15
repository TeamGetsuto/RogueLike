using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shirasu
{
    public class WaitNode : ActionNode
    {
        public float waitTime;
        float startTime;

        protected override void OnStart()
        {
            startTime = Time.time;
        }

        protected override void OnStop()
        {

        }

        protected override State OnUpDate()
        {
            if (Time.time - startTime > waitTime)
            {
                return State.Success;
            }

            return State.Running;
        }
    }
}

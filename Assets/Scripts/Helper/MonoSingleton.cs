using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    protected static T instance_;
    
    public static T Instance
    {
        get
        {
            if(instance_ == null)
            {
                instance_ = (T)FindObjectOfType(typeof(T));
            }

            return instance_;
        }
    }

}

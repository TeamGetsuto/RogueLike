using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperUtilities
{
    /// <summary>
    /// string�͋󂩂ǂ����@�m�F
    /// </summary>
    public static bool ValidateCheckEmptyString(Object thisObject, string fieldName, string stringToCheck)
    {
        if(stringToCheck == "")
        {
            Debug.Log(thisObject.name.ToString() + "��" +�@fieldName + "�͏���������Ă��܂���");
            return true;
        }
        return false;
    }

    /// <summary>
    /// List�͋󂩃G���[�����邩�@�m�F
    /// </summary>
    public static bool ValidateCheckEnumerableValues(Object thisObject, string fieldName, IEnumerable enumerableObjectToCheck)
    {
        bool error = false;
        int count = 0;

        foreach(var item in enumerableObjectToCheck)
        {
            if (item == null)
            {
                Debug.Log(thisObject.name.ToString() + "��" + fieldName + "�ł�NULL�t�B�[���h������܂��B");
                error = true;
            }
            else
            {
                count++;
            }
        }

        if(count==0)
        {
            Debug.Log(thisObject.name.ToString() + "��" + fieldName + "�͏���������Ă��܂���");
            error=true;
        }
        return error;
    }
}

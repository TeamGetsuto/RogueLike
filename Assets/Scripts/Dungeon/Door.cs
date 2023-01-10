using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Door : MonoBehaviour
{
    #region Header OBJECT REFERENCES
    [Space(10)]
    [Header("OBJECT REFERENCES")]
    #endregion

    #region Tooltip
    [Tooltip("Populate this with the BoxCollider2D component on the DoorCollider gameobject")]
    #endregion
    [SerializeField] private GameObject doorCollider;

    [HideInInspector] public bool isBossRoomDoor = false;
    private bool isOpen = false;
    private bool previouslyOpened = false;

    private void Awake()
    {
        doorCollider.SetActive(false);
    }


    public void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            previouslyOpened = true;
            doorCollider.SetActive(false);
        }
    }
    public void LockDoor()
    {
        isOpen = false;
        doorCollider.SetActive(true);

    }

    public void UnlockDoor()
    {
        if (previouslyOpened == true)
        {
            isOpen = false;
            OpenDoor();
        }
    }

    #region Validation
#if UNITY_EDITOR
    private void OnValidate()
    {
        HelperUtilities.ValidateCheckNullValue(this, nameof(doorCollider), doorCollider);
    }
#endif
    #endregion

}

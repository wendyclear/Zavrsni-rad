using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private RoomMenu _roomMenu;

    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;
    private RoomsCanvases _roomCanvases;
   public LeaveRoomMenu LeaveRoomMenu { get { return LeaveRoomMenu;}}

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomCanvases = canvases;
        _roomMenu.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInitialize(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

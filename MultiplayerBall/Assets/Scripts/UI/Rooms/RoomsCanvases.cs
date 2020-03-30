using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinCanvas _createOrJoinCanvas;
    public CreateOrJoinCanvas CreateOrJoinCanvas { get { return _createOrJoinCanvas; } }

    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas { get { return _currentRoomCanvas; } }

    private void Awake()
    {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        CreateOrJoinCanvas.FirstInitialize(this);
        CurrentRoomCanvas.FirstInitialize(this);
    }
}

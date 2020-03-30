using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;

    private List<RoomListing> _listings = new List<RoomListing>();
   // private List<string> _roomNames = new List<string>();

    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }


    public override void OnJoinedRoom()
    {
        _roomsCanvases.CurrentRoomCanvas.Show();
        _content.DestroyChildren();
        _listings.Clear();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        // bool exists = false;
        foreach (RoomInfo info in roomList)
        {
            //Removed from rooms list.
            if (info.RemovedFromList)
            {
                //Debug.Log("Brišem sobu " + info.Name);
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_listings[index].gameObject);
                     _listings.RemoveAt(index);
                }
            }
            //Added to rooms list.
            else
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index == -1)
                {
                    RoomListing listing = Instantiate(_roomListing, _content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        _listings.Add(listing);
                        // _roomNames.Add(info.Name);
                    }
                }
                else
                {
                    //modify listing here
                } 
            }
        }
    }
}

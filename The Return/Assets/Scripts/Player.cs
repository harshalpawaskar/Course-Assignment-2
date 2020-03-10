using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player: MonoBehaviour
{
    public Location currentLocation;

    public List<Item> inventory = new List<Item>();
    void Start()
    {

    }

    public bool HasItemByName(string noun)
    {
        foreach(Item item in inventory)
        {
            if (item.itemName.ToLower() == noun.ToLower())
                return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool ChangeLocation(GameController controller,string connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);
        if(connection != null)
        {
            if(connection.connectionEnabled)
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    public void Teleport(GameController controller,Location destination)
    {
        currentLocation = destination;
    }

    internal void RemoveItem(string noun)
    {
        foreach(Item item in inventory)
        {
            if (item.itemName == noun)
            {
                inventory.Remove(item);
                return;
            }
        }
    }

    internal bool CanTalkToItem(GameController controller, Item item)
    {
        return item.playerCanTalkTo;
    }

    internal bool CanGiveToItem(GameController controller, Item item)
    {
        return item.playerCanGiveTo;
    }

    internal bool CanUseItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
            return true;

        if (HasItem(item.targetItem))
            return true;

        if (currentLocation.HasItem(item.targetItem))
            return true;

        return false;
    }

    internal bool CanReadItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
            return true;

        if (HasItem(item.targetItem))
            return true;

        if (currentLocation.HasItem(item.targetItem))
            return true;

        return false;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach(Item item in inventory)
        {
            if (itemToCheck == item&& item.itemEnabled)
                return true;
        }
        return false;
    }
}

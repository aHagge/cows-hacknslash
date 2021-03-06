﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Inventory : MonoBehaviour {

    // Item array with all items able to go into the inventory.
    public Item[] Alltheitems;

    public static string itemselected;
    // The actual item in the inventory, later being set to the item of choice.
    public GameObject itemdisplayerprefab;

    public GameObject[] Slots;

    public GameObject Backpack;

    public GameObject Slotselector;

    public int slotselected;

    public TextMeshProUGUI slotinfo;

    private void Awake()
    {
        Backpack.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Slotselector.transform.position = Slots[0].transform.position;
            slotselected = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Slotselector.transform.position = Slots[1].transform.position;
            slotselected = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Slotselector.transform.position = Slots[2].transform.position;
            slotselected = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Slotselector.transform.position = Slots[3].transform.position;
            slotselected = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Slotselector.transform.position = Slots[4].transform.position;
            slotselected = 4;
        }

        //Set the info bar too what item selected name is
        slotinfo.text = Slots[slotselected].GetComponent<Slot>().iteminit;
        itemselected = Slots[slotselected].GetComponent<Slot>().iteminit;


        if (Input.GetKeyDown(KeyCode.P))
        {
            Additem(2, 1);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Additem(1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Backpack.activeInHierarchy)
            {
                Backpack.SetActive(false);
            } 
            else
            {
                Backpack.SetActive(true);
            }
        }
    }

    // Being able to call this function and just typing in what item id to add.
    public void Additem(int id , int amount)
    {
        foreach (GameObject slot in Slots)
        {
            // If nothing is in the slot.
            if (!slot.GetComponent<Slot>().somethingin)
            {
                // Spawn the object in that slot.
                Instantiate(itemdisplayerprefab, slot.transform.localPosition, Quaternion.identity, slot.gameObject.transform);

                // Making sure the slot is displayed as something in it.
                slot.GetComponent<Slot>().somethingin = true;
                slot.GetComponentInChildren<a_Item>().itemdisplaying = Alltheitems[id];
                slot.GetComponentInChildren<a_Item>().itemsinit += amount;
                slot.GetComponent<Slot>().iteminit = Alltheitems[id].Name;
                if (slot.GetComponentInChildren<a_Item>().itemsinit >= Alltheitems[id].HowManyCanStack)
                {
                    slot.GetComponent<Slot>().full = true;
                }
                break;
            }
            // If there is something in the slot and it's the same as the one you are trying to add.
            else if (slot.GetComponent<Slot>().iteminit.Equals(Alltheitems[id].Name) && !slot.GetComponent<Slot>().full)
            {
                slot.GetComponentInChildren<a_Item>().itemsinit += amount;

                // If it's full after you have added the amount of items.
                if (slot.GetComponentInChildren<a_Item>().itemsinit >= Alltheitems[id].HowManyCanStack)
                {
                    slot.GetComponent<Slot>().full = true;
                }
                break;
            }
        }
      
    }
}

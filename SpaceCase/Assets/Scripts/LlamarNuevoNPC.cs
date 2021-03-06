﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamarNuevoNPC : MonoBehaviour
{
    public float actionDistance = 1.5f;
    private Color mouseOverColor = Color.yellow;
    private Color originalColor = Color.blue;
    public GameObject npc;
    public GameObject npcSpawn;

    private void Start()
    {
        originalColor = GetComponent<Renderer>().material.color;
    }

    void OnMouseEnter()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < actionDistance)
        {
            GetComponent<Renderer>().material.color = mouseOverColor;
        }
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor;
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < actionDistance)
        {
            try
            {
                GetComponent<AudioSource>().Play();
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }

            Debug.Log("Llamar nuevo NPC");
            if (GameObject.FindGameObjectWithTag("NPC") == null)
            {
                Debug.Log("Llamado");
                GameObject NPC = Instantiate(npc, npcSpawn.transform.position, npcSpawn.transform.rotation);
            }
            

        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameTracker gameManager;

    public bool walkable = true;

    public bool selected;

    public int northCover;
    public int eastCover;
    public int westCover;
    public int southCover;

    public Camera cam;

    Material mat;

    public bool mouseOver = false;

	// Use this for initialization
	void Start ()
    {
        mat = GetComponent<Renderer>().material;
        //Change the Color back to white when the mouse exits the GameObject

    }

    // Update is called once per frame
    void Update ()
    {
        int tileContents = gameManager.CheckTileContents(transform.position);
        if (mouseOver == true)
        {
            mat.color = Color.white;
        }
        else
        {
            if (tileContents == 0)
                mat.color = Color.clear;
            else if (tileContents == 1)
                mat.color = Color.blue;
            else if (tileContents == 2)
                mat.color = Color.red;
        }
    }

    void OnMouseOver()
    {
        // Change the Color of the GameObject when the mouse hovers over it

        mouseOver = true;

        if (gameManager.playerTurn)
        {
            mat.color = Color.white;
            gameManager.DrawLine(transform.position);

            if (Input.GetMouseButtonDown(0))
            {
                selected = true;
                if (gameManager.playerTurn == true)
                {
                    gameManager.MovePlayer(transform.position);
                }
            }

            selected = false;
        }
    }

    void OnMouseExit()
    {
        mouseOver = false;

        //Change the Color back to white when the mouse exits the GameObject
        int tileContents = gameManager.CheckTileContents(transform.position);
        if (tileContents == 0)
            mat.color = Color.clear;
        else if (tileContents == 1)
            mat.color = Color.blue;
        else if (tileContents == 2)
            mat.color = Color.red;
    }
}

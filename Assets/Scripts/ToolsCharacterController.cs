using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rgbd2d;
    ToolBarController toolBarController;
    Animator animator;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] ToolAction onTilePickUp;

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
        toolBarController = GetComponent<ToolBarController>();
        animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        SelectTile();
        CanSelectedCheck();
        Marker();
        if(Input.GetMouseButtonDown(0))
        {
            if(UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReadController.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectedCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }
    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }

    private bool UseToolWorld()
    {
       Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

        Item item = toolBarController.GetItem;
        if(item == null ) { return false; }
        if(item.onAction == null ) { return false; }

        animator.SetTrigger("act");
        bool complete = item.onAction.OnApply(position);

        if (complete == true)
        {
            if (item.onItemUsed != null)
            {
                item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
            }

        }

        return complete;
    }

    private void UseToolGrid()
    {
        if(selectable == true)
        {
            Item item = toolBarController.GetItem;
            if(item == null) { return; }
            if(item.onTileMapAction  == null) { return; }

            animator.SetTrigger("act");
            bool complete = item.onTileMapAction.OnApplyToTilemap(selectedTilePosition, tileMapReadController, item);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ Tool action/ Seed")]
public class SeedTile : ToolAction
{
    public override bool OnApplyToTilemap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
    {
       if(tileMapReadController.cropsManager.Check(gridPosition) == false)
        {
            return false;
        }

        tileMapReadController.cropsManager.Seed(gridPosition, item.crop);
        
        return true;
    }
    public override void OnItemUsed(Item usedItem, ItemContainer inventory)
    {
        inventory.Remove(usedItem);  
    }
}

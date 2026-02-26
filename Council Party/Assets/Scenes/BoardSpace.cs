using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public int spaceIndex;
    public bool hasTrap;

    private List<PlayerToken> playersOnSpace = new List<PlayerToken>();

    public void EnterSpace(PlayerToken player)
    {
        playersOnSpace.Add(player);

        Debug.Log("Player entered space " + spaceIndex);

        if (hasTrap)
        {
            Debug.Log("Trap triggered!");
        }
    }

    public void ExitSpace(PlayerToken player)
    {
        playersOnSpace.Remove(player);
    }
}
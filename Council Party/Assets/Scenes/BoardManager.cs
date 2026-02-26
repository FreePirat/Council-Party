using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public List<BoardSpace> spaces = new List<BoardSpace>();

    public BoardSpace GetSpace(int index)
    {
        return spaces[index];
    }
}
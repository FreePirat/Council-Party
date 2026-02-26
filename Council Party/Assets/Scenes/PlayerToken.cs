using UnityEngine;
using System.Collections;

public class PlayerToken : MonoBehaviour
{
    public int currentIndex;
    public BoardManager board;

    public void MoveSteps(int steps)
    {
        StartCoroutine(MoveRoutine(steps));
    }

    private IEnumerator MoveRoutine(int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            if (currentIndex >= board.spaces.Count - 1)
                yield break;

            BoardSpace current = board.GetSpace(currentIndex);
            current.ExitSpace(this);

            currentIndex++;

            BoardSpace next = board.GetSpace(currentIndex);
            transform.position = next.transform.position;

            next.EnterSpace(this);

            yield return new WaitForSeconds(0.3f);
        }
    }
}
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem; // NEW INPUT SYSTEM

public class DiceRoller : MonoBehaviour
{
    public TextMeshProUGUI numberText; // Drag your Number text here

    public float rollInterval = 0.5f;
    public int minNumber = 1;
    public int maxNumber = 10;

    private bool isRolling = true;
    private Coroutine rollCoroutine;

    void Start()
    {
        rollCoroutine = StartCoroutine(RollDice());
    }

    void Update()
    {
        if (isRolling && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            StopRolling();
        }
    }

    IEnumerator RollDice()
    {
        while (isRolling)
        {
            int randomNumber = Random.Range(minNumber, maxNumber + 1);
            numberText.text = randomNumber.ToString();

            yield return new WaitForSeconds(rollInterval);
        }
    }

    void StopRolling()
    {
        isRolling = false;

        if (rollCoroutine != null)
            StopCoroutine(rollCoroutine);

        int finalNumber = Random.Range(minNumber, maxNumber + 1);
        numberText.text = finalNumber.ToString();
    }
}
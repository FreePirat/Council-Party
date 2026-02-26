using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class DiceRoller : MonoBehaviour
{
    public TextMeshProUGUI numberText; // assign in inspector
    public float rollInterval = 0.1f;
    public int minNumber = 1;
    public int maxNumber = 6;
    public PlayerToken player; // assign in inspector

    private bool isRolling = false;
    private Coroutine rollCoroutine;

    void Start()
    {
        // Initialize TMP text safely
        if (numberText != null)
            numberText.text = "-";
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!isRolling)
                StartRolling();
            else
                StopRolling();
        }
    }

    void StartRolling()
    {
        isRolling = true;
        rollCoroutine = StartCoroutine(RollDice());
    }

    IEnumerator RollDice()
    {
        while (isRolling)
        {
            int randomNumber = Random.Range(minNumber, maxNumber + 1);
            if (numberText != null)
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

        if (numberText != null)
            numberText.text = finalNumber.ToString();

        if (player != null)
            player.MoveSteps(finalNumber);
        else
            Debug.LogError("Player reference not assigned in DiceRoller!");
    }
}
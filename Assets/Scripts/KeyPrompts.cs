using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPrompts : MonoBehaviour {

    public GameObject leftMousePrompt;
    public GameObject rightMousePrompt;
    public GameObject ePrompt;

    static GameObject leftMousePrompt_s;
    static GameObject rightMousePrompt_s;
    static GameObject ePrompt_s;


    public enum Prompt
    {
        Left_Mouse,
        Right_Mouse,
        Space,
        E
    }

    private void Start()
    {
        leftMousePrompt_s = leftMousePrompt;
        rightMousePrompt_s = rightMousePrompt;
        ePrompt_s = ePrompt;
        EndPrompt(Prompt.Left_Mouse);
        EndPrompt(Prompt.Right_Mouse);
        EndPrompt(Prompt.E);
    }

    public static void StartPrompt(Prompt prompt)
    {
        switch (prompt)
        {
            case Prompt.Left_Mouse:
                leftMousePrompt_s.SetActive(true);
                break;
            case Prompt.Right_Mouse:
                rightMousePrompt_s.SetActive(true);
                break;
            case Prompt.E:
                ePrompt_s.SetActive(true);
                break;

        }
    }

    public static void EndPrompt(Prompt prompt)
    {
        switch (prompt)
        {
            case Prompt.Left_Mouse:
                leftMousePrompt_s.SetActive(false);
                break;
            case Prompt.Right_Mouse:
                rightMousePrompt_s.SetActive(false);
                break;
            case Prompt.E:
                ePrompt_s.SetActive(false);
                break;
        }
    }
}

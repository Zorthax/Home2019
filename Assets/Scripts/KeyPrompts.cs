using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPrompts : MonoBehaviour {

    public GameObject leftMousePrompt;

    static GameObject leftMousePrompt_s;

    public enum Prompt
    {
        Left_Mouse,
        Space,
        E
    }

    private void Start()
    {
        leftMousePrompt_s = leftMousePrompt;
    }

    public static void StartPrompt(Prompt prompt)
    {
        switch (prompt)
        {
            case Prompt.Left_Mouse:
                leftMousePrompt_s.SetActive(true);
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

        }
    }
}

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    class Part
    {
        public KeyCode keyToActivate;
        public AttachablePart attachedPart;

		public Part(KeyCode _key, AttachablePart _partToAdd)
        {
            keyToActivate = _key;
            attachedPart = _partToAdd;
        }
    }

    List<Part> activeParts;

	private List<AttachablePart> attachedParts = new List<AttachablePart>();
    public bool gameStarted = false;

    public static PlayerController instance;
    public GameObject keyMarkerCanvas;
	public static event Action OnControlEnabled;

	// Use this for initialization
    void Awake()
    {
        instance = this;
    }
	void Start ()
    {
        
        activeParts = new List<Part>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameStarted == true)
        {
            for (int i = 0; i < activeParts.Count; i++)
            {
                if (Input.GetKey(activeParts[i].keyToActivate))
                {
                    activeParts[i].attachedPart.ActivatePart();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartGame();
            }
        }
	}

	public void AttachPart(AttachablePart partToAttach)
    {
        attachedParts.Add(partToAttach);
    }

    public void StartGame()
    {
        gameStarted = true;
        GenerateKeysToParts();
		FireOnControlEnabled ();
    }

    void GenerateKeysToParts()
    {
        for (int i = 0; i < attachedParts.Count; i++)
        {
            KeyCode keyToUse = GenerateRandomKeyCode();
            activeParts.Add(new Part(keyToUse, attachedParts[i]));
            GameObject keyMarker = Instantiate(keyMarkerCanvas, attachedParts[i].transform.position + new Vector3(0,0.35f,0), Quaternion.identity) as GameObject;
            keyMarker.transform.SetParent(attachedParts[i].gameObject.transform);
            keyMarker.GetComponent<KeyMarker>().markerText.text = keyToUse.ToString();
            Debug.Log(activeParts[i].keyToActivate);
        }
    }

    KeyCode GenerateRandomKeyCode()
    {
        Array keycodes = Enum.GetValues(typeof(KeyboardEnum));
        System.Random random = new System.Random();
        KeyCode toReturn = (KeyCode)keycodes.GetValue(random.Next(keycodes.Length));
        while (CheckIfAssigned(toReturn))
        {
            random = new System.Random();
            toReturn = (KeyCode)keycodes.GetValue(random.Next(keycodes.Length));
        }
        return toReturn;
    }

    bool CheckIfAssigned(KeyCode keyToCheck)
    {
        for (int i = 0; i < activeParts.Count; i++)
        {
            if (activeParts[i].keyToActivate == keyToCheck)
            {
                return true;
            }
        }
        return false;
    }

	void FireOnControlEnabled()
	{
		if (OnControlEnabled != null)
		{
			OnControlEnabled ();
		}
	}
}

public enum KeyboardEnum
{
    //
    // Summary:
    //     ///
    //     The backspace key.
    //     ///
    Backspace = 8,
    //
    // Summary:
    //     ///
    //     The tab key.
    //     ///
    Tab = 9,
    //
    // Summary:
    //     ///
    //     Return key.
    //     ///
    Return = 13,

    //
    // Summary:
    //     ///
    //     Escape key.
    //     ///
    Escape = 27,
    //
    // Summary:
    //     ///
    //     Space key.
    //     ///
    Space = 32,
    //
    // Summary:
    //     ///
    //     Comma ',' key.
    //     ///
    Comma = 44,
    //
    // Summary:
    //     ///
    //     Minus '-' key.
    //     ///
    Minus = 45,
    //
    // Summary:
    //     ///
    //     Period '.' key.
    //     ///
    Period = 46,
    //
    // Summary:
    //     ///
    //     Slash '/' key.
    //     ///
    Slash = 47,
    //
    // Summary:
    //     ///
    //     The '0' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha0 = 48,
    //
    // Summary:
    //     ///
    //     The '1' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha1 = 49,
    //
    // Summary:
    //     ///
    //     The '2' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha2 = 50,
    //
    // Summary:
    //     ///
    //     The '3' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha3 = 51,
    //
    // Summary:
    //     ///
    //     The '4' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha4 = 52,
    //
    // Summary:
    //     ///
    //     The '5' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha5 = 53,
    //
    // Summary:
    //     ///
    //     The '6' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha6 = 54,
    //
    // Summary:
    //     ///
    //     The '7' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha7 = 55,
    //
    // Summary:
    //     ///
    //     The '8' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha8 = 56,
    //
    // Summary:
    //     ///
    //     The '9' key on the top of the alphanumeric keyboard.
    //     ///
    Alpha9 = 57,
    // Summary:
    //     ///
    //     Equals '=' key.
    //     ///
    Equals = 61,
    // Summary:
    //     ///
    //     Left square bracket key '['.
    //     ///
    LeftBracket = 91,
    //
    // Summary:
    //     ///
    //     Backslash key '\'.
    //     ///
    Backslash = 92,
    //
    // Summary:
    //     ///
    //     Right square bracket key ']'.
    //     ///
    RightBracket = 93,
    //
    // Summary:
    //     ///
    //     Back quote key '`'.
    //     ///
    BackQuote = 96,
    //
    // Summary:
    //     ///
    //     'a' key.
    //     ///
    A = 97,
    //
    // Summary:
    //     ///
    //     'b' key.
    //     ///
    B = 98,
    //
    // Summary:
    //     ///
    //     'c' key.
    //     ///
    C = 99,
    //
    // Summary:
    //     ///
    //     'd' key.
    //     ///
    D = 100,
    //
    // Summary:
    //     ///
    //     'e' key.
    //     ///
    E = 101,
    //
    // Summary:
    //     ///
    //     'f' key.
    //     ///
    F = 102,
    //
    // Summary:
    //     ///
    //     'g' key.
    //     ///
    G = 103,
    //
    // Summary:
    //     ///
    //     'h' key.
    //     ///
    H = 104,
    //
    // Summary:
    //     ///
    //     'i' key.
    //     ///
    I = 105,
    //
    // Summary:
    //     ///
    //     'j' key.
    //     ///
    J = 106,
    //
    // Summary:
    //     ///
    //     'k' key.
    //     ///
    K = 107,
    //
    // Summary:
    //     ///
    //     'l' key.
    //     ///
    L = 108,
    //
    // Summary:
    //     ///
    //     'm' key.
    //     ///
    M = 109,
    //
    // Summary:
    //     ///
    //     'n' key.
    //     ///
    N = 110,
    //
    // Summary:
    //     ///
    //     'o' key.
    //     ///
    O = 111,
    //
    // Summary:
    //     ///
    //     'p' key.
    //     ///
    P = 112,
    //
    // Summary:
    //     ///
    //     'q' key.
    //     ///
    Q = 113,
    //
    // Summary:
    //     ///
    //     'r' key.
    //     ///
    R = 114,
    //
    // Summary:
    //     ///
    //     's' key.
    //     ///
    S = 115,
    //
    // Summary:
    //     ///
    //     't' key.
    //     ///
    T = 116,
    //
    // Summary:
    //     ///
    //     'u' key.
    //     ///
    U = 117,
    //
    // Summary:
    //     ///
    //     'v' key.
    //     ///
    V = 118,
    //
    // Summary:
    //     ///
    //     'w' key.
    //     ///
    W = 119,
    //
    // Summary:
    //     ///
    //     'x' key.
    //     ///
    X = 120,
    //
    // Summary:
    //     ///
    //     'y' key.
    //     ///
    Y = 121,
    //
    // Summary:
    //     ///
    //     'z' key.
    //     ///
    Z = 122,
    //
    // Summary:
    //     ///
    //     The forward delete key.
    //     ///
    Delete = 127,
    //
    // Summary:
    //     ///
    //     Numeric keypad 0.
    //     ///
    Keypad0 = 256,
    //
    // Summary:
    //     ///
    //     Numeric keypad 1.
    //     ///
    Keypad1 = 257,
    //
    // Summary:
    //     ///
    //     Numeric keypad 2.
    //     ///
    Keypad2 = 258,
    //
    // Summary:
    //     ///
    //     Numeric keypad 3.
    //     ///
    Keypad3 = 259,
    //
    // Summary:
    //     ///
    //     Numeric keypad 4.
    //     ///
    Keypad4 = 260,
    //
    // Summary:
    //     ///
    //     Numeric keypad 5.
    //     ///
    Keypad5 = 261,
    //
    // Summary:
    //     ///
    //     Numeric keypad 6.
    //     ///
    Keypad6 = 262,
    //
    // Summary:
    //     ///
    //     Numeric keypad 7.
    //     ///
    Keypad7 = 263,
    //
    // Summary:
    //     ///
    //     Numeric keypad 8.
    //     ///
    Keypad8 = 264,
    //
    // Summary:
    //     ///
    //     Numeric keypad 9.
    //     ///
    Keypad9 = 265,
    //
    // Summary:
    //     ///
    //     Numeric keypad '.'.
    //     ///
    KeypadPeriod = 266,
    //
    // Summary:
    //     ///
    //     Numeric keypad '/'.
    //     ///
    KeypadDivide = 267,
    //
    // Summary:
    //     ///
    //     Numeric keypad '*'.
    //     ///
    KeypadMultiply = 268,
    //
    // Summary:
    //     ///
    //     Numeric keypad '-'.
    //     ///
    KeypadMinus = 269,
    //
    // Summary:
    //     ///
    //     Numeric keypad '+'.
    //     ///
    KeypadPlus = 270,
    //
    // Summary:
    //     ///
    //     Numeric keypad enter.
    //     ///
    KeypadEnter = 271,
    //
    // Summary:
    //     ///
    //     Numeric keypad '='.
    //     ///
    KeypadEquals = 272,
    //
    // Summary:
    //     ///
    //     Up arrow key.
    //     ///
    UpArrow = 273,
    //
    // Summary:
    //     ///
    //     Down arrow key.
    //     ///
    DownArrow = 274,
    //
    // Summary:
    //     ///
    //     Right arrow key.
    //     ///
    RightArrow = 275,
    //
    // Summary:
    //     ///
    //     Left arrow key.
    //     ///
    LeftArrow = 276,
    //
    // Summary:
    //     ///
    //     Insert key key.
    //     ///
    Insert = 277,
    //
    // Summary:
    //     ///
    //     Home key.
    //     ///
    Home = 278,
    //
    // Summary:
    //     ///
    //     End key.
    //     ///
    End = 279,
    //
    // Summary:
    //     ///
    //     Page up.
    //     ///
    PageUp = 280,
    //
    // Summary:
    //     ///
    //     Page down.
    //     ///
    PageDown = 281,
    //
    // Summary:
    //     ///
    //     F1 function key.
    //     ///
    F1 = 282,
    //
    // Summary:
    //     ///
    //     F2 function key.
    //     ///
    F2 = 283,
    //
    // Summary:
    //     ///
    //     F3 function key.
    //     ///
    F3 = 284,
    //
    // Summary:
    //     ///
    //     F4 function key.
    //     ///
    F4 = 285,
    //
    // Summary:
    //     ///
    //     F5 function key.
    //     ///
    F5 = 286,
    //
    // Summary:
    //     ///
    //     F6 function key.
    //     ///
    F6 = 287,
    //
    // Summary:
    //     ///
    //     F7 function key.
    //     ///
    F7 = 288,
    //
    // Summary:
    //     ///
    //     F8 function key.
    //     ///
    F8 = 289,
    //
    // Summary:
    //     ///
    //     F9 function key.
    //     ///
    F9 = 290,
    //
    // Summary:
    //     ///
    //     F10 function key.
    //     ///
    F10 = 291,
    //
    // Summary:
    //     ///
    //     F11 function key.
    //     ///
    F11 = 292,
    //
    // Summary:
    //     ///
    //     F12 function key.
    //     ///
    F12 = 293,
    //
    // Summary:
    //     ///
    //     Numlock key.
    //     ///
    Numlock = 300,
    //
    // Summary:
    //     ///
    //     Capslock key.
    //     ///
    CapsLock = 301,
    //
    // Summary:
    //     ///
    //     Scroll lock key.
    //     ///
    RightShift = 303,
    //
    // Summary:
    //     ///
    //     Left shift key.
    //     ///
    LeftShift = 304,
    //
    // Summary:
    //     ///
    //     Right Control key.
    //     ///
    RightControl = 305,
    //
    // Summary:
    //     ///
    //     Left Control key.
    //     ///
    LeftControl = 306,
    //
    // Summary:
    //     ///
    //     Right Alt key.
    //     ///
    RightAlt = 307,
    //
    // Summary:
    //     ///
    //     Left Alt key.
    //     ///
    LeftAlt = 308,
}

﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// A reference t o the useable on the actionbutton
    /// </summary>
    public IUseable MyUseable { get; set; }

    /// <summary>
    /// A reference to the actual button that this button uses
    /// </summary>
    public Button MyButton { get; private set; }

    public Image MyIcon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    [SerializeField]
    private Image icon;

    // Use this for initialization
    void Start ()
    {
        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// This is executed the the button is clicked
    /// </summary>
    public void OnClick()
    {
        if (MyUseable != null)
        {
            MyUseable.Use();
        }
    }

    /// <summary>
    /// Checks if someone clicked on the actionbutton
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (HandScript.MyInstance.MyMoveable != null && HandScript.MyInstance.MyMoveable is IUseable)
            {
                SetUseable(HandScript.MyInstance.MyMoveable as IUseable); 
            }
        }
    }

    /// <summary>
    /// Sets the useable on an actionbutton
    /// </summary>
    public void SetUseable(IUseable useable)
    {
        this.MyUseable = useable;

        UpdateVisual();
    }

    /// <summary>
    /// Updates the visual representation of the actionbutton
    /// </summary>
    public void UpdateVisual() 
    {
        MyIcon.sprite = HandScript.MyInstance.Put().MyIcon;
        MyIcon.color = Color.white;
    }
}

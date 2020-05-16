using Godot;
using System;

public class DialogText : RichTextLabel
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    private string[] dialog = { "Hey! My name is Yaphet.", "Baby's First Dialog Box.", "Wahhhh Wahhhhhh." };
    private int pageNumber = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Set the text to be the dialog  array at a specific index
        BbcodeText = dialog[pageNumber];

        // Visible characters handles text visibility
        // This gives the DialogBox a scrolling effect (like Pokemon dialog boxes)
        VisibleCharacters = 0;
    }

    public override void _Input(InputEvent inputEvent)
    {
        // Check if the input was a mouse button and was the mouse button pressed down
        if (inputEvent is InputEventMouseButton && inputEvent.IsPressed())
        {
            // If the current onscreen amount of visible characters is greater than the Total Amount of Characters in the BBCode
            if (VisibleCharacters > GetTotalCharacterCount())
            {
                // If the current page number is less than the amount of elements in the dialog array
                if (pageNumber < dialog.Length - 1)
                {
                    // Increase the page number
                    pageNumber += 1;
                    // Set the new text to be the dialog at the index of pageNumber
                    BbcodeText = dialog[pageNumber];
                    // Reset visible characters back to zero
                    VisibleCharacters = 0;
                }
            }
            // Else they have clicked the mouse button down in the middle of the text scrolling
            else
            {
                // Set the visible characters to the length of the current dialog string
                VisibleCharacters = dialog[pageNumber].Length;
            }
        }
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }

    // Method connected to the timer function
    // This method is ran on an interval
    // This interval is set in the WaitTime field in the Inspector Panel
    // To connect the Timer to another Node:
    //      Select the related Timer Node
    //      Select the Node Panel
    //      Right-click on the timeout() field
    //      Select connect
    public void _on_Timer_timeout()
    {
        VisibleCharacters += 1;
    }
}

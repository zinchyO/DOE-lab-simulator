using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BadgingSystem : MonoBehaviour
{
    public InputField Username_InputField;
    public InputField Pin_InputField;
    public Text feedback_Message;
    public Button login_button;
    public Button clear_Button;
    private string enteredPIN = "";
    
    
    public void PinNumber(string number) //user enters a pin less than4 
    {
        if (enteredPIN.Length < 4)
        {
            enteredPIN += number;
            Pin_InputField.text = new string('*', enteredPIN.Length);
        }
    }
    
    public void ClearPin() // clear button connection
    {
        enteredPIN = "";
        Pin_InputField.text = "";
    }

    public void Login() //temp login 2 test
    {
        string username = Username_InputField.text;
        if (Username_InputField.text == "admin" && enteredPIN == "1234")
        {
            feedback_Message.text = "Login Successful";
            Debug.Log("Login Successful");
            SaveLoginData(username);
            //LoadCleanRoomScene(); 
            //load scene once its all working together
        }
        else
        {   //feedback text field should change to reflect user actions
            feedback_Message.text = "Invalid Username or Pin";
            Debug.Log("Invalid Username or Pin");
        }
    }
    private void SaveLoginData(string username) //temp bc loging in isn't tested yet
    {
        PlayerPrefs.SetString("Username", username);
        PlayerPrefs.SetString("LoginTimestamp", System.DateTime.Now.ToString("o"));
        PlayerPrefs.Save();
    }
    
}

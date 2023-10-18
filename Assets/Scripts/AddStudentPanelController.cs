using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddStudentPanelController : MonoBehaviour
{
    
    public InputField surnameInput;
    public InputField nameInput;
    public InputField patronymicInput;
    public InputField birthInput;
    public InputField facultyInput;
    public InputField courseInput;
    public InputField groupInput;
    public MenuController menuController;

    public void AddStudentButtonClicked()
    {
        if (surnameInput != null && nameInput != null && patronymicInput != null && birthInput != null &&
            facultyInput != null && courseInput != null && groupInput != null)
        {
            var surname = surnameInput.text;
            var name = nameInput.text;
            var patronymic = patronymicInput.text;
            var birth = DateTime.ParseExact(birthInput.text, "dd.MM.yyyy", null);
            var faculty = facultyInput.text;
            int course = int.Parse(courseInput.text);
            int group = int.Parse(groupInput.text);

            if (menuController != null) 
            {
                menuController.AddStudent(surname, name, patronymic, birth, faculty, course, group);
            }
            
            else 
            {
                Debug.LogError("menuController is null");
            }
        }
        
        else
        {
            Debug.LogError("One or more input fields are null");
        }
    }
}
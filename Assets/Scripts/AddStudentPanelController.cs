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
        var surname = surnameInput.text;
        var name = nameInput.text;
        var patronymic = patronymicInput.text;
        var birth = DateTime.ParseExact(birthInput.text, "dd.MM.yyyy", null);
        var faculty = facultyInput.text;
        var coursee = courseInput.text;
        var group = groupInput.text;

        menuController.AddStudent(surname, name, patronymic, birth, faculty, courseInput.text, group);
    }
}
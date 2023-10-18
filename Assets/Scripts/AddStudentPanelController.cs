using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddStudentPanelController : MonoBehaviour
{
    public InputField nameInput;
    public InputField surnameInput;
    public InputField ageInput;
    public InputField groupInput;
    public MenuController menuController;

    public void AddStudentButtonClicked()
    {
        var name = nameInput.text;
        var surname = surnameInput.text;
        var age = int.Parse(ageInput.text);
        var group = groupInput.text;

        menuController.AddStudent(name, surname, age, group);
    }
}

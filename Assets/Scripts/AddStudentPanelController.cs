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

    public void OnAddButtonClicked()
    {
        string surname = surnameInput.text;
        string name = nameInput.text;
        string patronymic = patronymicInput.text;
        DateTime birth = Convert.ToDateTime(birthInput.text);
        string faculty = facultyInput.text;
        int course = int.Parse(courseInput.text);
        int group = int.Parse(groupInput.text);

        menuController.AddStudent(surname, name, patronymic, birth, faculty, course, group);

        surnameInput.text = "";
        nameInput.text = "";
        patronymicInput.text = "";
        birthInput.text = "";
        facultyInput.text = "";
        courseInput.text = "";
        groupInput.text = "";

        gameObject.SetActive(false);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject addPersonPanel;
    public GameObject editPersonPanel;
    public GameObject deletePersonPanel;

    private List<Human> people = new List<Human>();

    public void AddButtonClicked()
    {
        addPersonPanel.SetActive(true);
        editPersonPanel.SetActive(false);
        deletePersonPanel.SetActive(false);
    }

    public void EditButtonClicked()
    {
        addPersonPanel.SetActive(false);
        editPersonPanel.SetActive(true);
        deletePersonPanel.SetActive(false);
    }

    public void DeleteButtonClicked()
    {
        addPersonPanel.SetActive(false);
        editPersonPanel.SetActive(false);
        deletePersonPanel.SetActive(true);
    }

    public void AddStudent(string surname, string name, string patronymic, DateTime birth, string faculty, int course, int group)
    {
        var student = new Student(surname, name, patronymic, birth, faculty, course, group);
        people.Add(student);
        Debug.Log("Студент добавлен:\n" + student.Print());
    }

    public void EditStudent(string surname)
    {
        var studentToEdit = people.Find(p => p.Surname == surname);

        if (studentToEdit != null)
        {
            studentToEdit.Edit();
            Debug.Log("Данные студента изменены:\n" + studentToEdit.Print());
        }
        else
        {
            Debug.Log("Студент с такой фамилией не найден");
        }
    }

    public void DeleteStudent(string surname)
    {
        var studentToDelete = people.Find(p => p.Surname == surname);

        if (studentToDelete != null)
        {
            people.Remove(studentToDelete);
            Debug.Log("Данные студента удалены");
        }
        else
        {
            Debug.Log("Студент с такой фамилией не найден");
        }
    }

}
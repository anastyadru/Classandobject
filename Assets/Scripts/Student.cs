using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Student : Human
{
    private string Faculty { get; set; }
        
    private int Course { get; set; }
        
    private int Group { get; set; }

    public Student(string surname, string name, string patronymic, DateTime birth, string faculty, int course, int group): base(surname, name, patronymic, birth)
    {
        Faculty = faculty;
        Course = course;
        Group = group;
    }

    public new string Print()
    {
        return $"{base.Print()}, Факультет: {Faculty}, Курс: {Course}, Группа: {Group}";
    }

    public override void Edit()
    {
        base.Edit();
        var fieldToEdit = int.Parse(Console.ReadLine());
            
        switch (fieldToEdit)
        {
            case 1:
                Debug.Log("Введите новый факультет: ");
                Faculty = Console.ReadLine();
                break;
                
            case 2:
                Debug.Log("Введите новый курс: ");
                Course = int.Parse(Console.ReadLine());
                break;
                
            case 3:
                Debug.Log("Введите новую группу: ");
                Group = int.Parse(Console.ReadLine());
                break;

            default:
                Debug.Log("Некорректный ввод");
                break;
        }
    }

    public override void Display()
    {
        base.Display();
        Debug.Log($"Факультет: {Faculty}");
        Debug.Log($"Курс: {Course}");
        Debug.Log($"Группа: {Group}");
    }

}
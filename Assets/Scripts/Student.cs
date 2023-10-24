using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Student : Human
{
    public string Faculty { get; set; }
        
    public int Course { get; set; }
        
    public int Group { get; set; }

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
                Console.WriteLine("Введите новый факультет: ");
                Faculty = Console.ReadLine();
                break;
                
            case 2:
                Console.WriteLine("Введите новый курс: ");
                Course = int.Parse(Console.ReadLine());
                break;
                
            case 3:
                Console.WriteLine("Введите новую группу: ");
                Group = int.Parse(Console.ReadLine());
                break;

            default:
                Console.WriteLine("Некорректный ввод");
                break;
        }
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Факультет: {Faculty}");
        Console.WriteLine($"Курс: {Course}");
        Console.WriteLine($"Группа: {Group}");
    }

}
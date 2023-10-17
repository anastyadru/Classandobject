using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Human : MonoBehaviour
{
    public string Surname { get; set; }

    public string Name { get; set; }

    public string Patronymic { get; set; }

    public DateTime BirthDate { get; set; }

    public Human(string surname, string name, string patronymic, DateTime birth)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
        BirthDate = birth;
    }

    public int CalculateAge()
    {
        var age = DateTime.Now.Year - BirthDate.Year;
        if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
            age--;
        return age;
    }

    public string Print()
    {
        return $"Фамилия: {Surname}, Имя: {Name}, Отчество: {Patronymic}, Дата рождения: {BirthDate}, Возраст: {CalculateAge()}";
    }
        
    public virtual void Edit()
    {
        var fieldToEdit = int.Parse(Console.ReadLine());
            
        switch (fieldToEdit)
        {
            case 1:
                Console.WriteLine("Введите новую фамилию: ");
                Surname = Console.ReadLine();
                break;
                
            case 2:
                Console.WriteLine("Введите новое имя: ");
                Name = Console.ReadLine();
                break;
                
            case 3:
                Console.WriteLine("Введите новое отчество: ");
                Patronymic = Console.ReadLine();
                break;
                
            case 4:
                Console.WriteLine("Введите новую дату рождения: ");
                BirthDate = DateTime.Parse(Console.ReadLine());
                break;
                
            default:
                Console.WriteLine("Некорректный ввод");
                break;
        }
    }

    public virtual void Display()
    {
        Console.WriteLine($"ФИО: {Surname} {Name} {Patronymic}");
        Console.WriteLine($"Возраст: {CalculateAge()}");
    }
}
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

    public void OnAddButtonClicked()
    {
        Debug.Log("Данные студента добавлены:\n" + Print());
    }

    public void OnEditButtonClicked()
    {
        Edit();
        Debug.Log("Данные студента изменены:\n" + Print());
	}

    public void OnDeleteButtonClicked() 
    {
        Debug.Log("Данные студента удалены");
	}

}    
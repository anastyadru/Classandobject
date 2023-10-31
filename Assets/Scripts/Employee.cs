using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Employee : Human
{
    private string Company { get; set; }
    
    private int Salary { get; set; }

    private int Experience { get; set; }

        
    public Employee(string surname, string name, string patronymic, DateTime  birth, string company, int salary, int experience): base(surname, name, patronymic, birth)
    {
        Company = company;
        Salary = salary;
        Experience = experience;
    }

    public new string Print()
    {
        return $"{base.Print()}, Компания: {Company}, ЗП: {Salary}, Опыт работы: {Experience}";
    }
        
    public override void Edit()
    {
        base.Edit();
        var fieldToEdit = int.Parse(Console.ReadLine());
            
        switch (fieldToEdit)
        {
            case 1:
                Debug.Log("Введите новую компанию: ");
                Company = Console.ReadLine();
                break;
                
            case 2:
                Debug.Log("Введите новую зарплату: ");
                Salary = int.Parse(Console.ReadLine());
                break;
                
            case 3:
                Debug.Log("Введите новый опыт работы: ");
                Experience = int.Parse(Console.ReadLine());
                break;
                
            default:
                Debug.Log("Некорректный ввод");
                break;
        }
    }

    public override void Display()
    {
        base.Display();
        Debug.Log($"Компания: {Company}");
        Debug.Log($"Зарплата: {Salary}");
        Debug.Log($"Опыт работы: {Experience}");
    }

}
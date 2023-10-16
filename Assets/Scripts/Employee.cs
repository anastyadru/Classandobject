using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Employee : Human
{
    public string Company { get; set; }
    
    public int Salary { get; set; }

    public int Experience { get; set; }

        
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
                Console.WriteLine("Введите новую компанию: ");
                Company = Console.ReadLine();
                break;
                
            case 2:
                Console.WriteLine("Введите новую зарплату: ");
                Salary = int.Parse(Console.ReadLine());
                break;
                
            case 3:
                Console.WriteLine("Введите новый опыт работы: ");
                Experience = int.Parse(Console.ReadLine());
                break;
                
            default:
                Console.WriteLine("Некорректный ввод");
                break;
        }
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Компания: {Company}");
        Console.WriteLine($"Зарплата: {Salary}");
        Console.WriteLine($"Опыт работы: {Experience}");
    }
    
    public void OnAddButtonClicked()
    {
        Debug.Log("Данные работника добавлены:\n" + Print());
    }

    public void OnEditButtonClicked()
    {
        Edit();
        Debug.Log("Данные работника изменены:\n" + Print());
    }

    public void OnDeleteButtonClicked() 
    {
        Debug.Log("Данные работника удалены");
    }
        
}
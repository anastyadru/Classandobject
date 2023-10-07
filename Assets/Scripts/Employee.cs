using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Employee : IHuman, MonoBehaviour
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

    protected override void Display()
    {
        base.Display();
        Console.WriteLine($"Компания: {Company}");
        Console.WriteLine($"Зарплата: {Salary}");
        Console.WriteLine($"Опыт работы: {Experience}");
    }
        
}
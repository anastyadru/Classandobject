using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Driver : Employee
{
    private string Brand { get; set; }
        
    private string Model { get; set; }

    public Driver(string surname, string name, string patronymic, DateTime  birth, string company, int salary, int experience, string brand, string model): base(surname, name, patronymic, birth, company, salary, experience)
    {
        Brand = brand;
        Model = model;
    }

    public new string Print()
    {
        return $"{base.Print()}, Бренд: {Brand}, Модель: {Model}";
    }
        
    public override void Edit()
    {
        base.Edit();
        var fieldToEdit = int.Parse(Console.ReadLine());
            
        switch (fieldToEdit)
        {
            case 1:
                Debug.Log("Введите новый бренд: ");
                Brand = Console.ReadLine();
                break;
                
            case 2:
                Debug.Log("Введите новую модель: ");
                Model = Console.ReadLine();
                break;
                
            default:
                Debug.Log("Некорректный ввод");
                break;
        }
    }

    public override void Display()
    {
        base.Display();
        Debug.Log($"Бренд: {Brand}");
        Debug.Log($"Модель: {Model}");
    }

}
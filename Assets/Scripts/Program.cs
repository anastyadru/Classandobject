using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Program : MonoBehaviour
{
    static void Main(string[] args)
    {
        List<Human> people = new List<Human>();

        Console.Write("Выберите, какое действие хотите выполнить:\n1) Добавить \n2) Изменить \n3) Удалить \nВаше решение: ");
        var action = int.Parse(Console.ReadLine());

        switch (action)
        {
            case 1:
                    
                AddPerson(people);
                break;
                
            case 2:
                    
                EditPerson(people);
                break;
                
            case 3:
                    
                DeletePerson(people);
                break;
        }
    }

    static void AddPerson(List<Human> people)
    {
        Console.WriteLine("Введите фамилию: ");
        var surname = Console.ReadLine();

        Console.WriteLine("Введите имя: ");
        var name = Console.ReadLine();

        Console.WriteLine("Введите отчество: ");
        var patronymic = Console.ReadLine();

        Console.WriteLine("Введите дату рождения в формате ДД.ММ.ГГГГ: ");
        var birth = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Выберите, кого хотите добавить:\n1) student \n2) employee \n3) driver \nВаше решение: ");
        var person = int.Parse(Console.ReadLine());

        switch (person)
        {
            case 1:

                Console.Write("Введите факультет: ");
                var faculty = Console.ReadLine();

                Console.Write("Введите курс: ");
                var course = int.Parse(Console.ReadLine());

                Console.Write("Введите группу: ");
                var group = int.Parse(Console.ReadLine());

                Student student = new Student(surname, name, patronymic, birth, faculty, course, group);
                people.Add(student);

                Console.WriteLine("Данные студента добавлены:\n" + student.Print());

                break;

            case 2:

                Console.Write("Введите название компании: ");
                var company = Console.ReadLine();

                Console.Write("Введите заработную плату: ");
                var salary = int.Parse(Console.ReadLine());

                Console.Write("Введите опыт работы: ");
                var experience = int.Parse(Console.ReadLine());

                Employee employee = new Employee(surname, name, patronymic, birth, company, salary, experience);
                people.Add(employee);

                Console.WriteLine("Данные работника добавлены:\n" + employee.Print());

                break;

            case 3:

                Console.Write("Введите название компании: ");
                var company3 = Console.ReadLine();

                Console.Write("Введите заработную плату: ");
                var salary3 = int.Parse(Console.ReadLine());

                Console.Write("Введите опыт работы: ");
                var experience3 = int.Parse(Console.ReadLine());

                Console.Write("Введите бренд: ");
                var brand = Console.ReadLine();

                Console.Write("Введите модель: ");
                var model = Console.ReadLine();

                Driver driver = new Driver(surname, name, patronymic, birth, company3, salary3, experience3, brand, model);
                people.Add(driver);

                Console.WriteLine("Данные водителя добавлены:\n" + driver.Print());

                break;
        }
    }
        
    static void EditPerson(List<Human> people)
    {
        Console.WriteLine("Введите фамилию человека, данные которого хотите изменить: ");
        var surnameToEdit = Console.ReadLine();
                    
        var personToEdit = people.Find(p => p.Surname == surnameToEdit);

        if (personToEdit != null)
        {
            personToEdit.Edit();
            Console.WriteLine("Изменения сохранены");
        }
                    
        else
        {
            Console.WriteLine("Человек с такой фамилией не найден");
        }
    }
        
    static void DeletePerson(List<Human> people)
    {
        Console.WriteLine("Введите фамилию человека, данные которого хотите удалить: ");
        var surnameToDelete = Console.ReadLine();
                    
        var personToDelete = people.Find(p => p.Surname == surnameToDelete);

        if (personToDelete != null)
        {
            people.Remove(personToDelete);
            Console.WriteLine("Информация о человеке удалена");
        }
        
        else
        {
            Console.WriteLine("Человек с такой фамилией не найден");
        }
    }
    
}
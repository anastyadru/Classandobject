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

        if (Input.GetKey(KeyCode.StudentButton))
        {

            Console.Write("Введите факультет: ");
            var faculty = Console.ReadLine();

            Console.Write("Введите курс: ");
            var course = int.Parse(Console.ReadLine());

            Console.Write("Введите группу: ");
            var group = int.Parse(Console.ReadLine());

            Student student = new Student(surname, name, patronymic, birth, faculty, course, group);
            people.Add(student);

            Console.WriteLine("Данные студента добавлены:\n" + student.Print());
        }

        else if (Input.GetKey(KeyCode.EmployeeButton))
        {

            Console.Write("Введите название компании: ");
            var company = Console.ReadLine();

            Console.Write("Введите заработную плату: ");
            var salary = int.Parse(Console.ReadLine());

            Console.Write("Введите опыт работы: ");
            var experience = int.Parse(Console.ReadLine());

            Employee employee = new Employee(surname, name, patronymic, birth, company, salary, experience);
            people.Add(employee);

            Console.WriteLine("Данные работника добавлены:\n" + employee.Print());
        }

        else if (Input.GetKey(KeyCode.DriverButton))
        {

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
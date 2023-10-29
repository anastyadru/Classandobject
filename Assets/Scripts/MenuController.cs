using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public void AddHuman()
    {
        Console.WriteLine("Введите фамилию: ");
        var surname = Console.ReadLine();

        Console.WriteLine("Введите имя: ");
        var name = Console.ReadLine();

        Console.WriteLine("Введите отчество: ");
        var patronymic = Console.ReadLine();

        Console.WriteLine("Введите дату рождения в формате ДД.ММ.ГГГГ: ");
        var birth = Convert.ToDateTime(Console.ReadLine());
        
        Human human = new Human(surname, name, patronymic, birth);
        people.Add(human);

        Console.WriteLine("Выберите тип человека (0 - студент, 1 - работник, 2 - водитель):");
        int personType = int.Parse(Console.ReadLine());

        if (personType == 0)
        {
            Console.WriteLine("Введите факультет: ");
            var faculty = Console.ReadLine();

            Console.WriteLine("Введите курс: ");
            var course = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите группу: ");
            var group = int.Parse(Console.ReadLine());

            Student student = new Student(surname, name, patronymic, birth, faculty, course, group);
            people.Add(student);

            Console.WriteLine("Данные студента добавлены:\n" + student.Print());
        }
        
        else if (personType == 1)
        {
            string company = companyInput.text;
            int salary = int.Parse(salaryInput.text);
            int experience = int.Parse(experienceInput.text);
            
            Employee employee = new Employee(surname, name, patronymic, birth, company, salary, experience);
            people.Add(employee);
            
            Debug.Log("Данные работника добавлены:\n" + employee.Print());
        }
        
        else if (personType == 2)
        {
            string company3 = companyInput.text;
            int salary3 = int.Parse(salaryInput.text);
            int experience3 = int.Parse(experienceInput.text);
            string brand = brandInput.text;
            string model = modelInput.text;
            
            Driver driver = new Driver(surname, name, patronymic, birth, company3, salary3, experience3, brand, model);
            people.Add(driver);

            Debug.Log("Данные водителя добавлены:\n" + driver.Print());
        }
    }
        
    public void EditHuman()
    {
        string surname = surnameInput.text;
                    
        var personToEdit = people.Find(p => p.Surname == surname);

        if (personToEdit != null)
        {
            personToEdit.Edit();
            Debug.Log("Изменения сохранены");
        }
                    
        else
        {
            Debug.Log("Человек с такой фамилией не найден");
        }
    }
        
    public void DeleteHuman()
    {
        string surname = surnameInput.text;
                    
        var personToDelete = people.Find(p => p.Surname == surname);

        if (personToDelete != null)
        {
            people.Remove(personToDelete);
            Debug.Log("Информация о человеке удалена");
        }
        
        else
        {
            Debug.Log("Человек с такой фамилией не найден");
        }
    }

}
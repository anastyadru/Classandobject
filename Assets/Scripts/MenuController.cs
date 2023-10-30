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
		AddPerson();
    }

    public void EditButtonClicked()
    {
        addPersonPanel.SetActive(false);
        editPersonPanel.SetActive(true);
        deletePersonPanel.SetActive(false);
		EditPerson();
    }

    public void DeleteButtonClicked()
    {
        addPersonPanel.SetActive(false);
        editPersonPanel.SetActive(false);
        deletePersonPanel.SetActive(true);
		DeletePerson();
    }

    private void AddPerson()
    {
        Console.WriteLine("Введите фамилию:");
        var surname = Console.ReadLine();

        Console.WriteLine("Введите имя:");
        var name = Console.ReadLine();

        Console.WriteLine("Введите отчество:");
        var patronymic = Console.ReadLine();

        Console.WriteLine("Введите дату рождения в формате ДД.ММ.ГГГГ:");
        DateTime birth;
        while (!DateTime.TryParse(Console.ReadLine(), out birth))
        {
            Console.WriteLine("Некорректный формат даты. Попробуйте еще раз.");
        }
        
        Human human = new Human(surname, name, patronymic, birth);
        people.Add(human);

        Console.WriteLine("Выберите тип человека (0 - студент, 1 - работник, 2 - водитель):");
        int personType = int.Parse(Console.ReadLine());

        if (personType == 0)
        {
            Console.WriteLine("Введите факультет:");
            var faculty = Console.ReadLine();

            Console.WriteLine("Введите курс:");
            int course;
            while (!int.TryParse(Console.ReadLine(), out course) || course < 1)
            {
            	Console.WriteLine("Некорректный курс. Попробуйте еще раз.");
            }

            Console.WriteLine("Введите группу:");
            int group;
            while (!int.TryParse(Console.ReadLine(), out group) || group < 1)
            {
            	Console.WriteLine("Некорректная группа. Попробуйте еще раз.");
            }

            Student student = new Student(surname, name, patronymic, birth, faculty, course, group);
            people.Add(student);

            Console.WriteLine("Данные студента добавлены:\n" + student.Print());
        }
        
        else if (personType == 1)
        {
            Console.WriteLine("Введите название компании:");
            var company = Console.ReadLine();
        
            Console.WriteLine("Введите заработную плату:");
            int salary;
            while (!int.TryParse(Console.ReadLine(), out salary) || salary < 0)
            {
				Console.WriteLine("Некорректная заработная плата. Попробуйте еще раз.");
            }
        
            Console.WriteLine("Введите стаж работы:");
            int experience;
            while (!int.TryParse(Console.ReadLine(), out experience) || experience < 0)
            {
            	Console.WriteLine("Некорректный стаж работы. Попробуйте еще раз.");
            }
            
            Employee employee = new Employee(surname, name, patronymic, birth, company, salary, experience);
            people.Add(employee);
            
            Console.WriteLine("Данные работника добавлены:\n" + employee.Print());
        }
        
        else if (personType == 2)
        {
            Console.WriteLine("Введите название компании:");
            var company3 = Console.ReadLine();
        
            Console.WriteLine("Введите заработную плату:");
            int salary3;
            while (!int.TryParse(Console.ReadLine(), out salary) || salary < 0)
            {
            	Console.WriteLine("Некорректная заработная плата. Попробуйте еще раз.");
            }
        
            Console.WriteLine("Введите опыт работы:");
            int experience3;
            while (!int.TryParse(Console.ReadLine(), out experience) || experience < 0)
            {
            	Console.WriteLine("Некорректный опыт работы. Попробуйте еще раз.");
            }
        
            Console.WriteLine("Введите бренд:");
            var brand = Console.ReadLine();
        
            Console.WriteLine("Введите модель:");
            var model = Console.ReadLine();
            
            Driver driver = new Driver(surname, name, patronymic, birth, company3, salary3, experience3, brand, model);
            people.Add(driver);

            Console.WriteLine("Данные водителя добавлены:\n" + driver.Print());
        }
    }
        
   
	private void EditPerson()
    {
        Console.WriteLine("Введите фамилию человека, данные которого хотите изменить:");
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
        
    private void DeletePerson()
    {
        Console.WriteLine("Введите фамилию человека, данные которого хотите удалить:");
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
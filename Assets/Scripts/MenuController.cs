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
        Debug.Log("Введите фамилию:");
        var surname = Console.ReadLine();

        Debug.Log("Введите имя:");
        var name = Console.ReadLine();

        Debug.Log("Введите отчество:");
        var patronymic = Console.ReadLine();

        Debug.Log("Введите дату рождения в формате ДД.ММ.ГГГГ:");
        DateTime birth;
        while (!DateTime.TryParse(Console.ReadLine(), out birth))
        {
        	Debug.Log("Некорректный формат даты. Попробуйте еще раз.");
        }

        Debug.Log("Выберите тип человека (0 - студент, 1 - работник, 2 - водитель):");
        int personType = int.Parse(Console.ReadLine());

        if (personType == 0)
        {
            Debug.Log("Введите факультет:");
            var faculty = Console.ReadLine();

            Debug.Log("Введите курс:");
            int course;
            while (!int.TryParse(Console.ReadLine(), out course) || course < 1)
            {
            	Debug.Log("Некорректный курс. Попробуйте еще раз.");
            }

            Debug.Log("Введите группу:");
            int group;
            while (!int.TryParse(Console.ReadLine(), out group) || group < 1)
            {
            	Debug.Log("Некорректная группа. Попробуйте еще раз.");
            }

            Student student = new Student(surname, name, patronymic, birth, faculty, course, group);
            people.Add(student);

            Debug.Log("Данные студента добавлены:\n" + student.Print());
        }
        
        else if (personType == 1)
        {
            Debug.Log("Введите название компании:");
            var company = Console.ReadLine();
        
            Debug.Log("Введите заработную плату:");
            int salary;
            while (!int.TryParse(Console.ReadLine(), out salary) || salary < 0)
            {
				Debug.Log("Некорректная заработная плата. Попробуйте еще раз.");
            }
        
            Debug.Log("Введите стаж работы:");
            int experience;
            while (!int.TryParse(Console.ReadLine(), out experience) || experience < 0)
            {
            	Debug.Log("Некорректный стаж работы. Попробуйте еще раз.");
            }
            
            Employee employee = new Employee(surname, name, patronymic, birth, company, salary, experience);
            people.Add(employee);
            
            Debug.Log("Данные работника добавлены:\n" + employee.Print());
        }
        
        else if (personType == 2)
        {
            Debug.Log("Введите название компании:");
            var company3 = Console.ReadLine();
        
            Debug.Log("Введите заработную плату:");
            int salary3;
            while (!int.TryParse(Console.ReadLine(), out salary3) || salary3 < 0)
            {
            	Debug.Log("Некорректная заработная плата. Попробуйте еще раз.");
            }
        
            Debug.Log("Введите опыт работы:");
            int experience3;
            while (!int.TryParse(Console.ReadLine(), out experience3) || experience3 < 0)
            {
            	Debug.Log("Некорректный опыт работы. Попробуйте еще раз.");
            }
        
            Debug.Log("Введите бренд:");
            var brand = Console.ReadLine();
        
            Debug.Log("Введите модель:");
            var model = Console.ReadLine();
            
            Driver driver = new Driver(surname, name, patronymic, birth, company3, salary3, experience3, brand, model);
            people.Add(driver);

        	Debug.Log("Данные водителя добавлены:\n" + driver.Print());
        }
    }
        
   
	private void EditPerson()
    {
        Debug.Log("Введите фамилию человека, данные которого хотите изменить:");
        var surnameToEdit = Console.ReadLine();
                    
        var personToEdit = people.Find(p => p.Surname == surnameToEdit);

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
        
    private void DeletePerson()
    {
        Debug.Log("Введите фамилию человека, данные которого хотите удалить:");
        var surnameToDelete = Console.ReadLine();
                    
        var personToDelete = people.Find(p => p.Surname == surnameToDelete);

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
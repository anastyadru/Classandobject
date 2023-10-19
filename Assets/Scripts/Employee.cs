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

public class Program
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

public class MenuController : MonoBehaviour
{
    public GameObject addEmployeePanel;
    public GameObject editEmployeePanel;
    public GameObject deleteEmployeePanel;

    private List<Human> people = new List<Human>();

    public void AddButtonClicked()
    {
        addEmployeePanel.SetActive(true);
        editEmployeePanel.SetActive(false);
        deleteEmployeePanel.SetActive(false);
    }

    public void EditButtonClicked()
    {
        addEmployeePanel.SetActive(false);
        editEmployeePanel.SetActive(true);
        deleteEmployeePanel.SetActive(false);
    }

    public void DeleteButtonClicked()
    {
        addEmployeePanel.SetActive(false);
        editEmployeePanel.SetActive(false);
        deleteEmployeePanel.SetActive(true);
    }

    public void AddEmployee(string surname, string name, string patronymic, DateTime birth, string company, int salary, int experience)
    {
        var employee = new Employee(surname, name, patronymic, birth, company, salary, experience);
        people.Add(employee);
        Debug.Log("Работник добавлен:\n" + employee.Print());
    }

    public void EditEmployee(string surname)
    {
        var employeeToEdit = people.Find(p => p.Surname == surname);

        if (employeeToEdit != null)
        {
            employeeToEdit.Edit();
            Debug.Log("Данные работника изменены:\n" + employeeToEdit.Print());
        }
        else
        {
            Debug.Log("Работник с такой фамилией не найден");
        }
    }

    public void DeleteEmployee(string surname)
    {
        var employeeToDelete = people.Find(p => p.Surname == surname);

        if (employeeToDelete != null)
        {
            people.Remove(employeeToDelete);
            Debug.Log("Данные работника удалены");
        }
        else
        {
            Debug.Log("Работник с такой фамилией не найден");
        }
    }
}
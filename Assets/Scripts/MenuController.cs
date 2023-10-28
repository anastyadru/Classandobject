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
    
    public Text surnameInput;
    public Text nameInput;
    public Text patronymicInput;
    public Text birthInput;
    public Dropdown personDropdown;

    public Text facultyInput;
    public Text courseInput;
    public Text groupInput;

    public Text companyInput;
    public Text salaryInput;
    public Text experienceInput;

    public Text brandInput;
    public Text modelInput;

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
        string surname = surnameInput.text;
        string name = nameInput.text;
        string patronymic = patronymicInput.text;
        string birthString = birthInput.text;
        var birth = System.DateTime.Parse(birthString);
        
        Human human = new Human(surname, name, patronymic, birth);
        people.Add(human);

        int personType = personDropdown.value;

        if (personType == 0)
        {
            string faculty = facultyInput.text;
            int course = int.Parse(courseInput.text);
            int group = int.Parse(groupInput.text);

            Student student = new Student(surname, name, patronymic, birth, faculty, course, group);
            people.Add(student);

            Debug.Log("Данные студента добавлены:\n" + student.Print());
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
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//  TODO : Move to "Mod_9_Homework"
namespace Module9
{
	//	1. Event handler created for the Create Student button
			
	//	2. Event handler creates a Student object using values from the text boxes on the form
	//	3. Textbox values are cleared
	//	4. Event handler adds a Student object to the List<T>
	//	5. Next button displays each student's information in the text boxes
	//	6. Previous button displays each student's information in the text boxes


	public partial class MainWindow : Window
	{
		// Add a new class to the project to represent a Student with three properties for the text fields.  
		public class Student
		{
			public string FirstName { get; private set; }
			public string LastName { get; private set; }
			public string Program { get; private set; }

			public Student(string firstName, string lastName, string program)
			{
				FirstName = firstName;
				LastName = lastName;
				Program = program;
			}
		}

		// Create a collection to store Student objects.
		private readonly List<Student> _students = new List<Student>();
		private int _index;
		private bool _allowBlank;

		public MainWindow()
		{
			InitializeComponent();

			// Using the form and button, create a number of Student objects and add them to the collection (at least 3).
			// Uncomment the following line to use it
			//Loaded += MainWindow_Loaded;
		}

		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			const int studentCount = 3;
			for (var i = 0; i < studentCount; i++)
			{
				txtFirstName.Text = "Harry" + i;
				txtLastName.Text = "Potter" + i;
				txtCity.Text = "Little Whinging" + i;
				btnCreateStudent_Click(this, new RoutedEventArgs());
			}
		}

		// Implement the code in the button click event handler to create a Student object and add it to the collection.
		private void btnCreateStudent_Click(object sender, RoutedEventArgs e)
		{
			// they mixed program and city
			_students.Add(new Student(
				txtFirstName.Text.GetText(),
				txtLastName.Text.GetText(),
				txtCity.Text.GetText()));
			_index = _students.Count;

			// Clear the contents of the text boxes in the event handler.
			txtFirstName.Clear();
			txtLastName.Clear();
			txtCity.Clear();
		}

		// There are two additional buttons on the form that can be used to move through a collection of students.
		// Create event handlers for each of these buttons that will iterate over your Students collection
		// and display the values in the text boxes
		private void btnNext_Click(object sender, RoutedEventArgs e) { DisplayNext(true); }
		private void btnPrevious_Click(object sender, RoutedEventArgs e) { DisplayNext(false); }

		private void DisplayNext(bool isNext)
		{
			if ((isNext && _index + 1 > _students.Count)
				|| (!isNext && _index - 1 < 0))
				return;
			var student = isNext ? _students[_index++] : _students[--_index];

			// Use the syntax textbox.Text = <student property> for assigning the values
			// from a Student object to the text boxes
			txtFirstName.Text = student.FirstName;
			txtLastName.Text = student.LastName;
			txtCity.Text = student.Program;
		}
	}

	static class Extensions
	{
		public static string GetText(this string text)
		{
			return !String.IsNullOrWhiteSpace(text) ? text : String.Empty;
		}
	}
}

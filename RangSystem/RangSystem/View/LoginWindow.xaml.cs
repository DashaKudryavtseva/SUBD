using RangSystem.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace RangSystem.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        List<Teacher> teachers;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            List<Institute> institutes = new List<Institute>();                 //Список институтов
            List<Cathedra> cathedras = new List<Cathedra>();                    //Список кафедр
            teachers = new List<Teacher>();                       //Список преподавателей

            institutes = DBCommunicate.GetInstituteList();                      //Получение информации из БД
            cathedras = DBCommunicate.GetCathedraList();
            teachers = DBCommunicate.GetTeacherList();
            foreach (var temp in institutes)
            {
                comboBoxInstitute.Items.Add(temp.Name);                          //Запись в выпадающий список
            }
            foreach (var temp in cathedras)
            {
                comboBoxCathedra.Items.Add(temp.Name);                          //Запись в выпадающий список
            }
            foreach (var temp in teachers)
            {
                comboBoxTeacher.Items.Add(temp.FIO);                          //Запись в выпадающий список
            }
        }

        private void comboBoxInstitute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxTeacher.Items.Clear();
            comboBoxCathedra.Items.Clear();
            ObservableCollection<Cathedra> cathedras = new ObservableCollection<Cathedra>();
            cathedras = DBCommunicate.GetCathedraList(comboBoxInstitute.SelectedItem.ToString());
            foreach (var temp in cathedras)
            {
                comboBoxCathedra.Items.Add(temp.Name);                          //Запись в выпадающий список
            }
            //--ToDo комьоьокс тичер заполнить в соответсвии с выбранным институтом
            ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();
            teachers = DBCommunicate.GetTeacherListOnInst(comboBoxInstitute.SelectedItem.ToString());
            foreach (var temp in teachers)
            {
                comboBoxTeacher.Items.Add(temp.FIO);                          //Запись в выпадающий список
            }
        }

        private void comboBoxCathedra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxTeacher.Items.Clear();
            List<Teacher> teachers = new List<Teacher>();
            teachers = DBCommunicate.GetTeacherList(comboBoxCathedra.SelectedItem.ToString());
            foreach (var temp in teachers)
            {
                comboBoxTeacher.Items.Add(temp.FIO);                          //Запись в выпадающий список
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //--TODO сделать проверку на пароль

            //--Если пароль верный, то входим в мэйн
            Teacher teacher;
            foreach(var v in teachers)
            {
                if (v.FIO == comboBoxTeacher.Text)
                {
                    teacher = v;
                    MainWindow mainWindow = new MainWindow(teacher);
                    mainWindow.Show();
                    this.Close();
                    break;

                }
            }
        }
    }
}

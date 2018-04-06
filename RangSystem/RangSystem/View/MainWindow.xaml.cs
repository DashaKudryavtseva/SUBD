using RangSystem.Data;
using RangSystem.DataBase;
using RangSystem.View;
using RangSystem.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RangSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Discipline> disciplineList;
        ObservableCollection<Group> groupList;
        ControlsCollection controlsCollection;
        Teacher _teacher;
        public MainWindow(Teacher teacher)
        {
            InitializeComponent();
            _teacher = teacher;
            disciplineList = DBCommunicate.GetDisciplineList(teacher.Id);
            foreach (var v in disciplineList)
            {
                CBDiscInControl.Items.Add(v.Name);
            }
            

        }
        //заполнить список групп на основе выбранной дисциплины +
        private void CBDiscInControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (groupList != null)
            {
                groupList.Clear();
            }
            CBGroupInControl.Items.Clear();
            //ObservableCollection<Group> groups = new ObservableCollection<Group>();
            groupList = DBCommunicate.GetGroupListToControl(GetIdDiscipline(CBDiscInControl.SelectedItem.ToString()), _teacher.Id);
            foreach (var temp in groupList)
            {
                CBGroupInControl.Items.Add(temp.Name);                          //Запись в выпадающий список
            }

            DisplayControlsTable();
        }
        //показать таблицу промежуточного контроля
        private void DisplayControlsTable()
        {

            if(CBDiscInControl.SelectedItem != null && CBGroupInControl.SelectedItem != null)
            {
                
                controlsCollection = new ControlsCollection(_teacher.Id, 
                    GetIdDiscipline(CBDiscInControl.SelectedItem.ToString()),
                    GetIdGroup(CBGroupInControl.SelectedItem.ToString()));
                ControlViewModel controlViewModel = new ControlViewModel(controlsCollection.ControlList);
                DataGridControls.DataContext = controlViewModel;
               
            }
        }

        //получить Id дисциплины по ее названию
        private int GetIdDiscipline (string name)
        {
            foreach (var v in disciplineList)
            {
                if (v.Name == name)
                    return v.Id;
            }
            return -1;
        }
        //получить id группы по ее названию
        private int GetIdGroup(string name)
        {
            foreach (var v in groupList)
            {
                if (v.Name == name)
                    return v.Id;
            }
            return -1;
        }

        private void CBGroupInControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DisplayControlsTable();
        }

        private void DataGridControls_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //--помечает измененные экземпляры 
            IntermediateControl editControl = DataGridControls.SelectedItem as IntermediateControl;
            editControl.isEdit = true;
        }
        //--кнопка "сохранить контрол"
        private void btnControlSave_Click(object sender, RoutedEventArgs e)
        {
            controlsCollection.AllUpdate();
            MessageBox.Show("Данные успешно сохранены!");
        }

        private void AddInControlButton_Click(object sender, RoutedEventArgs e)
        {
            AddControlWindow addControlWindow = new AddControlWindow();
            if(addControlWindow.ShowDialog() == true)
            {

            }
        }
    }
}

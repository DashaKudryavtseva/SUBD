using RangSystem.Data;
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
        public MainWindow(Teacher teacher)
        {
            InitializeComponent();
            disciplineList = DBCommunicate.GetDisciplineList(teacher.IdTeacher);
            foreach (var v in disciplineList)
            {
                CBDiscInControl.Items.Add(v.Name);
            }
            

        }

        private void CBDiscInControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBGroupInControl.Items.Clear();
            ObservableCollection<Group> groups = new ObservableCollection<Group>();
            groups = DBCommunicate.GetGroupListToControl(GetIdDiscipline(CBDiscInControl.SelectedItem.ToString()));
            foreach (var temp in groups)
            {
                CBGroupInControl.Items.Add(temp.Name);                          //Запись в выпадающий список
            }
        }

        private int GetIdDiscipline (string name)
        {
            foreach (var v in disciplineList)
            {
                if (v.Name == name)
                    return v.ID;
            }
            return -1;
        }
    }
}

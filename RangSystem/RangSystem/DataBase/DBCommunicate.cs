using Npgsql;
using RangSystem.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace RangSystem.DataBase
{
    static class DBCommunicate
    {
        private static string connectionString = Properties.Settings.Default.ConnectionString; //строка подсоединения к бд
        //--Получить список институтов 
      
        //получить список институтов
        internal static List<Institute> GetInstituteList()
        {
            List<Institute> instList = new List<Institute>();
            try
            {
                NpgsqlConnection bd = new NpgsqlConnection(connectionString);
                bd.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT * FROM get_institutes();", bd);

                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

                if (npgSqlDataReader.HasRows) //--если такой логин есть в бд 
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        int id = dbDataRecord.GetInt32(0);
                        string name = dbDataRecord.GetString(1);
                        instList.Add(new Institute(name, id));
                    }
                }
                bd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex:" + ex.Message);
            }
            return instList;
        }

        internal static void UpdateControl(IntermediateControl control)
        {
            try
            {
                NpgsqlConnection bd = new NpgsqlConnection(connectionString);
                bd.Open();

                NpgsqlCommand npgSqlCommand = new NpgsqlCommand(
                    $"SELECT update_intermediate_control('{control.Id}','{control.IdTeacher}','{control.IdDiscipline}','{control.IdGroup}','{control.TypeOfControl}','{control.NumTasks}','{control.MaxBall}');", bd);
                npgSqlCommand.ExecuteNonQuery();
                bd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex:" + ex.Message);
            }
        }

        //получить список групп в окно зааолнения пром.контроля
        internal static ObservableCollection<Group> GetGroupListToControl(int idDisc)
        {
            ObservableCollection<Group> groupList = new ObservableCollection<Group>();
            try
            {
                NpgsqlConnection bd = new NpgsqlConnection(connectionString);
                bd.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT * FROM get_groups_on_discipline('{idDisc}');", bd);

                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

                if (npgSqlDataReader.HasRows) //--если такой логин есть в бд 
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        int idCathedra = dbDataRecord.GetInt32(0);
                        int idDirection = dbDataRecord.GetInt32(1);
                        int idGroup = dbDataRecord.GetInt32(2);
                        int numCourse = dbDataRecord.GetInt32(3);
                        string nameGroup = dbDataRecord.GetString(4);
                        groupList.Add(new Group(idCathedra, idDirection, idGroup, numCourse, nameGroup));
                    }
                }
                bd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex:" + ex.Message);
            }
            return groupList;
        }
        //получить список преподавателей выбранного института
        internal static ObservableCollection<Teacher> GetTeacherListOnInst(string nameInst)
        {
            ObservableCollection<Teacher> teacherList = new ObservableCollection<Teacher>();
            try
            {
                NpgsqlConnection bd = new NpgsqlConnection(connectionString);
                bd.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT * FROM get_teachers_on_inst('{nameInst}');", bd);

                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

                if (npgSqlDataReader.HasRows) //--если такой логин есть в бд 
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        int idCathedra = dbDataRecord.GetInt32(0);
                        int idDegree = dbDataRecord.GetInt32(1);
                        int idTeacher = dbDataRecord.GetInt32(2);
                        string fio = dbDataRecord.GetString(3);
                        string password = dbDataRecord.GetString(4);
                        teacherList.Add(new Teacher(idCathedra, idDegree, idTeacher, fio, password));
                    }
                }
                bd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex:" + ex.Message);
            }
            return teacherList;
        }
        //получить список кафедр
        internal static List<Cathedra> GetCathedraList()
        {
            List<Cathedra> cathedraList = new List<Cathedra>();
            try
            {
                NpgsqlConnection bd = new NpgsqlConnection(connectionString);
                bd.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT * FROM get_cathedras();", bd);

                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

                if (npgSqlDataReader.HasRows) //--если такой логин есть в бд 
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        int id = dbDataRecord.GetInt32(0);
                        int idInstitute = dbDataRecord.GetInt32(1);
                        string name = dbDataRecord.GetString(2);
                        cathedraList.Add(new Cathedra(name, id, idInstitute));
                    }
                }
                bd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex:" + ex.Message);
            }
            return cathedraList;
        }
        //получитьсписок кафедр выбранного института
        internal static ObservableCollection<Cathedra> GetCathedraList(string nameInst)
        {
            ObservableCollection<Cathedra> cathedraList = new ObservableCollection<Cathedra>();
            try
            {
                NpgsqlConnection bd = new NpgsqlConnection(connectionString);
                bd.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT * FROM get_cathedras('{nameInst}');", bd);

                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

                if (npgSqlDataReader.HasRows) //--если такой логин есть в бд 
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        int id = dbDataRecord.GetInt32(0);
                        int idInstitute = dbDataRecord.GetInt32(1);
                        string name = dbDataRecord.GetString(2);
                        cathedraList.Add(new Cathedra(name, id, idInstitute));
                    }
                }
                bd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex:" + ex.Message);
            }
            return cathedraList;
        }

        //получить список преподавателей
        internal static List<Teacher> GetTeacherList()
        {
            List<Teacher> teacherList = new List<Teacher>();
            try
            {
                NpgsqlConnection bd = new NpgsqlConnection(connectionString);
                bd.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT * FROM get_teachers();", bd);

                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

                if (npgSqlDataReader.HasRows) //--если такой логин есть в бд 
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        int idCathedra = dbDataRecord.GetInt32(0);
                        int idDegree = dbDataRecord.GetInt32(1);
                        int idTeacher = dbDataRecord.GetInt32(2);
                        string fio = dbDataRecord.GetString(3);
                        string password = dbDataRecord.GetString(4);
                        teacherList.Add(new Teacher(idCathedra, idDegree, idTeacher, fio, password));
                    }
                }
                bd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex:" + ex.Message);
            }
            return teacherList;
        }
        //получить список учителей выбранной кафедры
        internal static List<Teacher> GetTeacherList(string nameCath)
        {
            List<Teacher> teacherList = new List<Teacher>();
            try
            {
                NpgsqlConnection bd = new NpgsqlConnection(connectionString);
                bd.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT * FROM get_teachers('{nameCath}');", bd);

                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

                if (npgSqlDataReader.HasRows) //--если такой логин есть в бд 
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        int idCathedra = dbDataRecord.GetInt32(0);
                        int idDegree = dbDataRecord.GetInt32(1);
                        int idTeacher = dbDataRecord.GetInt32(2);
                        string fio = dbDataRecord.GetString(3);
                        string password = dbDataRecord.GetString(4);
                        teacherList.Add(new Teacher(idCathedra, idDegree, idTeacher, fio, password));
                    }
                }
                bd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex:" + ex.Message);
            }
            return teacherList;
        }
        //получить список дисциплин доступных преподавателю
        internal static ObservableCollection<Discipline> GetDisciplineList(int teachId)
        {
            ObservableCollection<Discipline> disciplineList = new ObservableCollection<Discipline>();
            try
            {
                NpgsqlConnection bd = new NpgsqlConnection(connectionString);
                bd.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT * FROM get_disciplines('{teachId}');", bd);

                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

                if (npgSqlDataReader.HasRows) //--если такой логин есть в бд 
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        int idDiscipline = dbDataRecord.GetInt32(0);
                        int duration = dbDataRecord.GetInt32(2);
                        string nameDiscipline = dbDataRecord.GetString(1);
                        disciplineList.Add(new Discipline(idDiscipline, nameDiscipline, duration));
                    }
                }
                bd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex:" + ex.Message);
            }
            return disciplineList;
        }

        internal static ObservableCollection<IntermediateControl> GetIntermediateControlls(int teachId, int discId, int groupId)
        {
            ObservableCollection<IntermediateControl> controlList = new ObservableCollection<IntermediateControl>();
            try
            {
                NpgsqlConnection bd = new NpgsqlConnection(connectionString);
                bd.Open();
                NpgsqlCommand npgSqlCommand = new NpgsqlCommand($"SELECT * FROM get_controls_on_disc_and_group('{teachId}','{discId}','{groupId}');", bd);

                NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

                if (npgSqlDataReader.HasRows) //--если такой логин есть в бд 
                {
                    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                    {
                        int id = dbDataRecord.GetInt32(0);
                        string typeOfControl = dbDataRecord.GetString(1);
                        int numTasks = dbDataRecord.GetInt32(2);
                        int maxBall = dbDataRecord.GetInt32(3);
                        controlList.Add(new IntermediateControl(id, discId, teachId, groupId, typeOfControl, numTasks, maxBall));
                    }
                }
                bd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex:" + ex.Message);
            }
            return controlList;
        }
    }
}

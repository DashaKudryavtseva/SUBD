﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace RangSystem.DataBase
{
    static class DBCommunicate
    {
        private static string connectionString = Properties.Settings.Default.ConnectionString;
        //--Получить список институтов 
      

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

        internal static List<Cathedra> GetCathedraList(string nameInst)
        {
            List<Cathedra> cathedraList = new List<Cathedra>();
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
    }
}
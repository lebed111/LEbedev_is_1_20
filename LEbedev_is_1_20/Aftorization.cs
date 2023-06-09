﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;


namespace LEbedev_is_1_20
{
    public partial class Aftorization : MetroFramework.Forms.MetroForm
    {
    public Aftorization()
    {
        InitializeComponent();
    }

        Requests f2 = new Requests();
        public delegate void ThreadStart();
        //Вычисление хэша строки и возрат его из метода
        public static string sha256(string randomString)
        {
            //Тут происходит криптографическая магия. Смысл данного метода заключается в том, что строка залетает в метод
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }


        public void GetUserInfo(string login_user)
        {
            //Объявлем переменную для запроса в БД
            string selected_id_stud = metroTextBox1.Text;
            // устанавливаем соединение с БД
            f2.conn.Open();
            // запрос
            string sql = $"SELECT * FROM Emploee WHERE Login ='{login_user}'";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, f2.conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                Auth.auth_id = reader[0].ToString();
                Auth.auth_fio = $"{reader[1].ToString()} {reader[2].ToString().Remove(1,(reader[2].ToString().Count())-1)}. {reader[3].ToString().Remove(1,(reader[3].ToString().Count())-1)}.";
                Auth.auth_role = Convert.ToInt32(reader[5].ToString());
                Auth.auto_post = reader[4].ToString();
            }
            reader.Close(); // закрываем reader
                            // закрываем соединение с БД
            f2.conn.Close();
        }
        void avtiriseon()
        {
            string f = metroTextBox1.Text;
            string r = sha256(metroTextBox2.Text);
            //Запрос в БД на предмет того, если ли строка с подходящим логином и паролем
            string sql = $"SELECT Emploee.Login, sha256.sha256_s FROM Emploee, sha256 WHERE Emploee.Login = \"{f}\" and sha256.sha256_s =\"{r}\"";
            //Открытие соединения
            f2.conn.Open();
            //Объявляем таблицу
            DataTable table = new DataTable();
            //Объявляем адаптер
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            //Объявляем команду
            MySqlCommand command = new MySqlCommand(sql, f2.conn);
            //Определяем параметры
            //command.Parameters.Add("@un", MySqlDbType.VarChar, 25);
            //command.Parameters.Add("@up", MySqlDbType.VarChar, 25);
            ////Присваиваем параметрам значение
            //command.Parameters["@un"].Value = textBox1.Text;
            //command.Parameters["@up"].Value = sha256(textBox2.Text);
            //Заносим команду в адаптер
            adapter.SelectCommand = command;
            //Заполняем таблицу
            adapter.Fill(table);
            //Закрываем соединение
            f2.conn.Close();

            //Если вернулась больше 0 строк, значит такой пользователь существует
            if (table.Rows.Count > 0)
            {
                //Присваеваем глобальный признак авторизации
                Auth.auth = true;
                GetUserInfo(metroTextBox1.Text);
                //Закрываем форму
                this.Invoke(new MethodInvoker(() => { this.Hide(); }));
                Menu mainMenu = new Menu();
                mainMenu.Show();
            }
            else
            {
                //Отобразить сообщение о том, что авторизаия неуспешна
                MessageBox.Show("Неверные данные авторизации!");
            }
        }
        private void Authorization_Load(object sender, EventArgs e)
        {
            f2.con();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           //Thread th = new Thread(avtiriseon);
           //th.Start();
            avtiriseon();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            finally
            {
                this.Close();
            }
        }

        private void Aftorization_Load(object sender, EventArgs e)
        {
            f2.con();
        }
    }  
}

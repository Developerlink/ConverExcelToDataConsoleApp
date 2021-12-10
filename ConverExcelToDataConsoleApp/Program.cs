using System;
using System.Collections.Generic;
using System.IO;

namespace ConverExcelToDataConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var pathIn = @"D:\uk-500.csv";
            var pathOut = @"D:\ExcelToSQL.sql";

            var sr = new StreamReader(pathIn);
            var sw = new StreamWriter(pathOut);

            //using (StreamWriter sw = new StreamWriter(pathOut, append: false))
            //{

                var first_Name = new List<String>();
                var last_Name = new List<String>();
                var company_Name = new List<String>();
                var address = new List<String>();
                var city = new List<String>();
                var country = new List<String>();
                var postal = new List<String>();
                var phone1 = new List<String>();
                var phone2 = new List<String>();
                var email = new List<String>();
                var web = new List<String>();


                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] values = line.Split(separator: ',');
                        if (values.Length >= 10)
                        {
                            first_Name.Add(values[0]);
                            last_Name.Add(values[1]);
                            company_Name.Add(values[2]);
                            address.Add(values[3]);
                            city.Add(values[4]);
                            country.Add(values[5]);
                            postal.Add(values[6]);
                            phone1.Add(values[7]);
                            phone2.Add(values[8]);
                            email.Add(values[9]);
                            web.Add(values[10]);

                        }
                    }
                }

                string[] List_first_name = first_Name.ToArray();
                string[] List_last_name = last_Name.ToArray();
                string[] List_company_name = company_Name.ToArray();
                string[] List_address = address.ToArray();
                string[] List_city = city.ToArray();
                string[] List_country = country.ToArray();
                string[] List_postal = postal.ToArray();
                string[] List_phone1 = phone1.ToArray();
                string[] List_phone2 = phone2.ToArray();
                string[] List_email = email.ToArray();
                string[] List_web = web.ToArray();

                sw.WriteLine("Use april2020");
                sw.WriteLine("GO");

                //Data to Employees table.
                sw.WriteLine($"INSERT INTO [Employees](First_name, Last_name, Department_id) ");
                sw.WriteLine($"VAlUES ");

                for (int i = 1; i < List_first_name.Length; i++)
                {
                    Random rnd = new Random();
                    int randomDeparmentId = rnd.Next(1, 10);

                    string values = $"('{List_first_name[i]}', '{List_last_name[i]}', '{randomDeparmentId}')";

                    if (i < List_first_name.Length - 1)
                    {
                        values += ", ";
                    }

                    sw.WriteLine(values);
                }

            //}

            sr.Close();
            sw.Close();








        }
    }
}

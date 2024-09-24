using AnalaizerClassLibrary;
using System.Data.SqlClient;

namespace CalcTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]

        public void TestGetPriority()
        {
            using (SqlConnection connection = new SqlConnection (@"Data Source=DESKTOP-UU6GC3O;Initial Catalog=DBlibraryCalc;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select OperatorId, OperatorSymbol, Priority from Data", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    // Отримання даних з таблиці
                    int operatorId = reader.GetInt32(0); // OperatorId
                    string operatorSymbol = reader.GetString(1); // OperatorSymbol
                    int expectedPriority = reader.GetInt32(2); // Priority

                    // Тестування пріоритетів операторів
                    int actualPriority = AnalaizerClass.GetPriority(operatorSymbol);

                    // Перевірка, чи збігається очікуваний і фактичний пріоритет
                    Assert.AreEqual(actualPriority, expectedPriority);

                }
                reader.Close();
            }
         
        }

    }
}
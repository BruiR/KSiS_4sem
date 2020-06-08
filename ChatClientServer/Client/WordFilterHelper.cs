using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace Client
{
    class WordFilterHelper
    {
        private List<string> wordsList = new List<string>();
        public WordFilterHelper()
        {
            string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=WordsDB.mdb;";
            OleDbConnection myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = "SELECT badWord FROM WordsTable";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                wordsList.Add(reader[0].ToString());
            }
            reader.Close();
            myConnection.Close();
        }
        public string ReplaceBadWords(string str)
        {
            foreach (string el in wordsList)
            {
                Regex myReg = new Regex(el, RegexOptions.IgnoreCase);
                if (myReg.IsMatch(str) == true)
                    str = myReg.Replace(str, "[мат]");
            }
            return str;
        }
    }
}
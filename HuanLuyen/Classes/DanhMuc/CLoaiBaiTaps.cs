using ADOConnection;
using System;
using System.Collections.Generic;
using System.Data;
namespace HuanLuyen
{
    public class CLoaiBaiTaps
    {
        public static List<CLoaiBaiTap> GetList()
        {
            List<CLoaiBaiTap> list = new List<CLoaiBaiTap>();
            string text = "SELECT LoaiBaiTapID, LoaiBaiTap FROM tblLoaiBaiTap ORDER BY Stt";
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CLoaiBaiTap cLoaiBaiTap = new CLoaiBaiTap();
                    CLoaiBaiTap cLoaiBaiTap2 = cLoaiBaiTap;
                    cLoaiBaiTap2.LoaiBaiTapID = dataReader.GetInt32(0);
                    cLoaiBaiTap2.LoaiBaiTap = dataReader.GetString(1);
                    list.Add(cLoaiBaiTap);
                }
                dataReader.Close();
            }
            catch (Exception expr_74)
            {
                throw expr_74;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static CLoaiBaiTap GetLoaiBaiTap(int lID)
        {
            CLoaiBaiTap cLoaiBaiTap = new CLoaiBaiTap();
            cLoaiBaiTap.LoaiBaiTapID = -1;
            string text = "SELECT LoaiBaiTap FROM tblLoaiBaiTap  WHERE LoaiBaiTapID = " + Convert.ToString(lID);
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CLoaiBaiTap cLoaiBaiTap2 = cLoaiBaiTap;
                    cLoaiBaiTap2.LoaiBaiTapID = lID;
                    cLoaiBaiTap2.LoaiBaiTap = dataReader.GetString(0);
                }
                dataReader.Close();
            }
            catch (Exception expr_6F)
            {
                throw expr_6F;
            }
            finally
            {
                connection.Close();
            }
            return cLoaiBaiTap;
        }
        public static DataSet CreateDS(ref IDbDataAdapter sda)
        {
            DataSet dataSet = new DataSet();
            try
            {
                IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
                IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
                string sText = "SELECT Stt, LoaiBaiTap, LoaiBaiTapID FROM tblLoaiBaiTap";
                IDbCommand selectCommand = connection.CreateCommand(sText);
                sda.SelectCommand = selectCommand;
                string text = "UPDATE tblLoaiBaiTap SET";
                text += " Stt = ";
                text += iDBUtility.GetParamPlaceHolder("Stt", true);
                text += " LoaiBaiTap = ";
                text += iDBUtility.GetParamPlaceHolder("LoaiBaiTap", false);
                text += " WHERE LoaiBaiTapID = ";
                text += iDBUtility.GetParamPlaceHolder("LoaiBaiTapID", false);
                IDbCommand dbCommand = connection.CreateCommand(text);
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.CommandType = CommandType.Text;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, 0, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiBaiTap", DbType.String, "", 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiBaiTapID", DbType.Int32, 0, 0));
                sda.UpdateCommand = dbCommand;
                string text2 = "DELETE FROM tblLoaiBaiTap WHERE LoaiBaiTapID = ";
                text2 += iDBUtility.GetParamPlaceHolder("LoaiBaiTapID", false);
                IDbCommand dbCommand3 = connection.CreateCommand(text2);
                IDbCommand dbCommand4 = dbCommand3;
                dbCommand4.CommandType = CommandType.Text;
                dbCommand4.Parameters.Add(iDBUtility.CreateParameter("LoaiBaiTapID", DbType.Int32, 0, 0));
                sda.DeleteCommand = dbCommand3;
                string text3 = "INSERT INTO tblLoaiBaiTap";
                text3 += " (Stt,LoaiBaiTap)";
                text3 += " VALUES (";
                text3 += iDBUtility.GetParamPlaceHolder("Stt", true);
                text3 += iDBUtility.GetParamPlaceHolder("LoaiBaiTap", false);
                text3 += ")";
                IDbCommand dbCommand5 = connection.CreateCommand(text3);
                IDbCommand dbCommand6 = dbCommand5;
                dbCommand6.CommandType = CommandType.Text;
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, 0, 0));
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("LoaiBaiTap", DbType.String, "", 0));
                sda.InsertCommand = dbCommand5;
                sda.Fill(dataSet);
            }
            catch (Exception expr_25F)
            {
                throw expr_25F;
            }
            return dataSet;
        }
    }
}
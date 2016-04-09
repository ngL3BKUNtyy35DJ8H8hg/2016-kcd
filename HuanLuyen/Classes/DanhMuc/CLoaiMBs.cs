using ADOConnection;
using System;
using System.Collections.Generic;
using System.Data;
namespace HuanLuyen
{
    public class CLoaiMBs
    {
        public static List<CLoaiMB> GetList()
        {
            List<CLoaiMB> list = new List<CLoaiMB>();
            string text = "SELECT ID, LoaiMB, KL, SymbolID, Altitude, Speed, Roll FROM tblLoaiMB ORDER BY Stt";
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CLoaiMB cLoaiMB = new CLoaiMB();
                    CLoaiMB cLoaiMB2 = cLoaiMB;
                    cLoaiMB2.ID = dataReader.GetInt32(0);
                    cLoaiMB2.LoaiMB = dataReader.GetString(1);
                    cLoaiMB2.KL = dataReader.GetString(2);
                    cLoaiMB2.SymbolID = (int)dataReader.GetInt16(3);
                    cLoaiMB2.Altitude = dataReader.GetDouble(4);
                    cLoaiMB2.Speed = dataReader.GetDouble(5);
                    cLoaiMB2.Roll = Convert.ToSingle(dataReader.GetValue(6));
                    list.Add(cLoaiMB);
                }
                dataReader.Close();
            }
            catch (Exception expr_CA)
            {
                throw expr_CA;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static CLoaiMB GetLoaiMB(int lID)
        {
            CLoaiMB cLoaiMB = new CLoaiMB();
            cLoaiMB.ID = -1;
            string text = "SELECT LoaiMB, KL, SymbolID, Altitude, Speed, Roll FROM tblLoaiMB  WHERE ID = " + Convert.ToString(lID);
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CLoaiMB cLoaiMB2 = cLoaiMB;
                    cLoaiMB2.ID = lID;
                    cLoaiMB2.LoaiMB = dataReader.GetString(0);
                    cLoaiMB2.KL = dataReader.GetString(1);
                    cLoaiMB2.SymbolID = (int)dataReader.GetInt16(2);
                    cLoaiMB2.Altitude = dataReader.GetDouble(3);
                    cLoaiMB2.Speed = dataReader.GetDouble(4);
                    cLoaiMB2.Roll = Convert.ToSingle(dataReader.GetValue(5));
                }
                dataReader.Close();
            }
            catch (Exception expr_BF)
            {
                throw expr_BF;
            }
            finally
            {
                connection.Close();
            }
            return cLoaiMB;
        }
        public static DataSet CreateDS(ref IDbDataAdapter sda)
        {
            DataSet dataSet = new DataSet();
            try
            {
                IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
                IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
                string sText = "SELECT Stt, LoaiMB, KL, SymbolID, Altitude, Speed, Roll, ID FROM tblLoaiMB";
                IDbCommand selectCommand = connection.CreateCommand(sText);
                sda.SelectCommand = selectCommand;
                string text = "UPDATE tblLoaiMB SET";
                text += " Stt = ";
                text += iDBUtility.GetParamPlaceHolder("Stt", true);
                text += " LoaiMB = ";
                text += iDBUtility.GetParamPlaceHolder("LoaiMB", true);
                text += " KL = ";
                text += iDBUtility.GetParamPlaceHolder("KL", true);
                text += " SymbolID = ";
                text += iDBUtility.GetParamPlaceHolder("SymbolID", true);
                text += " Altitude = ";
                text += iDBUtility.GetParamPlaceHolder("Altitude", true);
                text += " Speed = ";
                text += iDBUtility.GetParamPlaceHolder("Speed", true);
                text += " Roll = ";
                text += iDBUtility.GetParamPlaceHolder("Roll", false);
                text += " WHERE ID = ";
                text += iDBUtility.GetParamPlaceHolder("ID", false);
                IDbCommand dbCommand = connection.CreateCommand(text);
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.CommandType = CommandType.Text;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, 0, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiMB", DbType.String, "", 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KL", DbType.String, "", 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SymbolID", DbType.Int16, 0, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Altitude", DbType.Double, 0, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Speed", DbType.Double, 0, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Roll", DbType.Single, 0, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("ID", DbType.Int32, 0, 0));
                sda.UpdateCommand = dbCommand;
                string text2 = "DELETE FROM tblLoaiMB WHERE ID = ";
                text2 += iDBUtility.GetParamPlaceHolder("ID", false);
                IDbCommand dbCommand3 = connection.CreateCommand(text2);
                IDbCommand dbCommand4 = dbCommand3;
                dbCommand4.CommandType = CommandType.Text;
                dbCommand4.Parameters.Add(iDBUtility.CreateParameter("ID", DbType.Int32, 0, 0));
                sda.DeleteCommand = dbCommand3;
                string text3 = "INSERT INTO tblLoaiMB";
                text3 += " (Stt,LoaiMB, KL, SymbolID, Altitude, Speed, Roll)";
                text3 += " VALUES (";
                text3 += iDBUtility.GetParamPlaceHolder("Stt", true);
                text3 += iDBUtility.GetParamPlaceHolder("LoaiMB", true);
                text3 += iDBUtility.GetParamPlaceHolder("KL", true);
                text3 += iDBUtility.GetParamPlaceHolder("SymbolID", true);
                text3 += iDBUtility.GetParamPlaceHolder("Altitude", true);
                text3 += iDBUtility.GetParamPlaceHolder("Speed", true);
                text3 += iDBUtility.GetParamPlaceHolder("Roll", false);
                text3 += ")";
                IDbCommand dbCommand5 = connection.CreateCommand(text3);
                IDbCommand dbCommand6 = dbCommand5;
                dbCommand6.CommandType = CommandType.Text;
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, 0, 0));
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("LoaiMB", DbType.String, "", 0));
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("KL", DbType.String, "", 0));
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("SymbolID", DbType.Int16, 0, 0));
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("Altitude", DbType.Double, 0, 0));
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("Speed", DbType.Double, 0, 0));
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("Roll", DbType.Single, 0, 0));
                sda.InsertCommand = dbCommand5;
                sda.Fill(dataSet);
            }
            catch (Exception expr_4CF)
            {
                throw expr_4CF;
            }
            return dataSet;
        }
    }
}
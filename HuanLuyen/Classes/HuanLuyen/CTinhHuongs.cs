using ADOConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace HuanLuyen
{
    public class CTinhHuongs
    {
        public static List<CTinhHuong> GetList(int pBaiTapID)
        {
            List<CTinhHuong> list = new List<CTinhHuong>();
            string text = "SELECT Phut, TinhHuong FROM tblBaiTapTinhHuong  WHERE (BaiTapID = " + Convert.ToString(pBaiTapID) + ")";
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CTinhHuong cTinhHuong = new CTinhHuong();
                    CTinhHuong cTinhHuong2 = cTinhHuong;
                    cTinhHuong2.BaiTapID = pBaiTapID;
                    cTinhHuong2.Phut = (int)dataReader.GetInt16(0);
                    cTinhHuong2.TinhHuong = dataReader.GetString(1);
                    list.Add(cTinhHuong);
                }
                dataReader.Close();
            }
            catch (Exception expr_8C)
            {
                throw expr_8C;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static CTinhHuong GetTinhHuong(int pBaiTapID, int pPhut)
        {
            CTinhHuong cTinhHuong = new CTinhHuong();
            CTinhHuong cTinhHuong2 = cTinhHuong;
            cTinhHuong2.BaiTapID = pBaiTapID;
            cTinhHuong2.Phut = pPhut;
            cTinhHuong2.TinhHuong = "";
            string text = string.Concat(new string[]{
                "SELECT TinhHuong FROM tblBaiTapTinhHuong  WHERE (BaiTapID = ", Convert.ToString(pBaiTapID),") AND (Phut = ", Convert.ToString(pPhut),")"});
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CTinhHuong cTinhHuong3 = cTinhHuong;
                    cTinhHuong3.TinhHuong = dataReader.GetString(0);
                }
                dataReader.Close();
            }
            catch (Exception expr_AF)
            {
                throw expr_AF;
            }
            finally
            {
                connection.Close();
            }
            return cTinhHuong;
        }
        public static DataSet CreateDS(ref IDbDataAdapter sda, int pBaiTapID)
        {
            DataSet dataSet = new DataSet();
            try
            {
                IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
                IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
                string sText = "SELECT Phut, TinhHuong, BaiTapID, Stt FROM tblBaiTapTinhHuong WHERE BaiTapID = " + Convert.ToString(pBaiTapID);
                IDbCommand selectCommand = connection.CreateCommand(sText);
                sda.SelectCommand = selectCommand;
                string text = "UPDATE tblBaiTapTinhHuong SET";
                text += " Phut = ";
                text += iDBUtility.GetParamPlaceHolder("Phut", true);
                text += " TinhHuong = ";
                text += iDBUtility.GetParamPlaceHolder("TinhHuong", false);
                text += " WHERE (BaiTapID = ";
                text += iDBUtility.GetParamPlaceHolder("BaiTapID", false);
                text += ") AND (Stt = ";
                text += iDBUtility.GetParamPlaceHolder("Stt", false);
                text += ")";
                IDbCommand dbCommand = connection.CreateCommand(text);
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.CommandType = CommandType.Text;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Phut", DbType.Int16, 0, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("TinhHuong", DbType.String, "", 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, 0, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, 0, 0));
                sda.UpdateCommand = dbCommand;
                string text2 = "DELETE FROM tblBaiTapTinhHuong WHERE (BaiTapID = ";
                text2 += iDBUtility.GetParamPlaceHolder("BaiTapID", false);
                text2 += ") AND (Stt = ";
                text2 += iDBUtility.GetParamPlaceHolder("Stt", false);
                text2 += ")";
                IDbCommand dbCommand3 = connection.CreateCommand(text2);
                IDbCommand dbCommand4 = dbCommand3;
                dbCommand4.CommandType = CommandType.Text;
                dbCommand4.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, 0, 0));
                dbCommand4.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, 0, 0));
                sda.DeleteCommand = dbCommand3;
                string text3 = "INSERT INTO tblBaiTapTinhHuong";
                text3 += " (BaiTapID, Stt, Phut, TinhHuong)";
                text3 += " VALUES (";
                text3 += iDBUtility.GetParamPlaceHolder("BaiTapID", true);
                text3 += iDBUtility.GetParamPlaceHolder("Stt", true);
                text3 += iDBUtility.GetParamPlaceHolder("Phut", true);
                text3 += iDBUtility.GetParamPlaceHolder("TinhHuong", false);
                text3 += ")";
                IDbCommand dbCommand5 = connection.CreateCommand(text3);
                IDbCommand dbCommand6 = dbCommand5;
                dbCommand6.CommandType = CommandType.Text;
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, 0, 0));
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, 0, 0));
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("Phut", DbType.Int16, 0, 0));
                dbCommand6.Parameters.Add(iDBUtility.CreateParameter("TinhHuong", DbType.String, "", 0));
                sda.InsertCommand = dbCommand5;
                sda.Fill(dataSet);
            }
            catch (Exception expr_37C)
            {
                throw expr_37C;
            }
            return dataSet;
        }
        public static long Delete(int pBaiTapID)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblBaiTapTinhHuong");
            stringBuilder2.Append(" WHERE (BaiTapID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, pBaiTapID, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_C7)
            {
                throw expr_C7;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
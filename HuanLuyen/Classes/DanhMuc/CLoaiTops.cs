using ADOConnection;
using System;
using System.Collections.Generic;
using System.Data;
namespace HuanLuyen
{
    public class CLoaiTops
    {
        public static List<CLoaiTop> GetList()
        {
            List<CLoaiTop> list = new List<CLoaiTop>();
            string text = "SELECT LoaiTopID, LoaiTop, SoHieu FROM tblLoaiTop";
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CLoaiTop cLoaiTop = new CLoaiTop();
                    CLoaiTop cLoaiTop2 = cLoaiTop;
                    cLoaiTop2.LoaiTopID = (int)dataReader.GetInt16(0);
                    cLoaiTop2.LoaiTop = dataReader.GetString(1);
                    cLoaiTop2.SoHieu = (int)dataReader.GetInt16(2);
                    list.Add(cLoaiTop);
                }
                dataReader.Close();
            }
            catch (Exception expr_83)
            {
                throw expr_83;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static CLoaiTop GetLoaiTop(int lID)
        {
            CLoaiTop cLoaiTop = new CLoaiTop();
            cLoaiTop.LoaiTopID = -1;
            string text = "SELECT LoaiTop, SoHieu FROM tblLoaiTop  WHERE ID = " + Convert.ToString(lID);
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CLoaiTop cLoaiTop2 = cLoaiTop;
                    cLoaiTop2.LoaiTopID = lID;
                    cLoaiTop2.LoaiTop = dataReader.GetString(0);
                    cLoaiTop2.SoHieu = (int)dataReader.GetInt16(1);
                }
                dataReader.Close();
            }
            catch (Exception expr_7E)
            {
                throw expr_7E;
            }
            finally
            {
                connection.Close();
            }
            return cLoaiTop;
        }
        public static DataSet CreateDS(ref IDbDataAdapter sda)
        {
            DataSet dataSet = new DataSet();
            try
            {
                IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
                IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
                string sText = "SELECT LoaiTop, SoHieu, LoaiTopID FROM tblLoaiTop";
                IDbCommand selectCommand = connection.CreateCommand(sText);
                sda.SelectCommand = selectCommand;
                string text = "UPDATE tblLoaiTop SET";
                text += " LoaiTop = ";
                text += iDBUtility.GetParamPlaceHolder("LoaiTop", true);
                text += " SoHieu = ";
                text += iDBUtility.GetParamPlaceHolder("SoHieu", false);
                text += " WHERE LoaiTopID = ";
                text += iDBUtility.GetParamPlaceHolder("LoaiTopID", false);
                IDbCommand dbCommand = connection.CreateCommand(text);
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.CommandType = CommandType.Text;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiTop", DbType.String, "", 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SoHieu", DbType.Int16, 0, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiTopID", DbType.Int32, 0, 0));
                sda.UpdateCommand = dbCommand;
                sda.Fill(dataSet);
            }
            catch (Exception expr_13B)
            {
                throw expr_13B;
            }
            return dataSet;
        }
    }
}
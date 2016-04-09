using ADOConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace HuanLuyen
{
    public class CBaiTapRadas
    {
        public static List<CRada> GetList(int pBaiTapID)
        {
            List<CRada> list = new List<CRada>();
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(250);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("SELECT RadaID, LoaiRadaID, Ten, SoHieu, PosX, PosY, R");
            stringBuilder2.Append(" FROM tblBaiTapRada");
            stringBuilder2.Append(" WHERE BaiTapID =");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", false));
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbCommand dbCommand2 = dbCommand;
            dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, pBaiTapID, 0));
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, true);
                while (dataReader.Read())
                {
                    CRada cRada = new CRada();
                    CRada cRada2 = cRada;
                    cRada2.RadaID = dataReader.GetInt32(0);
                    cRada2.LoaiRadaID = (int)dataReader.GetInt16(1);
                    cRada2.Ten = dataReader.GetString(2);
                    cRada2.SoHieu = dataReader.GetString(3);
                    cRada2.PosX = dataReader.GetDouble(4);
                    cRada2.PosY = dataReader.GetDouble(5);
                    cRada2.R = Convert.ToSingle(dataReader.GetValue(6));
                    list.Add(cRada);
                }
                dataReader.Close();
            }
            catch (Exception expr_150)
            {
                throw expr_150;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static int GetMaxID(int pBaiTapID)
        {
            int result = 0;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(250);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("SELECT Max([RadaID]) AS MaxID");
            stringBuilder2.Append(" FROM tblBaiTapRada");
            stringBuilder2.Append(" WHERE BaiTapID =");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", false));
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbCommand dbCommand2 = dbCommand;
            dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, pBaiTapID, 0));
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, true);
                while (dataReader.Read())
                {
                    result = dataReader.GetInt32(0);
                }
                dataReader.Close();
            }
            catch (Exception expr_CB)
            {
                throw expr_CB;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static int Insert(int pBaiTapID, CRada obj)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblBaiTapRada (BaiTapID, RadaID, LoaiRadaID, Ten, SoHieu, PosX, PosY, R) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("RadaID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiRadaID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Ten", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SoHieu", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("R", false));
            stringBuilder2.Append(")");
            string text = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(text);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            try
            {
                dbCommand.Transaction = dbTransaction;
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, pBaiTapID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("RadaID", DbType.Int32, obj.RadaID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiRadaID", DbType.Int16, obj.LoaiRadaID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Ten", DbType.String, obj.Ten, obj.Ten.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SoHieu", DbType.String, obj.SoHieu, obj.SoHieu.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, obj.PosX, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, obj.PosY, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("R", DbType.Single, obj.R, 0));
                num = (long)dbCommand2.ExecuteNonQuery();
                dbCommand2.Parameters.Clear();
                dbTransaction.Commit();
            }
            catch (Exception expr_271)
            {
                throw expr_271;
            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static long Update(CRada objRada)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(200);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("UPDATE tblBaiTapRada SET");
            stringBuilder2.Append(" LoaiRadaID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiRadaID", true));
            stringBuilder2.Append(" Ten = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Ten", true));
            stringBuilder2.Append(" SoHieu = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SoHieu", true));
            stringBuilder2.Append(" PosX = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder2.Append(" PosY = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder2.Append(" R = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("R", false));
            stringBuilder2.Append(" WHERE RadaID =");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("RadaID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiRadaID", DbType.Int32, objRada.LoaiRadaID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Ten", DbType.String, objRada.Ten, objRada.Ten.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SoHieu", DbType.String, objRada.SoHieu, objRada.SoHieu.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, objRada.PosX, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, objRada.PosY, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("R", DbType.Single, objRada.R, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("RadaID", DbType.Int32, objRada.RadaID, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_26E)
            {
                throw expr_26E;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long Delete(int pBaiTapID, int pRadaID)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblBaiTapRada ");
            stringBuilder2.Append(" WHERE (BaiTapID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", false));
            stringBuilder2.Append(") AND (RadaID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("RadaID", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, pBaiTapID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("RadaID", DbType.Int32, pRadaID, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_10B)
            {
                throw expr_10B;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
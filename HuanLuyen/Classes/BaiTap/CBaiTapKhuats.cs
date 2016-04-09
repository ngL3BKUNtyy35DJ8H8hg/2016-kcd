using ADOConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace HuanLuyen
{
    public class CBaiTapKhuats
    {
        public static List<CKhuat> GetList(int pBaiTapID)
        {
            List<CKhuat> list = new List<CKhuat>();
            string sText = "SELECT KhuatID, RadaID FROM tblBaiTapRadaKhuat WHERE BaiTapID = " + Convert.ToString(pBaiTapID);
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            int num = 0;
            checked
            {
                try
                {
                    CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                    while (dataReader.Read())
                    {
                        CKhuat cKhuat = new CKhuat();
                        num++;
                        CKhuat cKhuat2 = cKhuat;
                        cKhuat2.KhuatID = dataReader.GetInt32(0);
                        cKhuat2.RadaID = dataReader.GetInt32(1);
                        cKhuat2.Stt = num;
                        list.Add(cKhuat);
                    }
                    dataReader.Close();
                }
                catch (Exception expr_90)
                {
                    throw expr_90;
                }
                finally
                {
                    connection.Close();
                }
                return list;
            }
        }
        public static List<CKhuat> GetList(int pBaiTapID, int pRadaID)
        {
            List<CKhuat> list = new List<CKhuat>();
            string sText = string.Concat(new string[]
{
"SELECT KhuatID FROM tblBaiTapRadaKhuat WHERE (BaiTapID = ",
Convert.ToString(pBaiTapID),
") AND (RadaID = ",
Convert.ToString(pRadaID),
")"
});
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            int num = 0;
            checked
            {
                try
                {
                    CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                    while (dataReader.Read())
                    {
                        CKhuat cKhuat = new CKhuat();
                        num++;
                        CKhuat cKhuat2 = cKhuat;
                        cKhuat2.KhuatID = dataReader.GetInt32(0);
                        cKhuat2.RadaID = pRadaID;
                        cKhuat2.Stt = num;
                        list.Add(cKhuat);
                    }
                    dataReader.Close();
                }
                catch (Exception expr_B7)
                {
                    throw expr_B7;
                }
                finally
                {
                    connection.Close();
                }
                return list;
            }
        }
        public static List<CKhuatPt> GetKhuatPts(int pBaiTapID, int pKhuatID)
        {
            List<CKhuatPt> list = new List<CKhuatPt>();
            string sText = string.Concat(new string[]
{
"SELECT Stt, PosX, PosY FROM tblBaiTapRadaKhuatPt WHERE (BaiTapID = ",
Convert.ToString(pBaiTapID),
") AND (KhuatID = ",
Convert.ToString(pKhuatID),
")"
});
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, false);
                while (dataReader.Read())
                {
                    CKhuatPt cKhuatPt = new CKhuatPt();
                    CKhuatPt cKhuatPt2 = cKhuatPt;
                    cKhuatPt2.Stt = (int)dataReader.GetInt16(0);
                    cKhuatPt2.PosX = dataReader.GetDouble(1);
                    cKhuatPt2.PosY = dataReader.GetDouble(2);
                    list.Add(cKhuatPt);
                }
                dataReader.Close();
            }
            catch (Exception expr_BC)
            {
                throw expr_BC;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static int Insert(int pBaiTapID, CKhuat obj)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblBaiTapRadaKhuat (BaiTapID, KhuatID, RadaID) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("KhuatID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("RadaID", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, pBaiTapID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KhuatID", DbType.Int32, obj.KhuatID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("RadaID", DbType.Int32, obj.RadaID, 0));
                num = (long)dbCommand2.ExecuteNonQuery();
                dbCommand2.Parameters.Clear();
                dbTransaction.Commit();
            }
            catch (Exception expr_13E)
            {
                throw expr_13E;
            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static long InsertPts(int pBaiTapID, int pKhuatID, List<CKhuatPt> pPts)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblBaiTapRadaKhuatPt (BaiTapID, KhuatID, Stt, PosX, PosY) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("KhuatID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Stt", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", false));
            stringBuilder2.Append(")");
            string text = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(text);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long result = 0L;
            int num = 0;
            try
            {
                dbCommand.Transaction = dbTransaction;
                foreach (CKhuatPt current in pPts)
                {
                    IDbCommand dbCommand2;
                    checked
                    {
                        num++;
                        dbCommand2 = dbCommand;
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, pBaiTapID, 0));
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KhuatID", DbType.Int32, pKhuatID, 0));
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, num, 0));
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, current.PosX, 0));
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, current.PosY, 0));
                    }
                    result = (long)dbCommand2.ExecuteNonQuery();
                    dbCommand2.Parameters.Clear();
                }

                dbTransaction.Commit();
            }
            catch (Exception expr_1E7)
            {
                throw expr_1E7;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static int Delete(int pBaiTapID, int pKhuatId)
        {
            int result = 0;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblBaiTapRadaKhuat");
            stringBuilder2.Append(" WHERE (BaiTapID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", false));
            stringBuilder2.Append(") AND (KhuatID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("KhuatID", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, pBaiTapID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KhuatID", DbType.Int32, pKhuatId, 0));
                result = dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_109)
            {
                throw expr_109;

            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static int DeletePts(int pBaiTapID, int pKhuatId)
        {
            int result = 0;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblBaiTapRadaKhuatPt");
            stringBuilder2.Append(" WHERE (BaiTapID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", false));
            stringBuilder2.Append(") AND (KhuatID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("KhuatID", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, pBaiTapID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KhuatID", DbType.Int32, pKhuatId, 0));
                result = dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_109)
            {
                throw expr_109;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
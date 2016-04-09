using ADOConnection;
using AxMapXLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
namespace HuanLuyen
{
    public class CKhuats
    {
        public static List<CKhuat> GetList(int pRadaID)
        {
            List<CKhuat> list = new List<CKhuat>();
            string sText = "SELECT KhuatID FROM tblRadaKhuat WHERE RadaID = " + Convert.ToString(pRadaID);
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
                catch (Exception expr_89)
                {
                    throw expr_89;
                }
                finally
                {
                    connection.Close();
                }
                return list;
            }
        }
        public static List<CKhuatPt> GetKhuatPts(int pKhuatID)
        {
            List<CKhuatPt> list = new List<CKhuatPt>();
            string sText = "SELECT Stt, PosX, PosY FROM tblRadaKhuatPt WHERE KhuatID = " + Convert.ToString(pKhuatID);
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
            catch (Exception expr_8E)
            {
                throw expr_8E;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static CKhuat FindAtPoint(AxMap pMap, PointF pt, List<CKhuat> pKhuats)
        {
            checked
            {
                if (pKhuats != null && pKhuats.Count > 0)
                {
                    for (int i = pKhuats.Count - 1; i >= 0; i += -1)
                    {
                        CKhuat cKhuat = pKhuats[i];
                        if (cKhuat.HitTest(pMap, pt))
                        {
                            return cKhuat;
                        }
                    }
                }
                return null;
            }
        }
        public static int Insert(CKhuat obj)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblRadaKhuat (RadaID) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("RadaID", false));
            stringBuilder2.Append(")");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            int result = 0;
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("RadaID", DbType.Int32, obj.RadaID, 0));
                result = checked((int)iDBUtility.InsertAndReturnSerialKey(ref dbCommand, "KhuatID", "tblRadaKhuat"));
                dbTransaction.Commit();
            }
            catch (Exception expr_CA)
            {
                throw expr_CA;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long InsertPts(int pKhuatID, List<CKhuatPt> pPts)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblRadaKhuatPt (KhuatID, Stt, PosX, PosY) VALUES(");
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
            catch (Exception expr_1B0)
            {
                throw expr_1B0;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static int Delete(int pKhuatId)
        {
            int result = 0;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblRadaKhuat");
            stringBuilder2.Append(" WHERE KhuatID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("KhuatID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KhuatID", DbType.Int32, pKhuatId, 0));
                result = dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_B8)
            {
                throw expr_B8;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static int DeletePts(int pKhuatId)
        {
            int result = 0;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblRadaKhuatPt");
            stringBuilder2.Append(" WHERE KhuatID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("KhuatID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KhuatID", DbType.Int32, pKhuatId, 0));
                result = dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_B8)
            {
                throw expr_B8;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
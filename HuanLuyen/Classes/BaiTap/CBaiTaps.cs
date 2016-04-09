using ADOConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
namespace HuanLuyen
{
    public class CBaiTaps
    {
        public static void HuanLuyen2BaiTap(CBaiTap pBaiTap, List<CFlight> pFlights)
        {
            CBaiTap cBaiTap = new CBaiTap();
            DateTime today = DateTime.Now;
            CBaiTap cBaiTap2 = cBaiTap;
            cBaiTap2.BaiTap = "Lưu Huấn luyện (" + today.ToShortDateString() + ")";
            cBaiTap2.GioBatDau = pBaiTap.GioBatDau;
            cBaiTap2.PhutBatDau = pBaiTap.PhutBatDau;
            cBaiTap2.NgayTao = today;
            cBaiTap2.LoaiBaiTapID = pBaiTap.LoaiBaiTapID;
            int num = CBaiTaps.Insert(cBaiTap);
            checked
            {
                if (num > 0)
                {
                    cBaiTap.BaiTapID = num;
                    string kyHieu = CBaiTaps.GetKyHieu(pBaiTap.BaiTapID);
                    CBaiTaps.UpdateKyHieu(num, kyHieu);
                    List<CRada> list = CBaiTapRadas.GetList(pBaiTap.BaiTapID);
                    foreach (CRada current in list)
                    {
                        CBaiTapRadas.Insert(num, current);
                        List<CKhuat> list2 = CBaiTapKhuats.GetList(pBaiTap.BaiTapID, current.RadaID);
                        foreach (CKhuat current2 in list2)
                        {
                            CBaiTapKhuats.Insert(num, current2);
                            List<CKhuatPt> khuatPts = CBaiTapKhuats.GetKhuatPts(pBaiTap.BaiTapID, current2.KhuatID);
                            CBaiTapKhuats.InsertPts(num, current2.KhuatID, khuatPts);
                        }

                    }

                    foreach (CFlight current3 in pFlights)
                    {
                        CTop cTop = new CTop(current3);
                        cTop.BaiTapID = num;
                        int num2 = CTops.Insert(cTop);
                        if (num2 > 0)
                        {
                            List<PathNode> path = cTop.Path;
                            int arg_185_0 = 0;
                            int num3 = path.Count - 1;
                            for (int i = arg_185_0; i <= num3; i++)
                            {
                                CTops.InsertNode(num2, path[i]);
                            }
                        }
                    }

                }
            }
        }
        public static List<CBaiTap> GetList()
        {
            List<CBaiTap> list = new List<CBaiTap>();
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(250);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("SELECT BaiTapID, LoaiBaiTapID, NgayTao, BaiTap, GioBatDau, PhutBatDau, SoPhut");
            stringBuilder2.Append(" FROM tblBaiTap");
            string text = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, true);
                while (dataReader.Read())
                {
                    CBaiTap cBaiTap = new CBaiTap();
                    CBaiTap cBaiTap2 = cBaiTap;
                    cBaiTap2.BaiTapID = dataReader.GetInt32(0);
                    cBaiTap2.LoaiBaiTapID = dataReader.GetInt32(1);
                    cBaiTap2.NgayTao = dataReader.GetDateTime(2);
                    cBaiTap2.BaiTap = dataReader.GetString(3);
                    cBaiTap2.GioBatDau = (int)dataReader.GetInt16(4);
                    cBaiTap2.PhutBatDau = (int)dataReader.GetInt16(5);
                    cBaiTap2.SoPhut = (int)dataReader.GetInt16(6);
                    list.Add(cBaiTap);
                }
                dataReader.Close();
            }
            catch (Exception expr_FE)
            {
                throw expr_FE;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public static int Insert(CBaiTap obj)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblBaiTap (LoaiBaiTapID, NgayTao, BaiTap, GioBatDau, PhutBatDau, SoPhut) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTap", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiBaiTapID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("NgayTao", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("GioBatDau", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PhutBatDau", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SoPhut", false));
            stringBuilder2.Append(")");
            string text = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(text);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long num = 0L;
            try
            {
                dbCommand.Transaction = dbTransaction;
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiBaiTapID", DbType.Int32, obj.LoaiBaiTapID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("NgayTao", DbType.DateTime, obj.NgayTao, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTap", DbType.String, obj.BaiTap, obj.BaiTap.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("GioBatDau", DbType.Double, obj.GioBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PhutBatDau", DbType.Double, obj.PhutBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SoPhut", DbType.Single, obj.SoPhut, 0));
                num = iDBUtility.InsertAndReturnSerialKey(ref dbCommand, "BaiTapID", "tblBaiTap");
                dbTransaction.Commit();
            }
            catch (Exception expr_1F7)
            {
                throw expr_1F7;
            }
            finally
            {
                connection.Close();
            }
            return checked((int)num);
        }
        public static long Update(CBaiTap obj)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(200);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("UPDATE tblBaiTap SET");
            stringBuilder2.Append(" LoaiBaiTapID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("LoaiBaiTapID", true));
            stringBuilder2.Append(" NgayTao = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("NgayTao", true));
            stringBuilder2.Append(" BaiTap = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTap", true));
            stringBuilder2.Append(" GioBatDau = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("GioBatDau", true));
            stringBuilder2.Append(" PhutBatDau = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PhutBatDau", true));
            stringBuilder2.Append(" SoPhut = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SoPhut", false));
            stringBuilder2.Append(" WHERE BaiTapID =");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("LoaiBaiTapID", DbType.Int32, obj.LoaiBaiTapID, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("NgayTao", DbType.DateTime, obj.NgayTao, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTap", DbType.String, obj.BaiTap, obj.BaiTap.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("GioBatDau", DbType.Double, obj.GioBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PhutBatDau", DbType.Double, obj.PhutBatDau, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SoPhut", DbType.Single, obj.SoPhut, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BaiTapID", DbType.Int32, obj.BaiTapID, 0));
                result = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_268)
            {
                throw expr_268;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long Delete(int pBaiTapID)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblBaiTap ");
            stringBuilder2.Append(" WHERE BaiTapID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BaiTapID", false));
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
            catch (Exception expr_BA)
            {
                throw expr_BA;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static string GetKyHieu(int pBaiTapID)
        {
            string result = "";
            OleDbConnection oleDbConnection = null;
            OleDbCommand oleDbCommand = null;
            OleDbDataReader oleDbDataReader = null;
            string cmdText = "SELECT KyHieu FROM tblBaiTap WHERE BaiTapID = " + Convert.ToString(pBaiTapID);
            try
            {
                oleDbConnection = new OleDbConnection(modHuanLuyen.myCnnString);
                oleDbConnection.Open();
                oleDbCommand = new OleDbCommand(cmdText, oleDbConnection);
                oleDbDataReader = oleDbCommand.ExecuteReader();
                while (oleDbDataReader.Read())
                {
                    byte[] array = (byte[])oleDbDataReader.GetValue(0);
                    try
                    {
                        result = Encoding.UTF8.GetString(array, 0, checked(array.GetUpperBound(0) + 1));
                    }
                    catch (Exception expr_6A)
                    {
                        throw expr_6A;
                    }
                }
            }
            catch (Exception expr_83)
            {
                throw expr_83;
            }
            finally
            {
                oleDbDataReader.Close();
                oleDbConnection.Close();
                oleDbCommand.Dispose();
                oleDbConnection.Dispose();
            }
            return result;
        }
        public static long UpdateKyHieu(int pBaiTapID, string strKyHieu)
        {
            OleDbConnection oleDbConnection = null;
            OleDbCommand oleDbCommand = null;
            int num = -1;
            string text = "UPDATE tblBaiTap SET";
            text += " KyHieu = ?";
            text += " WHERE BaiTapID = ?";
            try
            {
                oleDbConnection = new OleDbConnection(modHuanLuyen.myCnnString);
                oleDbConnection.Open();
                oleDbCommand = new OleDbCommand(text, oleDbConnection);
                oleDbCommand.Parameters.Add(new OleDbParameter("KyHieu", OleDbType.Binary, 0, "KyHieu"));
                oleDbCommand.Parameters.Add(new OleDbParameter("Original_BaiTapID", OleDbType.Integer, 0, ParameterDirection.Input, false, 10, 0, "BaiTapID", DataRowVersion.Original, null));
                oleDbCommand.Parameters["KyHieu"].Value = Encoding.UTF8.GetBytes(strKyHieu);
                oleDbCommand.Parameters["Original_BaiTapID"].Value = pBaiTapID;
                num = oleDbCommand.ExecuteNonQuery();
            }
            catch (Exception expr_CA)
            {
                throw expr_CA;
            }
            finally
            {
                oleDbConnection.Close();
                oleDbCommand.Dispose();
                oleDbConnection.Dispose();
            }
            return (long)num;
        }
    }
}
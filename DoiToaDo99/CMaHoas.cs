using ADOConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using HuanLuyen;

namespace DoiToaDo
{

        public partial class CMaHoas
        {
            public static List<CMaHoa> GetList()
            {
                List<CMaHoa> list = new List<CMaHoa>();
                string sText = "SELECT MaHoaID, Ten, OLon99, OCoBan99, OChinh55, OLon55  FROM tblMaHoa";
                IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
                IDbCommand dbCommand = connection.CreateCommand(sText);
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, true);
                while (dataReader.Read())
                {
                    try
                    {
                        CMaHoa cMaHoa = new CMaHoa();
                        CMaHoa cMaHoa2 = cMaHoa;
                        cMaHoa2.MaHoaID = dataReader.GetInt32(0);
                        cMaHoa2.Ten = dataReader.GetString(1);
                        cMaHoa2.OLon99 = dataReader.GetString(2);
                        cMaHoa2.OCoBan99 = dataReader.GetString(3);
                        cMaHoa2.OChinh55 = dataReader.GetString(4);
                        cMaHoa2.OLon55 = dataReader.GetString(5);
                        list.Add(cMaHoa);
                    }
                    catch (Exception expr_A0)
                    {
                        throw expr_A0;
                    }
                }
                dataReader.Close();
                connection.Close();
                return list;
            }
            public static CMaHoa GetMaHoa(int pMaHoaID)
            {
                CMaHoa cMaHoa = null;
                string text = "SELECT Ten, OLon99, OCoBan99, OChinh55, OLon55 FROM tblMaHoa WHERE MaHoaID = " + pMaHoaID.ToString();
                IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
                IDbCommand dbCommand = connection.CreateCommand(text);
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, true);
                try
                {
                    while (dataReader.Read())
                    {
                        cMaHoa = new CMaHoa();
                        CMaHoa cMaHoa2 = cMaHoa;
                        cMaHoa2.MaHoaID = pMaHoaID;
                        cMaHoa2.Ten = dataReader.GetString(0);
                        cMaHoa2.OLon99 = dataReader.GetString(1);
                        cMaHoa2.OCoBan99 = dataReader.GetString(2);
                        cMaHoa2.OChinh55 = dataReader.GetString(3);
                        cMaHoa2.OLon55 = dataReader.GetString(4);
                    }
                }
                catch (Exception expr_9F)
                {
                    throw expr_9F;
                }
                finally
                {
                    dataReader.Close();
                    connection.Close();
                }
                if (cMaHoa == null)
                {
                    cMaHoa = modMaHoa.GetMaHoaMacDinh();
                }
                return cMaHoa;
            }
            public static int Insert(CMaHoa obj)
            {
                IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
                IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
                StringBuilder stringBuilder = new StringBuilder(150);
                StringBuilder stringBuilder2 = stringBuilder;
                stringBuilder2.Append("INSERT INTO tblMaHoa (Ten, OLon99, OCoBan99, OChinh55, OLon55) VALUES(");
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Ten", true));
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("OLon99", true));
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("OCoBan99", true));
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("OChinh55", true));
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("OLon55", false));
                stringBuilder2.Append(")");
                string text = stringBuilder.ToString();
                IDbCommand dbCommand = connection.CreateCommand(text);
                IDbTransaction dbTransaction = connection.BeginTransaction();
                long num = 0L;
                try
                {
                    dbCommand.Transaction = dbTransaction;
                    IDbCommand dbCommand2 = dbCommand;
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Ten", DbType.String, obj.Ten, obj.Ten.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("OLon99", DbType.String, obj.OLon99, obj.OLon99.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("OCoBan99", DbType.String, obj.OCoBan99, obj.OCoBan99.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("OChinh55", DbType.String, obj.OChinh55, obj.OChinh55.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("OLon55", DbType.String, obj.OLon55, obj.OLon55.Length));
                    num = iDBUtility.InsertAndReturnSerialKey(ref dbCommand, "MaHoaID", "tblMaHoa");
                    dbTransaction.Commit();
                }
                catch (Exception expr_1D2)
                {
                    throw expr_1D2;
                }
                finally
                {
                    connection.Close();
                }
                return checked((int)num);
            }
            public static long Update(CMaHoa obj)
            {
                long result = 0L;
                IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
                IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
                StringBuilder stringBuilder = new StringBuilder(200);
                StringBuilder stringBuilder2 = stringBuilder;
                stringBuilder2.Append("UPDATE tblMaHoa SET");
                stringBuilder2.Append(" Ten = ");
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Ten", true));
                stringBuilder2.Append(" OLon99 = ");
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("OLon99", true));
                stringBuilder2.Append(" OCoBan99 = ");
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("OCoBan99", true));
                stringBuilder2.Append(" OChinh55 = ");
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("OChinh55", true));
                stringBuilder2.Append(" OLon55 = ");
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("OLon55", false));
                stringBuilder2.Append(" WHERE MaHoaID =");
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("MaHoaID", false));
                string sText = stringBuilder.ToString();
                IDbTransaction dbTransaction = connection.BeginTransaction();
                IDbCommand dbCommand = connection.CreateCommand(sText);
                try
                {
                    IDbCommand dbCommand2 = dbCommand;
                    dbCommand2.Transaction = dbTransaction;
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Ten", DbType.String, obj.Ten, obj.Ten.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("OLon99", DbType.String, obj.OLon99, obj.OLon99.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("OCoBan99", DbType.String, obj.OCoBan99, obj.OCoBan99.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("OChinh55", DbType.String, obj.OChinh55, obj.OChinh55.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("OLon55", DbType.String, obj.OLon55, obj.OLon55.Length));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("MaHoaID", DbType.Int32, obj.MaHoaID, 0));
                    result = (long)dbCommand2.ExecuteNonQuery();
                    dbTransaction.Commit();
                }
                catch (Exception expr_238)
                {
                    throw expr_238;
                }
                finally
                {
                    connection.Close();
                }
                return result;
            }
            public static long Delete(int pMaHoaID)
            {
                long result = 0L;
                IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
                IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
                StringBuilder stringBuilder = new StringBuilder(150);
                StringBuilder stringBuilder2 = stringBuilder;
                stringBuilder2.Append("DELETE FROM tblMaHoa ");
                stringBuilder2.Append(" WHERE MaHoaID = ");
                stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("MaHoaID", false));
                string sText = stringBuilder.ToString();
                IDbTransaction dbTransaction = connection.BeginTransaction();
                IDbCommand dbCommand = connection.CreateCommand(sText);
                try
                {
                    IDbCommand dbCommand2 = dbCommand;
                    dbCommand2.Transaction = dbTransaction;
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("MaHoaID", DbType.Int32, pMaHoaID, 0));
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
        }
}

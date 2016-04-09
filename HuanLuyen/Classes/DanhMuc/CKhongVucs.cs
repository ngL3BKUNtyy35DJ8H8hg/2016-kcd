using ADOConnection;
using AxMapXLib;
using MapXLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Text;
namespace HuanLuyen
{
    public class CKhongVucs
    {
        public static List<CKhongVuc> GetList(int lSB_ID)
        {
            List<CKhongVuc> list = new List<CKhongVuc>();
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(250);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("SELECT Stt, PosX, PosY, BanKinh, Name");
            stringBuilder2.Append(" FROM tblKhongVuc");
            stringBuilder2.Append(" WHERE (SB_ID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SB_ID", false));
            stringBuilder2.Append(")");
            stringBuilder2.Append(" ORDER BY Stt");
            string sText = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            IDbCommand dbCommand2 = dbCommand;
            dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SB_ID", DbType.Int32, lSB_ID, 0));
            try
            {
                CDataReader dataReader = connection.GetDataReader(ref dbCommand, true);
                while (dataReader.Read())
                {
                    CKhongVuc cKhongVuc = new CKhongVuc();
                    CKhongVuc cKhongVuc2 = cKhongVuc;
                    cKhongVuc2.Stt = (int)dataReader.GetInt16(0);
                    cKhongVuc2.Pos.x = dataReader.GetDouble(1);
                    cKhongVuc2.Pos.y = dataReader.GetDouble(2);
                    cKhongVuc2.BanKinh = Convert.ToSingle(dataReader.GetValue(3));
                    cKhongVuc2.Name = dataReader.GetString(4);
                    list.Add(cKhongVuc);
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
        public static long Inserts(List<CKhongVuc> pKhongVucs)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblKhongVuc (SB_ID, Stt, PosX, PosY, BanKinh, Name) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SB_ID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Stt", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BanKinh", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Name", false));
            stringBuilder2.Append(")");
            string text = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(text);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long result = 0L;
            try
            {
                dbCommand.Transaction = dbTransaction;
                foreach (CKhongVuc current in pKhongVucs)
                {
                    IDbCommand dbCommand2 = dbCommand;
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SB_ID", DbType.Int32, current.SB_ID, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, current.Stt, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, current.Pos.x, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, current.Pos.y, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BanKinh", DbType.Single, current.BanKinh, 0));
                    dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Name", DbType.String, current.Name, 0));
                    result = (long)dbCommand2.ExecuteNonQuery();
                    dbCommand2.Parameters.Clear();
                }

                dbTransaction.Commit();
            }
            catch (Exception expr_231)
            {
                throw expr_231;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long Inserts(int pSB_ID, DataView dv)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("INSERT INTO tblKhongVuc (SB_ID, Stt, PosX, PosY, BanKinh, Name) VALUES(");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SB_ID", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Stt", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosX", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("PosY", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("BanKinh", true));
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("Name", false));
            stringBuilder2.Append(")");
            string text = stringBuilder.ToString();
            IDbCommand dbCommand = connection.CreateCommand(text);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long result = 0L;
            int num = 0;
            try
            {
                dbCommand.Transaction = dbTransaction;
                foreach (DataRowView dataRowView in dv)
                {
                    IDbCommand dbCommand2;
                    checked
                    {
                        num++;
                        dbCommand2 = dbCommand;
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SB_ID", DbType.Int32, pSB_ID, 0));
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Stt", DbType.Int16, num, 0));
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosX", DbType.Double, dataRowView["PosX"], 0));
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("PosY", DbType.Double, dataRowView["PosY"], 0));
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("BanKinh", DbType.Single, dataRowView["BanKinh"], 0));
                        dbCommand2.Parameters.Add(iDBUtility.CreateParameter("Name", DbType.String, dataRowView["Name"], dataRowView["Name"].ToString().Length));
                    }
                    result = (long)dbCommand2.ExecuteNonQuery();
                    dbCommand2.Parameters.Clear();
                }

                dbTransaction.Commit();
            }
            catch (Exception expr_260)
            {
                throw expr_260;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static long Delete(int pSB_ID)
        {
            long result = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            StringBuilder stringBuilder = new StringBuilder(150);
            StringBuilder stringBuilder2 = stringBuilder;
            stringBuilder2.Append("DELETE FROM tblKhongVuc ");
            stringBuilder2.Append(" WHERE SB_ID = ");
            stringBuilder2.Append(iDBUtility.GetParamPlaceHolder("SB_ID", false));
            string sText = stringBuilder.ToString();
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SB_ID", DbType.Int32, pSB_ID, 0));
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
        public static struPhuongVi GetPhuongVi(MapPoint pTdPos, double pPosX, double pPosY)
        {
            struPhuongVi result = default(struPhuongVi);
            PointF pPT = default(PointF);
            PointF pPT2 = default(PointF);
            AxMap arg_47_0 = modHuanLuyen.fMain.AxMap1;
            float num = pPT.X;
            float num2 = pPT.Y;
            arg_47_0.ConvertCoord(ref num, ref num2, ref pTdPos.x, ref pTdPos.y, ConversionConstants.miMapToScreen);
            pPT.Y = num2;
            pPT.X = num;
            AxMap arg_83_0 = modHuanLuyen.fMain.AxMap1;
            num2 = pPT2.X;
            num = pPT2.Y;
            arg_83_0.ConvertCoord(ref num2, ref num, ref pPosX, ref pPosY, ConversionConstants.miMapToScreen);
            pPT2.Y = num;
            pPT2.X = num2;
            result.CuLy = modHuanLuyen.fMain.AxMap1.Distance(pTdPos.x, pTdPos.y, pPosX, pPosY) / 1000.0;
            result.PhuongVi = modHuanLuyen.GetHDG(pPT, pPT2);
            return result;
        }
        public static MapPoint GetMapPtFromPhuongVi(AxMap pMap, MapPoint pTdPos, double heading, double mBanKinh)
        {
            MapPoint result = new MapPoint(0.0, 0.0);
            try
            {
                PointF point = default(PointF);
                float num = point.X;
                float num2 = point.Y;
                pMap.ConvertCoord(ref num, ref num2, ref pTdPos.x, ref pTdPos.y, ConversionConstants.miMapToScreen);
                point.Y = num2;
                point.X = num;
                double num3 = pMap.Distance(pTdPos.x, pTdPos.y, pTdPos.x, pTdPos.y + 10.0) / 1000.0;
                MapPoint mapPoint = new MapPoint(pTdPos.x, pTdPos.y + mBanKinh * 10.0 / num3);
                PointF[] array = new PointF[1];
                PointF[] array2 = array;
                PointF[] arg_CC_0 = array2;
                int num4 = 0;
                num2 = arg_CC_0[num4].X;
                PointF[] array3 = array;
                PointF[] arg_E4_0 = array3;
                int num5 = 0;
                num = arg_E4_0[num5].Y;
                pMap.ConvertCoord(ref num2, ref num, ref mapPoint.x, ref mapPoint.y, ConversionConstants.miMapToScreen);
                array3[num5].Y = num;
                array2[num4].X = num2;
                Matrix matrix = new Matrix();
                matrix.RotateAt((float)heading, point, MatrixOrder.Prepend);
                matrix.TransformPoints(array);
                array3 = array;
                PointF[] arg_14C_0 = array3;
                num5 = 0;
                num2 = arg_14C_0[num5].X;
                array2 = array;
                PointF[] arg_164_0 = array2;
                num4 = 0;
                num = arg_164_0[num4].Y;
                pMap.ConvertCoord(ref num2, ref num, ref result.x, ref result.y, ConversionConstants.miScreenToMap);
                array2[num4].Y = num;
                array3[num5].X = num2;
            }
            catch (Exception expr_1A8)
            {
                throw expr_1A8;
            }
            return result;
        }
    }
}
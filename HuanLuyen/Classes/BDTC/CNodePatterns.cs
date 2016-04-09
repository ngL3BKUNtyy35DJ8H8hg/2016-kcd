using ADOConnection;
using DBiGraphicObjs.DBiGraphicObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Xml;
namespace HuanLuyen
{
    public static class CNodePatterns
    {
        private static CNodePattern GetDefaPattern()
        {
            PointF[] array = new PointF[4];
            array[0].X = -3f;
            array[0].Y = -3f;
            array[1].X = -3f;
            array[1].Y = 3f;
            array[2].X = 3f;
            array[2].Y = 3f;
            array[3].X = 3f;
            array[3].Y = -3f;
            PolygonGraphic aGObj = new PolygonGraphic(array, 1f, Color.Blue);
            return new CNodePattern(0, 0, 0, new CGraphicObjs{aGObj});
        }
        public static CNodePattern GetPattern(int pStyle)
        {
            CNodePattern cNodePattern = (CNodePattern)modHuanLuyen.m_NodePatterns[pStyle];
            if (cNodePattern == null)
            {
                cNodePattern = CNodePatterns.GetDefaPattern();
            }
            return cNodePattern;
        }
        public static ArrayList GetAllPatterns()
        {
            ArrayList arrayList = new ArrayList();
            string sText = "SELECT SymbolStyle, KyHieu  FROM tblKyHieu";
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            CDataReader dataReader = connection.GetDataReader(ref dbCommand, true);
            while (dataReader.Read())
            {
                try
                {
                    int @int = (int)dataReader.GetInt16(0);
                    string @string = dataReader.GetString(1);
                    CNodePattern cNodePattern = CNodePatterns.Str2Pattern(@string);
                    cNodePattern.PattNo = @int;
                    arrayList.Add(cNodePattern);
                }
                catch (Exception expr_5E)
                {
                    throw expr_5E;
                }
            }
            dataReader.Close();
            connection.Close();
            return arrayList;
        }
        public static List<CStrPattern> GetAllStrPatterns()
        {
            List<CStrPattern> list = new List<CStrPattern>();
            string sText = "SELECT SymbolStyle, KyHieu  FROM tblKyHieu";
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            CDataReader dataReader = connection.GetDataReader(ref dbCommand, true);
            while (dataReader.Read())
            {
                try
                {
                    CStrPattern cStrPattern = new CStrPattern();
                    CStrPattern cStrPattern2 = cStrPattern;
                    cStrPattern2.PattNo = (int)dataReader.GetInt16(0);
                    cStrPattern2.StrPattern = dataReader.GetString(1);
                    list.Add(cStrPattern);
                }
                catch (Exception expr_64)
                {
                    throw expr_64;
                }
            }
            dataReader.Close();
            connection.Close();
            return list;
        }
        public static ArrayList GetAllThumbNails()
        {
            ArrayList arrayList = new ArrayList();
            string text = "select KH_ID, TenKH, KyHieu,SymbolStyle from tblKyHieu";
            text += " order by SymbolStyle";
            CDataReader cDataReader = null;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                cDataReader = connection.GetDataReader(ref dbCommand, true);
                while (cDataReader.Read())
                {
                    CThumbNail value = new CThumbNail(cDataReader.GetString(1), cDataReader.GetInt32(0), cDataReader.GetString(2), (int)cDataReader.GetInt16(3));
                    arrayList.Add(value);
                }
            }
            catch (Exception expr_7A)
            {
                throw expr_7A;
            }
            finally
            {
                cDataReader.Close();
                connection.Close();
            }
            return arrayList;
        }
        public static int GetSymbolStyle(long pSymbol_ID)
        {
            int result = -1;
            string sText = "SELECT SymbolStyle FROM tblKyHieu WHERE KH_ID = " + Convert.ToString(pSymbol_ID);
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDbCommand dbCommand = connection.CreateCommand(sText);
            CDataReader cDataReader = null;
            try
            {
                cDataReader = connection.GetDataReader(ref dbCommand, false);
                while (cDataReader.Read())
                {
                    result = (int)cDataReader.GetInt16(0);
                }
            }
            catch (Exception expr_4C)
            {
                throw expr_4C;
            }
            finally
            {
                cDataReader.Close();
                connection.Close();
            }
            return result;
        }
        public static bool UpdateKyHieu(long pKH_ID, string pKH, string pTenKH, int pSymbolStyle)
        {
            bool result = false;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            string text = "UPDATE tblKyHieu SET";
            text = text + " TenKH = " + iDBUtility.GetParamPlaceHolder("TenKH", true);
            text = text + " KyHieu = " + iDBUtility.GetParamPlaceHolder("KyHieu", true);
            text = text + " SymbolStyle = " + iDBUtility.GetParamPlaceHolder("SymbolStyle", false);
            text = text + " WHERE KH_ID = " + iDBUtility.GetParamPlaceHolder("KH_ID", false);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("TenKH", DbType.String, pTenKH, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KyHieu", DbType.String, pKH, pKH.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SymbolStyle", DbType.Int16, pSymbolStyle, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KH_ID", DbType.Int32, pKH_ID, 0));
                long num = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
                result = true;
            }
            catch (Exception expr_147)
            {
                throw expr_147;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static object DeleteKyHieu(long pKH_ID)
        {
            bool flag = false;
            long num = 0L;
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            string text = "DELETE FROM tblKyHieu ";
            text += "WHERE KH_ID = ";
            text += iDBUtility.GetParamPlaceHolder("KH_ID", false);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            IDbCommand dbCommand = connection.CreateCommand(text);
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KH_ID", DbType.Int32, pKH_ID, 0));
                num = (long)dbCommand2.ExecuteNonQuery();
                dbTransaction.Commit();
            }
            catch (Exception expr_A0)
            {
                throw expr_A0;
            }
            finally
            {
                connection.Close();
            }
            if (num != 1L)
            {
            }
            else
            {
                flag = true;
            }
            return flag;
        }
        public static long AddKyHieu(string pKH, string pTenKH, int pSymbolStyle)
        {
            IADOConnection connection = modHuanLuyen.g_objConnFactory.GetConnection();
            IDBUtility iDBUtility = (IDBUtility)connection.DBUtility;
            string text = "INSERT INTO tblKyHieu ";
            text += "(SymbolStyle, TenKH, KyHieu)";
            text += " VALUES (";
            text += iDBUtility.GetParamPlaceHolder("SymbolStyle", true);
            text += iDBUtility.GetParamPlaceHolder("TenKH", true);
            text += iDBUtility.GetParamPlaceHolder("KyHieu", false);
            text += ")";
            IDbCommand dbCommand = connection.CreateCommand(text);
            IDbTransaction dbTransaction = connection.BeginTransaction();
            long result = -1L;
            try
            {
                IDbCommand dbCommand2 = dbCommand;
                dbCommand2.Transaction = dbTransaction;
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("SymbolStyle", DbType.Int16, pSymbolStyle, 0));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("TenKH", DbType.String, pTenKH, pTenKH.Length));
                dbCommand2.Parameters.Add(iDBUtility.CreateParameter("KyHieu", DbType.String, pKH, pKH.Length));
                result = iDBUtility.InsertAndReturnSerialKey(ref dbCommand, "KH_ID", "tblKyHieu");
                dbTransaction.Commit();
            }
            catch (Exception expr_131)
            {
                throw expr_131;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public static CNodePattern Str2Pattern(string xmlFrag)
        {
            NameTable nameTable = new NameTable();
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(nameTable);
            xmlNamespaceManager.AddNamespace("bk", "urn:sample");
            XmlParserContext context = new XmlParserContext(null, xmlNamespaceManager, null, XmlSpace.None);
            XmlTextReader xmlTextReader = new XmlTextReader(xmlFrag, XmlNodeType.Element, context);
            int num = 5;
            int num2 = 5;
            CNodePattern cNodePattern = new CNodePattern(0, 0, 0, null);
            string text = "";
            while (xmlTextReader.Read())
            {
                XmlNodeType nodeType = xmlTextReader.NodeType;
                XmlNodeType xmlNodeType = nodeType;
                if (xmlNodeType == XmlNodeType.Element)
                {
                    string name = xmlTextReader.Name;
                    if (name == "KyHieu")
                    {
                        if (xmlTextReader.AttributeCount > 0)
                        {
                            while (xmlTextReader.MoveToNextAttribute())
                            {
                                string name2 = xmlTextReader.Name;
                                if (name2 == "CX")
                                {
                                    num = Convert.ToInt32(xmlTextReader.Value);
                                }
                                else if (name2 == "CY")
                                {
                                    num2 = Convert.ToInt32(xmlTextReader.Value);
                                }
                            }
                        }
                    }
                    else if (name == "Part")
                    {
                        text = xmlTextReader.ReadOuterXml();
                        while (xmlTextReader.Name == "Part")
                        {
                            text += xmlTextReader.ReadOuterXml();
                        }
                    }
                }
                else if (xmlNodeType == XmlNodeType.EndElement)
                {
                }
            }
            xmlTextReader.Close();
            cNodePattern.CX = num;
            cNodePattern.CY = num2;
            cNodePattern.Pattern = CGraphicObjs.Str2Objects(text, num, num2, modHuanLuyen.cDecSepa, modHuanLuyen.cGrpSepa);
            return cNodePattern;
        }
    }
}
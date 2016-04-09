using System;
namespace TinhBao55
{
    public static class modBanTin
    {
        public static string GetValueString(int pValue)
        {
            string text = "";
            string text2 = pValue.ToString();
            if (text2.Length < 2)
            {
                if (text.Length > 0)
                {
                    text += " không";
                }
                else
                {
                    text += "không";
                }
                text2 = "0" + text2;
            }
            if (text2.Length > 2)
            {
                modBanTin.DocNhom(ref text, text2);
            }
            else
            {
                modBanTin.DocNhom2(ref text, text2);
            }
            return text;
        }
        public static string GetValueString0(int pValue)
        {
            string result = "";
            string text = pValue.ToString();
            if (text.Length < 2)
            {
                text = "0" + text;
            }
            if (text.Length > 2)
            {
                modBanTin.DocNhom(ref result, text);
            }
            else
            {
                modBanTin.DocNhom2(ref result, text);
            }
            return result;
        }
        public static string GetKyTuSoString(string pKyTuSo)
        {
            string text = "";
            char[] charArr = pKyTuSo.ToCharArray();
            for (int i = 0; i < charArr.Length; i++)
            {
                int val = int.Parse(charArr.GetValue(i).ToString());
                switch (val)
                {
                    case 0:
                        if (text.Length == 0)
                        {
                            text = "không";
                        }
                        else
                        {
                            text += " không";
                        }
                        break;
                    case 1:
                        if (text.Length == 0)
                        {
                            text = "một";
                        }
                        else
                        {
                            text += " một";
                        }
                        break;
                    case 2:
                        if (text.Length == 0)
                        {
                            text = "hai";
                        }
                        else
                        {
                            text += " hai";
                        }
                        break;
                    case 3:
                        if (text.Length == 0)
                        {
                            text = "ba";
                        }
                        else
                        {
                            text += " ba";
                        }
                        break;
                    case 4:
                        if (text.Length == 0)
                        {
                            text = "bốn";
                        }
                        else
                        {
                            text += " bốn";
                        }
                        break;
                    case 5:
                        if (text.Length == 0)
                        {
                            text = "năm";
                        }
                        else
                        {
                            text += " năm";
                        }
                        break;
                    case 6:
                        if (text.Length == 0)
                        {
                            text = "sáu";
                        }
                        else
                        {
                            text += " sáu";
                        }
                        break;
                    case 7:
                        if (text.Length == 0)
                        {
                            text = "bẩy";
                        }
                        else
                        {
                            text += " bẩy";
                        }
                        break;
                    case 8:
                        if (text.Length == 0)
                        {
                            text = "tám";
                        }
                        else
                        {
                            text += " tám";
                        }
                        break;
                    case 9:
                        if (text.Length == 0)
                        {
                            text = "chín";
                        }
                        else
                        {
                            text += " chín";
                        }
                        break;
                }
            }
            return text;
        }
        private static void DocNhom2(ref string KQ, string pValue)
        {
            if (int.Parse(pValue) > 0)
            {
                int num = int.Parse(pValue[0].ToString());
                int num2 = int.Parse(pValue[1].ToString());
                switch (num)
                {
                    case 1:
                        if (KQ.Length == 0)
                        {
                            KQ = "mười";
                        }
                        else
                        {
                            KQ += " mười";
                        }
                        break;
                    case 2:
                        if (KQ.Length == 0)
                        {
                            KQ = "hai";
                        }
                        else
                        {
                            KQ += " hai";
                        }
                        break;
                    case 3:
                        if (KQ.Length == 0)
                        {
                            KQ = "ba";
                        }
                        else
                        {
                            KQ += " ba";
                        }
                        break;
                    case 4:
                        if (KQ.Length == 0)
                        {
                            KQ = "bốn";
                        }
                        else
                        {
                            KQ += " bốn";
                        }
                        break;
                    case 5:
                        if (KQ.Length == 0)
                        {
                            KQ = "năm";
                        }
                        else
                        {
                            KQ += " năm";
                        }
                        break;
                    case 6:
                        if (KQ.Length == 0)
                        {
                            KQ = "sáu";
                        }
                        else
                        {
                            KQ += " sáu";
                        }
                        break;
                    case 7:
                        if (KQ.Length == 0)
                        {
                            KQ = "bẩy";
                        }
                        else
                        {
                            KQ += " bẩy";
                        }
                        break;
                    case 8:
                        if (KQ.Length == 0)
                        {
                            KQ = "tám";
                        }
                        else
                        {
                            KQ += " tám";
                        }
                        break;
                    case 9:
                        if (KQ.Length == 0)
                        {
                            KQ = "chín";
                        }
                        else
                        {
                            KQ += " chín";
                        }
                        break;
                }
                switch (num2)
                {
                    case 0:
                        if (num > 1)
                        {
                            KQ += " mươi";
                        }
                        break;
                    case 1:
                        if (num > 1)
                        {
                            KQ += " mốt";
                        }
                        else if (KQ.Length == 0)
                        {
                            KQ = "một";
                        }
                        else
                        {
                            KQ += " một";
                        }
                        break;
                    case 2:
                        if (KQ.Length == 0)
                        {
                            KQ = "hai";
                        }
                        else
                        {
                            KQ += " hai";
                        }
                        break;
                    case 3:
                        if (KQ.Length == 0)
                        {
                            KQ = "ba";
                        }
                        else
                        {
                            KQ += " ba";
                        }
                        break;
                    case 4:
                        if (KQ.Length == 0)
                        {
                            KQ = "bốn";
                        }
                        else
                        {
                            KQ += " bốn";
                        }
                        break;
                    case 5:
                        if (num > 0)
                        {
                            KQ += " lăm";
                        }
                        else if (KQ.Length == 0)
                        {
                            KQ = "năm";
                        }
                        else
                        {
                            KQ += " năm";
                        }
                        break;
                    case 6:
                        if (KQ.Length == 0)
                        {
                            KQ = "sáu";
                        }
                        else
                        {
                            KQ += " sáu";
                        }
                        break;
                    case 7:
                        if (KQ.Length == 0)
                        {
                            KQ = "bẩy";
                        }
                        else
                        {
                            KQ += " bẩy";
                        }
                        break;
                    case 8:
                        if (KQ.Length == 0)
                        {
                            KQ = "tám";
                        }
                        else
                        {
                            KQ += " tám";
                        }
                        break;
                    case 9:
                        if (KQ.Length == 0)
                        {
                            KQ = "chín";
                        }
                        else
                        {
                            KQ += " chín";
                        }
                        break;
                }
            }
        }
        private static void DocNhom(ref string KQ, string pValue)
        {
            if (int.Parse(pValue) > 0)
            {
                int num = int.Parse(pValue[0].ToString());
                int num2 = int.Parse(pValue[1].ToString());
                int num3 = int.Parse(pValue[2].ToString());
                switch (num)
                {
                    case 0:
                        if (KQ.Length == 0)
                        {
                            KQ = "";
                        }
                        else
                        {
                            KQ += " khôngtrăm";
                        }
                        break;
                    case 1:
                        if (KQ.Length == 0)
                        {
                            KQ = "mộttrăm";
                        }
                        else
                        {
                            KQ += " mộttrăm";
                        }
                        break;
                    case 2:
                        if (KQ.Length == 0)
                        {
                            KQ = "haitrăm";
                        }
                        else
                        {
                            KQ += " haitrăm";
                        }
                        break;
                    case 3:
                        if (KQ.Length == 0)
                        {
                            KQ = "batrăm";
                        }
                        else
                        {
                            KQ += " batrăm";
                        }
                        break;
                    case 4:
                        if (KQ.Length == 0)
                        {
                            KQ = "bốntrăm";
                        }
                        else
                        {
                            KQ += " bốntrăm";
                        }
                        break;
                    case 5:
                        if (KQ.Length == 0)
                        {
                            KQ = "nămtrăm";
                        }
                        else
                        {
                            KQ += " nămtrăm";
                        }
                        break;
                    case 6:
                        if (KQ.Length == 0)
                        {
                            KQ = "sáutrăm";
                        }
                        else
                        {
                            KQ += " sáutrăm";
                        }
                        break;
                    case 7:
                        if (KQ.Length == 0)
                        {
                            KQ = "bẩytrăm";
                        }
                        else
                        {
                            KQ += " bẩytrăm";
                        }
                        break;
                    case 8:
                        if (KQ.Length == 0)
                        {
                            KQ = "támtrăm";
                        }
                        else
                        {
                            KQ += " támtrăm";
                        }
                        break;
                    case 9:
                        if (KQ.Length == 0)
                        {
                            KQ = "chíntrăm";
                        }
                        else
                        {
                            KQ += " chíntrăm";
                        }
                        break;
                }
                switch (num2)
                {
                    case 1:
                        if (KQ.Length == 0)
                        {
                            KQ = "mười";
                        }
                        else
                        {
                            KQ += " mười";
                        }
                        break;
                    case 2:
                        if (KQ.Length == 0)
                        {
                            KQ = "haimươi";
                        }
                        else
                        {
                            KQ += " haimươi";
                        }
                        break;
                    case 3:
                        if (KQ.Length == 0)
                        {
                            KQ = "bamươi";
                        }
                        else
                        {
                            KQ += " bamươi";
                        }
                        break;
                    case 4:
                        if (KQ.Length == 0)
                        {
                            KQ = "bốnmươi";
                        }
                        else
                        {
                            KQ += " bốnmươi";
                        }
                        break;
                    case 5:
                        if (KQ.Length == 0)
                        {
                            KQ = "nămmươi";
                        }
                        else
                        {
                            KQ += " nămmươi";
                        }
                        break;
                    case 6:
                        if (KQ.Length == 0)
                        {
                            KQ = "sáumươi";
                        }
                        else
                        {
                            KQ += " sáumươi";
                        }
                        break;
                    case 7:
                        if (KQ.Length == 0)
                        {
                            KQ = "bẩymươi";
                        }
                        else
                        {
                            KQ += " bẩymươi";
                        }
                        break;
                    case 8:
                        if (KQ.Length == 0)
                        {
                            KQ = "támmươi";
                        }
                        else
                        {
                            KQ += " támmươi";
                        }
                        break;
                    case 9:
                        if (KQ.Length == 0)
                        {
                            KQ = "chínmươi";
                        }
                        else
                        {
                            KQ += " chínmươi";
                        }
                        break;
                }
                if ((num2 == 0 & num3 > 0) && KQ.Length > 0)
                {
                    KQ += " linh";
                }
                switch (num3)
                {
                    case 1:
                        if (num2 > 1)
                        {
                            KQ += " mốt";
                        }
                        else if (KQ.Length == 0)
                        {
                            KQ = "một";
                        }
                        else
                        {
                            KQ += " một";
                        }
                        break;
                    case 2:
                        if (KQ.Length == 0)
                        {
                            KQ = "hai";
                        }
                        else
                        {
                            KQ += " hai";
                        }
                        break;
                    case 3:
                        if (KQ.Length == 0)
                        {
                            KQ = "ba";
                        }
                        else
                        {
                            KQ += " ba";
                        }
                        break;
                    case 4:
                        if (KQ.Length == 0)
                        {
                            KQ = "bốn";
                        }
                        else
                        {
                            KQ += " bốn";
                        }
                        break;
                    case 5:
                        if (num2 > 0)
                        {
                            KQ += " lăm";
                        }
                        else if (KQ.Length == 0)
                        {
                            KQ = "năm";
                        }
                        else
                        {
                            KQ += " năm";
                        }
                        break;
                    case 6:
                        if (KQ.Length == 0)
                        {
                            KQ = "sáu";
                        }
                        else
                        {
                            KQ += " sáu";
                        }
                        break;
                    case 7:
                        if (KQ.Length == 0)
                        {
                            KQ = "bẩy";
                        }
                        else
                        {
                            KQ += " bẩy";
                        }
                        break;
                    case 8:
                        if (KQ.Length == 0)
                        {
                            KQ = "tám";
                        }
                        else
                        {
                            KQ += " tám";
                        }
                        break;
                    case 9:
                        if (KQ.Length == 0)
                        {
                            KQ = "chín";
                        }
                        else
                        {
                            KQ += " chín";
                        }
                        break;
                }
            }
        }
    }
}
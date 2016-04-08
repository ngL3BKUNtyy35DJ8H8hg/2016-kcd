using System;
namespace DoiToaDo
{
	public class modMaHoa
	{
		public static string str99OLonChuan = "1,6,2,7,3,8,4,9,5,0";
		public static string str55OChinhChuan = "4,5,6,3,0,7,2,1,8";
		public static string GetStrChuan()
		{
			string text = "";
			int num = 0;
				do
				{
					int num2 = 0;
					do
					{
						if (text.Length > 0)
						{
							text = text + "," + num.ToString("0") + num2.ToString("0");
						}
						else
						{
							text = text + num.ToString("0") + num2.ToString("0");
						}
						num2++;
					}
					while (num2 <= 9);
					num++;
				}
				while (num <= 9);
				return text;
					}
		public static string GetStrCoBanChuan()
		{
			string text = "";
			int num = 0;
				do
				{
					int num2 = 0;
					do
					{
						if (text.Length > 0)
						{
							text = text + "," + num.ToString("0") + num2.ToString("0");
						}
						else
						{
							text = text + num.ToString("0") + num2.ToString("0");
						}
						num2++;
					}
					while (num2 <= 9);
					num++;
				}
				while (num <= 9);
				string text2 = text;
				int num3 = 1;
				do
				{
					text2 = text2 + ";" + text;
					num3++;
				}
				while (num3 <= 9);
				return text2;
					}
		public static CMaHoa GetMaHoaMacDinh()
		{
			CMaHoa cMaHoa = new CMaHoa();
			CMaHoa cMaHoa2 = cMaHoa;
			cMaHoa2.Ten = "Mặc định";
			cMaHoa2.OLon99 = modMaHoa.str99OLonChuan;
			cMaHoa2.OCoBan99 = modMaHoa.GetStrCoBanChuan();
			cMaHoa2.OChinh55 = modMaHoa.str55OChinhChuan;
			cMaHoa2.OLon55 = modMaHoa.GetStrChuan();
			return cMaHoa;
		}
	}
}
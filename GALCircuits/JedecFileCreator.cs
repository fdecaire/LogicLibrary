using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALCircuits
{
	public class JedecFileCreator
	{
		public void Save(string fileName, List<int> fuseList )
		{
			using (var writer = new StreamWriter(fileName))
			{
				writer.WriteLine("Device    :    GAL16V8");
				writer.WriteLine();
				writer.WriteLine("Created By:    ");
				writer.WriteLine();
				writer.WriteLine("Date      :    ");
				writer.WriteLine();
				writer.WriteLine("*QP20");
				writer.WriteLine();
				writer.WriteLine("*QF2194");
				writer.WriteLine();
				writer.WriteLine("*G0");
				writer.WriteLine();
				writer.WriteLine("*F0");
				writer.WriteLine();

				for (int fuseRow = 0; fuseRow < 69; fuseRow++)
				{
					string row = "*L" + (fuseRow * 32).ToString("00000") + " ";
					for (int fuseCol = 0; fuseCol < 32 && fuseRow * 32 + fuseCol < 2194; fuseCol++)
					{
						if (fuseList.Contains(fuseRow * 32 + fuseCol))
						{
							row += "0";
						}
						else
						{
							row += "1";
						}
					}
					writer.WriteLine(row);
					writer.WriteLine();
				}
			}
			/*
Device    :    GAL16V8

Created By:    http://www.autoelectric.cn

Date      :    2017-01-18 19:33

*QP20

*QF2194

*G0

*F0

*L00000 11111111111111111011111111111111

			 */
		}
	}
}

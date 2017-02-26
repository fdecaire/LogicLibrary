using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace GALCircuits
{
	//TODO: this currently only works with the GAL16V8
	public class PdsFileParser
	{
		private string _sourceFile;
		private int _parserPos = 0;
		private List<int> _fuseList = new List<int>();
		private List<string> _pinList = new List<string>();
		private bool _pinListRow = true;
		private bool _destinationToken = true;
		private int _fuseRow;

		public PdsFileParser(string sourceFile)
		{
			// remove any /r (just keep /n)
			_sourceFile = sourceFile.Replace("\r", "");
		}

		public List<int> Parse()
		{
			string nextToken = GetNextToken();

			while (nextToken != "")
			{
				if (_pinListRow)
				{
					_pinList.Add(nextToken);

					if (nextToken.Contains("/"))
					{
						InvertOutputFuse(_pinList.Count);
					}
				}
				else
				{
					if (nextToken == "=")
					{
						_destinationToken = false;
					}

					else if (_destinationToken)
					{
						int pinNumber = _pinList.IndexOf(nextToken.Replace("/", ""));
						if (pinNumber > -1)
						{
							pinNumber++;
						}
						else
						{
							pinNumber = _pinList.IndexOf("/" + nextToken.Replace("/", ""));
							if (pinNumber > -1)
							{
								pinNumber++;
							}
							else
							{
								//TODO: error!
								throw new ArgumentOutOfRangeException();
							}
						}
						SetFuseRow(pinNumber);

						if (nextToken.Contains("/"))
						{
							InvertOutputFuse(pinNumber);
						}
					}

					// each time there is an OR (+), then increment the fuse row number
					else if (nextToken == "+")
					{
						_fuseRow++; //TODO: should check to see if there are too many rows
					}

					else if (nextToken != "*")
					{
						if (nextToken.ToUpper() == "VCC")
						{
							// skip this row of fuses
							//TODO: need to set VCC to always enabled and GND to always disabled
						}
						else
						{
							// set a fuse
							int fuseColumn = GetFuseColumn(nextToken);

							if (fuseColumn > -1)
							{
								_fuseList.Add(_fuseRow * 32 + fuseColumn);
							}
							else
							{
								//TODO: error!
								throw new ArgumentOutOfRangeException();
							}
						}
					}

					// read a formula and compute the fuse list
					var test = "";
				}

				nextToken = GetNextToken();
			}

			MarkUnusedRows();

			_fuseList.Sort();

			return _fuseList;
		}

		private void MarkUnusedRows()
		{
			for (int i = 0; i < 64; i++)
			{
				if (!DoesRowHaveFuses(i))
				{
					_fuseList.Add(i + 2128);
				}
			}
		}

		private bool DoesRowHaveFuses(int row)
		{
			return (from a in _fuseList where a > row * 32 && a < row * 32 + 32 select a).Any();
		}

		private void InvertOutputFuse(int pinNumber)
		{
			// pins 19,18,17,16,15,14,13,12 can be set active low
			// 2048 - 2055
			switch (pinNumber)
			{
				case 19:
					_fuseList.Add(2048);
					break;
				case 18:
					_fuseList.Add(2049);
					break;
				case 17:
					_fuseList.Add(2050);
					break;
				case 16:
					_fuseList.Add(2051);
					break;
				case 15:
					_fuseList.Add(2052);
					break;
				case 14:
					_fuseList.Add(2053);
					break;
				case 13:
					_fuseList.Add(2054);
					break;
				case 12:
					_fuseList.Add(2055);
					break;
			}
		}

		private int GetFuseColumn(string inputName)
		{
			int[] columnNumberByPin = {-1, 2, 0, 4, 8, 12, 16, 20, 24, 28, -1, 30, -1, 26, 22, 18, 14, 10, 6, -1, -1};
			int[] inverseColNumberByPin = {-1, 3, 1, 5, 9, 13, 17, 21, 25, 29, -1, 31, 27, 23, 19, 15, 11, 7, -1, -1};
			bool inputInverted = false;

			int pinNumber = _pinList.IndexOf(inputName.Replace("/", ""));

			if (pinNumber > -1)
			{
				pinNumber++;
			}
			else
			{
				pinNumber = _pinList.IndexOf("/" + inputName.Replace("/", ""));

				if (pinNumber > -1)
				{
					inputInverted = true;
					pinNumber++;
				}
				else
				{
					// error!
					return -1;
				}
			}

			if (inputName.Contains("/") && !inputInverted)
			{
				return inverseColNumberByPin[pinNumber];
			}
			return columnNumberByPin[pinNumber];
		}

		private void SetFuseRow(int pinNumber)
		{
			// set the fuse row by the output pin number
			switch (pinNumber)
			{
				case 19:
					_fuseRow = 0;
					break;
				case 18:
					_fuseRow = 8;
					break;
				case 17:
					_fuseRow = 16;
					break;
				case 16:
					_fuseRow = 24;
					break;
				case 15:
					_fuseRow = 32;
					break;
				case 14:
					_fuseRow = 40;
					break;
				case 13:
					_fuseRow = 48;
					break;
				case 12:
					_fuseRow = 56;
					break;
			}
		}

		private string GetNextToken()
		{
			// skip blanks
			SkipBlanks();

			//skip any comment lines
			SkipCommentLine();

			string result = "";

			if (_parserPos < _sourceFile.Length && (_sourceFile[_parserPos] == '*' || _sourceFile[_parserPos] == '+' || _sourceFile[_parserPos] == '='))
			{
				result = _sourceFile[_parserPos].ToString();
				_parserPos++;

				return result;
			}

			while (_parserPos < _sourceFile.Length && _sourceFile[_parserPos] != ' ' && _sourceFile[_parserPos] != '\n' && _sourceFile[_parserPos] != '\t' && _sourceFile[_parserPos] != '*')
			{
				result += _sourceFile[_parserPos];
				_parserPos++;
			}

			return result;
		}

		private void SkipCommentLine()
		{
			if (_parserPos < _sourceFile.Length && _sourceFile[_parserPos] == ';')
			{
				while (_sourceFile[_parserPos] != '\n')
				{
					_parserPos++;

					if (_parserPos >= _sourceFile.Length)
					{
						return;
					}
				}

				SkipBlanks();
			}
		}

		private void SkipBlanks()
		{
			if (_parserPos >= _sourceFile.Length)
			{
				return;
			}

			while ( _sourceFile[_parserPos] == ' ' || _sourceFile[_parserPos] == '\t' ||
			       _sourceFile[_parserPos] == '\n')
			{
				if (_sourceFile[_parserPos] == '\n')
				{
					_destinationToken = true;
					if (_pinList.Count > 0)
					{
						_pinListRow = false;
					}
				}

				_parserPos++;

				if (_parserPos >= _sourceFile.Length)
				{
					return;
				}
			}
		}


	}
}

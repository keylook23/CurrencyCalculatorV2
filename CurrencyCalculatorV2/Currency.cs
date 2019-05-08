using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyCalculatorV2
{
	class Currency
	{
		public string Name { get; private set; }
		public string Code { get; private set; }
		public double Rate { get; private set; }
		public double Converter { get; private set; }

		public Currency(String code, double rate, string name, double converter)
		{
			Name = name;
			Code = code;
			Rate = rate;
			Converter = converter;
		}

		public override string ToString()
		{
			return Code;
		}
	}
}


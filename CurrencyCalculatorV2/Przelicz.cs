using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyCalculatorV2
{
	public class  Class1
	{
		double suma;
		string waluta1;

		string kod_waluty;
		double przelicznik;
		double kurs_sredni;

		public void LoadWalutas()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("Kursy.xml");



			foreach (XmlNode node in doc.SelectNodes("tabela_kursow/pozycja"))
			{
				.Form1.Listbox listbox1 = new listbox();
				listBox1.Items.Add((node["kod_waluty"].InnerText));
				listBox2.Items.Add((node["kod_waluty"].InnerText));
				//suma = przelicznik * kurs_sredni;
			}
		}
		public void CheckWalutas(string kod)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("Kursy.xml");
			foreach (XmlNode node in doc.SelectNodes("tabela_kursow/pozycja"))
			{
				if (waluta1 == (node["kod_waluty"].InnerText))
				{
					przelicznik = double.Parse(node["przelicznik"].InnerText);
					kurs_sredni = double.Parse(node["kurs_sredni"].InnerText);
					Form1.label1.Text = kurs_sredni.ToString();
				}
			}

		}
	}
}

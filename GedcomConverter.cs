using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Xsl;

namespace GEDCOMtoXML
{
    /// <summary>
    /// This class helps to read the genealogical file and convert into XML output
    /// </summary>
    public class Converter
	{
		/// <summary>
		/// This method is used to identify the Tag from genealogical file
		/// </summary>
		/// <param name="val">It carries the tag value</param>
		/// <returns></returns>
		static private bool IsTag(string val)
		{
			String[] tags = new string[]{   "INDI","NAME","SEX","BIRT","DATE",
											"PLAC","OCCU","FAMC","FAMS","NOTE",
											"CHAN","DATE","DEAT","TITL","SOUR",
											"CHIL","HUSB","FAM","MARR","DIV",
											"WIFE","CONT","CONC","AUTH","PUBL","TRLR"
										};
			foreach (String t in tags)
				if (t == val)
					return true;

			return false;
		}
		/// <summary>
		/// This method is to create the XML element based on the genealogical file format...
		/// </summary>
		/// <param name="import_ged_file">import path of geneological file</param>
		/// <param name="export_xml_file">export path of geneological file</param>
		/// <param name="idFilter">Id filter like "INDI", "FAM", "NOTE" etc....</param>
		/// <returns></returns>
		static public string ConvertXML(string import_ged_file, string export_xml_file,string idFilter)
		{
			// doing with XML
			XmlDocument xmlDoc = new XmlDocument();
			XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
			XmlElement rootNode = xmlDoc.CreateElement("GEDCOM");
			xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
			xmlDoc.AppendChild(rootNode);
			StreamReader sr = new StreamReader(import_ged_file);
			int prev_lvl = -1,
				cur_lvl = 0;
			XmlNode prevNode = rootNode;
			int count = 0;
			bool isSearchedIdFound = false;			
			while (!sr.EndOfStream)
			{				
				String line = sr.ReadLine();
				String[] elements = line.Split(' ');

				//Start : Fileter the information till the searched ID found
				if (elements[0] == "0" && count == 1 && elements[1] != "@" + idFilter + "@")
				{
                    break;
				}
				else if (elements[0] == "0" && elements[1] == "@" + idFilter + "@")
				{
					count++;
					isSearchedIdFound = true;
				}
				//End :Fileter the information till the searched ID found

				if (elements.Count() == 0)
					continue;

				cur_lvl = Convert.ToInt16(elements[0]);

				// find the id if present
				String id = "", tag = "", innerText = "";
				for (int i = 1; i < elements.Count(); ++i)
				{
					String element = elements[i];
					if (element.StartsWith("@"))						
					id = element;
					
					else if (IsTag(element))
						tag = element;
					else
						innerText += element + " ";
				}

				if (tag.Length == 0)
				{
					Console.WriteLine(line);
					continue;
				}
				if (isSearchedIdFound || string.IsNullOrEmpty(idFilter))
				{
					// create the new node
					XmlElement xmlElement = xmlDoc.CreateElement(tag);
					xmlElement.InnerText = innerText.Trim();
					XmlAttribute xmlAttribute = xmlDoc.CreateAttribute("level");
					xmlAttribute.InnerText = cur_lvl.ToString();
					xmlElement.Attributes.Append(xmlAttribute);
					if (id.Length > 0)
					{
						xmlAttribute = xmlDoc.CreateAttribute("id");
						xmlAttribute.InnerText = id;
						xmlElement.Attributes.Append(xmlAttribute);
					}

					if (cur_lvl == prev_lvl)
						prevNode.ParentNode.AppendChild(xmlElement);
					else if (cur_lvl > prev_lvl)
						prevNode.AppendChild(xmlElement);
					else
					{
						XmlNode pn = prevNode;
						for (int i = 0; i <= prev_lvl - cur_lvl; ++i)
							pn = pn.ParentNode;
						pn.AppendChild(xmlElement);
					}

					prevNode = xmlElement;
					prev_lvl = cur_lvl;
				}
				
			}

			// run the transformation and create the xml output
			XslCompiledTransform xslTrans = new XslCompiledTransform();
			xslTrans.Load(@"E:\GitHub\lookmaan-philips-assignment\GedTransform.xslt");
			if (!File.Exists(export_xml_file))
				File.Create(export_xml_file);
			XmlTextWriter xmlWriter = new XmlTextWriter(export_xml_file, null);
			xslTrans.Transform(xmlDoc, null, xmlWriter);			
			xmlDoc.Save(@"E:\GitHub\lookmaan-philips-assignment\Output\GetcomTransformedOutput.xml");
			Console.WriteLine("Your searched ouput....");
			Console.WriteLine();
			Console.WriteLine(xmlDoc.InnerXml);	
			xmlWriter.Close();
			sr.Close();
			return xmlDoc.InnerXml;
		}		
	}
}

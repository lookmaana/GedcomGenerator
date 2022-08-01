using Xunit;
using GEDCOMtoXML;

namespace GedcomGeneratorTest
{
    public class GedcomGeneratorTest
    {
        [Fact]
        public bool SearchIndivualId()
        {
            string indivualId = "I0001";
            string import_ged = @"E:\GitHub\lookmaan-philips-assignment\Input\Genealogical_data.txt";
            string export_xml = "output.xml";
            string xmlOutput = GEDCOMtoXML.Converter.ConvertXML(import_ged, export_xml, indivualId);
            if (xmlOutput != null && xmlOutput.Contains(indivualId))
            {
                return true;
            }
            return false;
        }

        //[Fact]
        //public void SearchFamilyId()
        //{

        //}
        //[Fact]
        //public void SearchNoteId()
        //{

        //}
        //[Fact]
        //public void SearchSourceId()
        //{

        //}
    }
}
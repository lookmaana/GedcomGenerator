namespace GedcomGenTest
{
    /// <summary>
    /// This class is used to test the positive and negative scenario of searching id's
    /// </summary>
    /// 
    // TODO : all the common local variable can be moved into global variable to avoid reduntancy....
    public class GedcomGeneratorTest
    {
        /// <summary>
        /// This method is used to search the invidual id exists
        /// </summary>
        [Fact]        
        public void WhenSearchIndivualId_Exists()
        {
            string indivualId = "I0001";
            //TODO :  Read the path from config...
            string import_ged = @"E:\GitHub\lookmaan-philips-assignment\Input\Genealogical_data.txt";
            string export_xml = "output.xml";
            string xmlOutput = GEDCOMtoXML.Converter.ConvertXML(import_ged, export_xml, indivualId);
            if (xmlOutput != null && xmlOutput.Contains(indivualId))
            {
                Assert.True(true);
            }            
        }
        /// <summary>
        /// This method is used to search the invidual id does not exists
        /// </summary>
        [Fact]
        public void WhenSearchIndivualId_NotExists()
        {
            string indivualId = "I01";
            string import_ged = @"E:\GitHub\lookmaan-philips-assignment\Input\Genealogical_data.txt";
            string export_xml = "output.xml";
            string xmlOutput = GEDCOMtoXML.Converter.ConvertXML(import_ged, export_xml, indivualId);
            if (xmlOutput != null && !xmlOutput.Contains(indivualId))
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// This method is used to search the family id exists
        /// </summary>
        [Fact]
        public void WhenSearchFamilyId_Exists()
        {
            string familyId = "F0001";
            string import_ged = @"E:\GitHub\lookmaan-philips-assignment\Input\Genealogical_data.txt";
            string export_xml = "output.xml";
            string xmlOutput = GEDCOMtoXML.Converter.ConvertXML(import_ged, export_xml, familyId);
            if (xmlOutput != null && xmlOutput.Contains(familyId))
            {
                Assert.True(true);
            }
        }
        /// <summary>
        /// This method is used to search the family id does not exists
        /// </summary>
        [Fact]
        public void WhenSearchFamilyId_NotExists()
        {
            string familyId = "F01";
            string import_ged = @"E:\GitHub\lookmaan-philips-assignment\Input\Genealogical_data.txt";
            string export_xml = "output.xml";
            string xmlOutput = GEDCOMtoXML.Converter.ConvertXML(import_ged, export_xml, familyId);
            if (xmlOutput != null && !xmlOutput.Contains(familyId))
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// This method is used to search the note id exists
        /// </summary>
        [Fact]
        public void WhenSearchNoteId_Exists()
        {
            string noteId = "N0001";
            string import_ged = @"E:\GitHub\lookmaan-philips-assignment\Input\Genealogical_data.txt";
            string export_xml = "output.xml";
            string xmlOutput = GEDCOMtoXML.Converter.ConvertXML(import_ged, export_xml, noteId);
            if (xmlOutput != null && xmlOutput.Contains(noteId))
            {
                Assert.True(true);
            }
        }
        /// <summary>
        /// This method is used to search the note id does not exists
        /// </summary>
        [Fact]
        public void WhenSearchNoteId_NotExists()
        {
            string noteId = "N01";
            string import_ged = @"E:\GitHub\lookmaan-philips-assignment\Input\Genealogical_data.txt";
            string export_xml = "output.xml";
            string xmlOutput = GEDCOMtoXML.Converter.ConvertXML(import_ged, export_xml, noteId);
            if (xmlOutput != null && !xmlOutput.Contains(noteId))
            {
                Assert.True(false);
            }
        }
        /// <summary>
        /// This method is used to search the source id exists
        /// </summary>
        [Fact]
        public void WhenSearchSourceId_Exists()
        {
            string sourceId = "S0001";
            string import_ged = @"E:\GitHub\lookmaan-philips-assignment\Input\Genealogical_data.txt";
            string export_xml = "output.xml";
            string xmlOutput = GEDCOMtoXML.Converter.ConvertXML(import_ged, export_xml, sourceId);
            if (xmlOutput != null && xmlOutput.Contains(sourceId))
            {
                Assert.True(true);
            }
        }
        /// <summary>
        /// This method is used to search the source id does not exists
        /// </summary>
        [Fact]
        public void WhenearchSourceId_NotExists()
        {
            string sourceId = "S01";
            string import_ged = @"E:\GitHub\lookmaan-philips-assignment\Input\Genealogical_data.txt";
            string export_xml = "output.xml";
            string xmlOutput = GEDCOMtoXML.Converter.ConvertXML(import_ged, export_xml, sourceId);
            if (xmlOutput != null && !xmlOutput.Contains(sourceId))
            {
                Assert.True(false);
            }
        }
    }
}
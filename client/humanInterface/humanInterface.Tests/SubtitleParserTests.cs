using businessLogic;
using dataEntities;
using indexing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theParser;

namespace humanInterface.Tests
{
    //[TestClass]
    //public class SubtitleParserTests
    //{
    //    [TestMethod]
    //    public void ParseItTest()
    //    {
    //        //Title t = new Title();
    //        //t.TitleName = "The Big Lebowski";
    //        //t.Id = 40;
    //        //t.SubtitleText = File.ReadAllText(@"C:\Users\khabilep\Downloads\the-insider_english-61226\The.Insider.1999.WS.DVDRip.XviD.AC3-C00LdUdE.srt");
            
    //        //List<IndexableEntity> indexableItems = SubtitleParser.ParseIt(t, null);
    //        //int i = 1;
    //        //foreach (IndexableEntity e in indexableItems)
    //        //{
    //        //    e.Id = i;
    //        //    i++;
    //        //}
    //        //System.Data.SqlTypes.SqlXml
    //        //IndexMiner.AddUpdateLuceneIndex(indexableItems);
    //        //IndexMiner.Optimize();
    //    }

    //    [TestMethod]
    //    public void SearchIndexTest()
    //    {
    //        IEnumerable<IndexableEntity> searchResult = IndexMiner.SearchDefault("brain");
    //    }

    //    [TestMethod]
    //    public void ClearLuceneIndexTest()
    //    {
    //        IndexMiner.ClearLuceneIndex();
    //    }

    //    [TestMethod]
    //    public void SolrIndexingTest()
    //    {
    //        //string[] allLines = File.ReadAllLines(@"C:\Personal\Projects\Source\Client\humanInterface\humanInterface.Tests\bin\Debug\Fargo - 1996 m-HD x264.srt");
    //        //SubtitleParser parser = new SubtitleParser();
    //        //List<IndexableEntity> indexableItems = parser.ParseIt(allLines, "Fargo");
    //        //var o = new { id="12", title="fargo", text=@"Way out west there was this fella... fella I wanna tell ya about. Fella by the name of Jeff Lebowski. At least that was the handle his loving parents gave him, but he never had much use for it himself. Mr. Lebowski, he called himself ""The Dude"". Now, ""Dude"" - that's a name no one would self-apply where I come from. But then there was a lot about the Dude that didn't make a whole lot of sense. And a lot about where he lived, likewise. But then again, maybe that's why I found the place so darned interestin'. They call Los Angeles the ""City Of Angels."" I didn't find it to be that, exactly. But I'll allow there are some nice folks there. 'Course I can't say I've seen London, and I ain't never been to France. And I ain't never seen no queen in her damned undies, so the feller says. But I'll tell you what - after seeing Los Angeles, and this here story I'm about to unfold, well, I guess I seen somethin' every bit as stupefyin' as you'd see in any of them other places. And in English, too. So I can die with a smile on my face, without feelin' like the good Lord gypped me. Now this here story I'm about to unfold took place back in the early '90s - just about the time of our conflict with Sad'm and the I-raqis. I only mention it because sometimes there's a man... I won't say a hero, 'cause, what's a hero? But sometimes, there's a man. And I'm talkin' about the Dude here. Sometimes, there's a man, well, he's the man for his time and place. He fits right in there. And that's the Dude, in Los Angeles. And even if he's a lazy man - and the Dude was most certainly that. Quite possibly the laziest in Los Angeles County, which would place him high in the runnin' for laziest worldwide. But sometimes there's a man, sometimes, there's a man. Aw. I lost my train of thought here. But... aw, hell. I've done introduced him enough."  };
    //        //string json = JsonConvert.SerializeObject(o); //JsonConvert.SerializeObject(indexableItems);
                     
    //        //RestSharp.RestClient client = new RestSharp.RestClient("http://localhost/solr/update");
    //        //RestSharp.RestRequest request = new RestSharp.RestRequest(Method.POST);
    //        //request.Resource = "json";

    //        //request.AddHeader("content-type", "application/json");
    //        //request.AddHeader("Content-Length", int.MaxValue.ToString());
    //        //request.AddBody(json);
    //        //var restResponse = client.Execute(request);

    //    }

    //    [TestMethod]
    //    public void QuerySolrIndexingTest()
    //    {            
    //        RestSharp.RestClient client = new RestSharp.RestClient("http://localhost/solr/");
    //        RestSharp.RestRequest request = new RestSharp.RestRequest(Method.GET);
    //        request.Resource = "select";

    //        //request.AddHeader("content-type", "application/json");
    //        //request.AddHeader("Content-Length", int.MaxValue.ToString());
    //        request.AddParameter("fq", "funny");
    //        request.AddParameter("wt", "json");
    //        var restResponse = client.Execute(request);
    //    }


    //    [TestMethod]
    //    public void ParseAndReIndexAllTest()
    //    {
    //        BusinessLogic bl = new BusinessLogic();
    //        bl.ParseAndReIndexAll();
    //    }
    //}


}

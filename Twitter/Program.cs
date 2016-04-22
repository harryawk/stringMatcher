using System;
using System.Collections;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using TwitterSample.OAuth;
using System.Threading.Tasks;

namespace Tuittuit
{
    /// <summary>
    /// Sample illustrating how to write a simple twitter client using HttpClient. The sample uses a 
    /// HttpMessageHandler to insert the appropriate OAuth authentication information into the outgoing
    /// HttpRequestMessage. The result from twitter is read as a JToken.
    /// </summary>
    /// <remarks>
    /// Before you can run this sample you must obtain an application key from twitter, and 
    /// fill in the information in the OAuthMessageHandler class, see 
    /// http://dev.twitter.com/ for details.
    /// </remarks>
    class Program
    {
		//===========================================================member====================================
		private ArrayList dinasPemakaman  = new ArrayList();
		private ArrayList dinasPendidikan = new ArrayList();
		private ArrayList dinasBinaMarga  = new ArrayList();
		private ArrayList dinasKebersihan = new ArrayList();
		private ArrayList dinasPerubungan = new ArrayList();
		private ArrayList lainnya         = new ArrayList();
		public static string b = "%40twitterapi";
		private static string _address = "https://api.twitter.com/1.1/search/tweets.json?q="+b+"&count=100";

		//===========================================================API=======================================
		private static async Task<JToken> RunClient()
        {
            // Create client and insert an OAuth message handler in the message path that 
            // inserts an OAuth authentication header in the request
            HttpClient client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler()));

            // Send asynchronous request to twitter and read the response as JToken
            HttpResponseMessage response = await client.GetAsync(_address);
			JToken statuses = null;
           // if (response.IsSuccessStatusCode)
           // {
                statuses = await response.Content.ReadAsAsync<JToken>();
               	/*
				Console.WriteLine("Most recent statuses from ScottGu's twitter account:");
                Console.WriteLine();
                foreach (var status in statuses)
                {
                    Console.WriteLine("   {0}", status["text"]);
                    Console.WriteLine();
                }
                */
           // }
			return statuses;
        }

		//===========================================================helper====================================
		public int[] makeKeywordsIndex(string[] Pemakaman, string[] Pendidikan, string[] BinaMarga, string[] Kebersihan, string[] Perubungan)
		{
			int[] n = new int[Pemakaman.Length + Pendidikan.Length + BinaMarga.Length + Kebersihan.Length + Perubungan.Length];
			int i = 0;

			foreach (String temp in Pemakaman) 
			{
				n [i] = 0;
				i++;
			}

			foreach (String temp in Pendidikan) 
			{
				n [i] = 1;
				i++;
			}

			foreach (String temp in BinaMarga) 
			{
				n [i] = 2;
				i++;
			}

			foreach (String temp in Kebersihan) 
			{
				n [i] = 3;
				i++;
			}

			foreach (String temp in Perubungan) 
			{
				n [i] = 4;
				i++;
			}

			return n;
		}

		public String[] makeKeywords(string[] Pemakaman, string[] Pendidikan, string[] BinaMarga, string[] Kebersihan, string[] Perubungan)
		{
			String[] n = new String[Pemakaman.Length + Pendidikan.Length + BinaMarga.Length + Kebersihan.Length + Perubungan.Length];
			int i = 0;

			foreach (String temp in Pemakaman) 
			{
				n [i] = temp;
				i++;
			}

			foreach (String temp in Pendidikan) 
			{
				n [i] = temp;
				i++;
			}

			foreach (String temp in BinaMarga) 
			{
				n [i] = temp;
				i++;
			}

			foreach (String temp in Kebersihan) 
			{
				n [i] = temp;
				i++;
			}

			foreach (String temp in Perubungan) 
			{
				n [i] = temp;
				i++;
			}

			return n;
		}

		public void addToCategory(int n, String s)
		{
			if (n == 0) {
				dinasPemakaman.Add (s);
			} else if (n == 1) {
				dinasPendidikan.Add (s);
			} else if (n == 2) {
				dinasBinaMarga.Add (s);
			} else if (n == 3) {
				dinasKebersihan.Add (s);
			} else if (n == 4) {
				dinasPerubungan.Add (s);
			} else {
				lainnya.Add (s);
			}
		}

		public void PrintValues( IEnumerable myList )  {
			foreach (Object obj in myList) {
				Console.WriteLine ("   {0}", obj);
				Console.WriteLine ("==================================");
			}
		}

		public void printTweet()
		{
			Console.WriteLine ("Pemakaman");
			Console.WriteLine( "    Count:    {0}", dinasPemakaman.Count );
			Console.WriteLine( "    Values:" );
			PrintValues(dinasPemakaman);

			Console.WriteLine ("Pendidikan");
			Console.WriteLine( "    Count:    {0}", dinasPendidikan.Count );
			Console.WriteLine( "    Values:" );
			PrintValues(dinasPendidikan);

			Console.WriteLine ("BinaMarga");
			Console.WriteLine( "    Count:    {0}", dinasBinaMarga.Count );
			Console.WriteLine( "    Values:" );
			PrintValues(dinasBinaMarga);

			Console.WriteLine ("Kebersihan");
			Console.WriteLine( "    Count:    {0}", dinasKebersihan.Count );
			Console.WriteLine( "    Values:" );
			PrintValues(dinasKebersihan);

			Console.WriteLine ("Pemakaman");
			Console.WriteLine( "    Count:    {0}", dinasPerubungan.Count );
			Console.WriteLine( "    Values:" );
			PrintValues(dinasPerubungan);

			Console.WriteLine ("lainnya");
			Console.WriteLine( "    Count:    {0}", lainnya.Count );
			Console.WriteLine( "    Values:" );
			PrintValues(lainnya);
		}

		//===========================================================fungsi-Utama================================
		public void tuitTuit()
        {
			//kmpMatching mesin = new kmpMatching ("wawa");
			kmpMatching mesin = new kmpMatching ("wawa");
			int category = 0;
			JToken feed = null;
			int[] n = makeKeywordsIndex (new String[]{"twitter"}, new String[]{"prince"}, new String[]{}, new String[]{}, new String[]{});
			String[] keywords = makeKeywords (new String[]{"twitter"}, new String[]{"prince"}, new String[]{}, new String[]{}, new String[]{});
			feed = RunClient().Result;


			foreach (JToken status in feed["statuses"])
			{
				category = mesin.search ("" + status ["text"], keywords);
				addToCategory (category, status ["text"].ToString());
			}
        }

		public static void Main(String[] args)
		{
			Program p = new Program ();
			p.tuitTuit ();
			p.printTweet ();
		}
    }
}


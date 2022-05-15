using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Game_Relased_On_Birthday
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string day = dateTimePicker1.Value.Day.ToString();
            string month = dateTimePicker1.Value.Month.ToString();
            string year = dateTimePicker1.Value.Year.ToString();
            Task task = CallToWebAsync(day, month, year);
        }
        private async Task<string> CallToWebAsync(string da, string mo, string ye)
        {

            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.giantbomb.com/api/games/?api_key=[API_KEY]&filter=original_release_date:"+ye+'-'+mo+'-'+da+"&sort=original_release_date&field_list=name");

            var productValue = new ProductInfoHeaderValue("GitHubProject", "1.0");
            var commentValue = new ProductInfoHeaderValue("(+https://github.com/Jonapop/Birthday-Game-Release)");

            request.Headers.UserAgent.Add(productValue);
            request.Headers.UserAgent.Add(commentValue);

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(request);
            var resp = httpResponseMessage;
            richTextBox2.AppendText(await resp.Content.ReadAsStringAsync());
            return await resp.Content.ReadAsStringAsync();

        }
    }
}

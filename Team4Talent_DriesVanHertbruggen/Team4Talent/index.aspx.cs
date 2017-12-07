using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;

namespace Team4Talent
{
    public partial class index : System.Web.UI.Page
    {
        food foodItem = new food();

        protected void order_click(object sender, EventArgs e)

        {
            if (txtEmail.Text != "" && txtEmail.Text.Length != 0 && txtName.Text != "" && txtName.Text.Length != 0 && txtEmail.Text.Contains("@") && txtEmail.Text.Contains("."))
            {
                string strorder = hiddeninput.Value;
                System.Diagnostics.Debug.WriteLine(strorder);       //debug code

                string strtmp = strorder;
                string[] strfood = strorder.Split('%');
                for (int i = 0; i <= strfood.Rank; i++)             //debug code
                {
                    System.Diagnostics.Debug.WriteLine(strfood[i]);
                }

                string[,] tstrorders = new string[strfood.Rank + 1, 4];


                string removefood = "";
                for (int i = 0; i <= strfood.Rank; i++)
                {
                    int foodcount = strfood[i].Count(f => f == '|');
                    removefood = strfood[i];
                    System.Diagnostics.Debug.WriteLine("foodcount" + foodcount);       //debug code

                    string test1 = removefood.Substring(0, removefood.IndexOf("|"));
                    removefood = removefood.Substring(removefood.IndexOf("|") + 1, removefood.Length - (removefood.IndexOf("|") + 1));
                    string test2 = removefood.Substring(0, removefood.IndexOf("|"));
                    removefood = removefood.Substring(removefood.IndexOf("|") + 1, removefood.Length - (removefood.IndexOf("|") + 1));
                    string test3 = removefood.Substring(0, removefood.IndexOf("|"));
                    removefood = removefood.Substring(removefood.IndexOf("|") + 1, removefood.Length - (removefood.IndexOf("|") + 1));
                    string test4 = removefood;

                    System.Diagnostics.Debug.WriteLine(test1 + " " + test2 + " " + test3 + " " + test4);

                    tstrorders[i, 0] = test1;
                    tstrorders[i, 1] = test2;
                    tstrorders[i, 2] = test3;
                    tstrorders[i, 3] = test4;
                }

                string tmporder = "dummy data";

                StringBuilder html = new StringBuilder();
                html.Append("<table border = '1'>");

                //Building the Header row.
                html.Append("<tr>");

                html.Append("<th></th>");
                html.Append("<th>Naam</th>");
                html.Append("<th>Aantal</th>");
                html.Append("<th>Prijs</th>");
                html.Append("<th>Totaal</th>");

                html.Append("</tr>");

                html.Append("<tr>");
                for (int i = 0; i <= strfood.Rank; i++)
                {
                    html.Append("<td>");
                    html.Append(i);
                    html.Append("</td>");
                    for (int j = 0; j < 4; j++)
                    {
                        html.Append("<td>");
                        html.Append(tstrorders[i, j]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }

                html.Append("</table>");
                html.Append("</ br></ br>");

                tmporder = html.ToString();

                double dbltotaal = 0;
                for (int i = 0; i <= strfood.Rank; i++)
                {
                    dbltotaal += Convert.ToDouble(tstrorders[i, 3]);
                }

                tmporder = tmporder + "Het totale bedrag is : €" + dbltotaal.ToString("#.00");

                email temail = new email();
                temail.SendMessage(txtEmail.Text, txtName.Text, tmporder);

                //parseOrder(dbltotaal, tstrorders[,]);
                
            }
        }

        /*
        Begin SQL opslag 


        [WebMethod]
        public void Insert(double total, int smoskaas, int smoshesp, int smoskaashesp)
        {
            {
                SqlConnection conn = new SqlConnection(@"Data Source=den1.mssql1.gear.host;Integrated Security=True");
                SqlCommand insert = new SqlCommand("insert into dbo.orders(Total, Email, SmosKaas, SmosHesp, SmosKaasHesp) values(@total, @email, @smoskaas,@smoshesp, @smoskaashesp)", conn);
                insert.Parameters.AddWithValue("@total", total);
                insert.Parameters.AddWithValue("@email", txtEmail.Text);
                insert.Parameters.AddWithValue("@smoskaas", smoskaas);
                insert.Parameters.AddWithValue("@smoshesp", smoshesp);
                insert.Parameters.AddWithValue("@smoskaashesp", smoskaashesp);
                try
                {
                    conn.Open();
                    insert.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("error: " + ex.Message);
                    conn.Close();
                }
            }
        }

        private void parseOrder(double tmpTotaal, string[,] orderlist)
        {

        }
        */
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Studentdetails
{
    public partial class Stdent_details : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
         public void getcon()
        {
            con.ConnectionString = @" Data Source=LAPTOP-4H9G3A49\SQLEXPRESS;Initial Catalog=nivea;Integrated Security=True";
            con.Open();
        }

         protected void btnadd_Click(object sender, EventArgs e)
         {
             getcon();
             String query = "insert into student_details values('" + txtname.Text + "','" + txtage.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + txtdob.Text + "','" + DropDownList1.SelectedItem.Text + "','" + txtrno.Text + "','" + txtphno.Text + "','" + txtadd.Text + "')";
             cmd = new SqlCommand(query, con);
             Response.Write("<script>alert('Data Added Successfully! :-)')</script>");
            cmd.ExecuteNonQuery();

            txtadd.Text = "";
            txtage.Text = "";
            txtdob.Text = "";
            txtname.Text = "";
            txtphno.Text = "";
            txtrno.Text = "";

         }

         protected void btndelete_Click(object sender, EventArgs e)
         {
             getcon();

             String delete = ("delete from student_details where name=('" + txtname.Text + "' )");
             cmd = new SqlCommand(delete, con);
             Response.Write("<script>alert('Data Deleted Successfully! :-)')</script>");
             cmd.ExecuteNonQuery();

         }

         protected void btnmodify_Click(object sender, EventArgs e)
         {
             getcon();

             String update = "update Student_details set  Age='" + txtage.Text + "',Gender='"+RadioButtonList1.SelectedItem.Text+"',DOB='"+txtdob.Text+"',Course='"+DropDownList1.SelectedItem.Text+"',Roll_no='"+txtrno+"',Phone='"+txtphno.Text+"',Address='"+txtadd+"' where Name='" + txtname.Text + "'";
             SqlCommand cmd = new SqlCommand(update, con);
             Response.Write("<script>alert('Data Modified Successfully! :-)')</script>");
             cmd.ExecuteNonQuery();

             
         }

         protected void btnlist_Click(object sender, EventArgs e)
         {
             getcon();

             String sel = "select age,gender,dob,course,roll_no,phone,address from student_details where name='" + txtname.Text + "'";
             SqlCommand cmd = new SqlCommand(sel, con);
             SqlDataAdapter sd = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             sd.Fill(dt);
             if (dt.Rows.Count > 0)
             {
                 txtage.Text = dt.Rows[0][0].ToString();
                 RadioButtonList1.Text= dt.Rows[0][1].ToString();
                 txtdob.Text = dt.Rows[0][2].ToString();
                 DropDownList1.Text = dt.Rows[0][3].ToString();
                 txtrno.Text = dt.Rows[0][4].ToString();
                 txtphno.Text = dt.Rows[0][5].ToString();
                 txtadd.Text = dt.Rows[0][6].ToString();

             }
             else
             {
                 Response.Write("<script>alert('Invalid Name! :-)')</script>");

             }           

         }
    }
}
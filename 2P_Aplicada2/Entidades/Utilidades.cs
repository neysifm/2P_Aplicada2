using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2P_Aplicada2.Entidades
{
    public static class Utilidades
    {
        public static Int32 ToInt(this String value)
        {
            int.TryParse(value, out int retorno);

            return retorno;
        }

        public static decimal ToDecimal(this string valor)
        {
            decimal.TryParse(valor, out decimal retorno);

            return retorno;
        }
        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        public static void CallJsFunction(Page page, Type type, string functionName)
        {
            page.ClientScript.RegisterStartupScript(type, "CallMyFunction", functionName, true);
        }

        public static DateTime ToDatetime(this object obj)
        {
            DateTime.TryParse(obj.ToString(), out DateTime value);
            return value;
        }
        static readonly string FECHA_FORMAT = "yyyy-MM-dd";

        public static string ToFormatDate(this DateTime dateTime)
        {
            return dateTime.ToString(FECHA_FORMAT);
        }

        public static void ClearControls(Control control, List<Type> controlsToClear)
        {
            foreach (Control c in control.Controls)
            {
                if (controlsToClear.Contains(c.GetType()))
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        ((TextBox)c).Text = string.Empty;
                    }

                    if (c.GetType() == typeof(DropDownList))
                    {
                        ((DropDownList)c).SelectedIndex = 0;
                    }
                }
            }
        }

        public static void FillGrid<T>(GridView gv, List<T> lista)
        {
            gv.DataSource = null;
            gv.DataBind();
            gv.DataSource = lista;
            gv.DataBind();
        }

        public static string Hash(string input) { var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray()); }
    }
}
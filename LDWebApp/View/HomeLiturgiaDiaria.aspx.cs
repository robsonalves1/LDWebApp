using LDWebApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LDWebApp.View
{
    public partial class HomeLiturgiaDiaria : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DivFirstLecture.Visible = true;
                DivSecondLecture.Visible = false;
                DivPsalm.Visible = false;
                DivGospel.Visible = false;
                await GetLectures("https://liturgia.up.railway.app/");
            }
        }

        protected async Task GetLectures(string URI)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string LeiturasJsonString = await response.Content.ReadAsStringAsync();
                        LeiturasJsonString = "[" + LeiturasJsonString + "]";
                        List<JsonApiLiturgia> jsonApiAnswerLiturgia = JsonConvert.DeserializeObject<List<JsonApiLiturgia>>(LeiturasJsonString);
                        LoadLectures(jsonApiAnswerLiturgia);
                    }
                }
            }
        }

        protected void LoadLectures(List<JsonApiLiturgia> jsonApiAnswerLiturgia)
        {
            LinkHomeLiturgy.InnerHtml = "Liturgia Diária - ";

            // FIX THE DATE INSERTING 0 BEFORE NUMBERS LOWER THAN 10
            string dateString = jsonApiAnswerLiturgia[0].Date;
            string[] dateSplitted = dateString.Split('/');
            string newDateString = "";
            if (Convert.ToDouble(dateSplitted[0]) < 10) {
                newDateString = "0" + dateSplitted[0];
            }
            newDateString += "/" + dateSplitted[1] + "/" + dateSplitted[2];

            LinkHomeLiturgy.InnerHtml = "Liturgia Diária - " + newDateString;

            DivTitle.InnerHtml = "<p><strong>" + jsonApiAnswerLiturgia[0].Offers + "</strong></p>";

            string color = jsonApiAnswerLiturgia[0].Color;
            LoadLiturgyColors(color);

            DivFirstLecture.InnerHtml =
                "<h2>" + jsonApiAnswerLiturgia[0].FirstLecture.Title + "(" + jsonApiAnswerLiturgia[0].FirstLecture.Reference + ")" + "</h2>";

            string firstLectureText = jsonApiAnswerLiturgia[0].FirstLecture.Text;
            string firstLectureLectureInsertTagBrBeforeNumbers = InsertTagBrBeforeNumbers(firstLectureText);

            DivFirstLecture.InnerHtml +=
                "<p class=\"fs-5\">" + firstLectureLectureInsertTagBrBeforeNumbers + "</p>";

            if (jsonApiAnswerLiturgia[0].SegundaLeitura != null)
            {
                DivSecondLecture.InnerHtml =
                    "<h2>" + jsonApiAnswerLiturgia[0].SegundaLeitura.Title + "(" + jsonApiAnswerLiturgia[0].SegundaLeitura.Reference + ")" + "</h2>";

                string secondLectureText = jsonApiAnswerLiturgia[0].SegundaLeitura.Text;
                string secondLectureInsertTagBrBeforeNumbers = InsertTagBrBeforeNumbers(secondLectureText);

                DivSecondLecture.InnerHtml +=
                    "<p class=\"fs-5\">" + secondLectureInsertTagBrBeforeNumbers + "</p>";
            }
            else
            {
                DivSecondLecture.InnerHtml = "<p class=\"fs-5\">" + jsonApiAnswerLiturgia[0].segundaLeitura + "</p>";
            }

            DivPsalm.InnerHtml =
                "<h2>" + jsonApiAnswerLiturgia[0].Psalm.Reference + "</h2>" +
                "<p><strong>Refrão: " + jsonApiAnswerLiturgia[0].Psalm.Chorus + "</strong></p>";

            string psalmText = jsonApiAnswerLiturgia[0].Psalm.Text;
            string psalmInsertTagBrBeforeNumbers = InsertTagBrBeforeUnderscore(psalmText);

            DivPsalm.InnerHtml +=
                "<p class=\"fs-5\">" + psalmInsertTagBrBeforeNumbers + "</p>";

            DivGospel.InnerHtml =
                "<h2>" + jsonApiAnswerLiturgia[0].Gospel.Title + "(" + jsonApiAnswerLiturgia[0].Gospel.Reference + ")" + "</h2>";

            string gospelText = jsonApiAnswerLiturgia[0].Gospel.Text;
            string gospelInsertTagBrBeforeNumbers = InsertTagBrBeforeNumbers(gospelText);
            
            DivGospel.InnerHtml +=
                "<p class=\"fs-5\">" + gospelInsertTagBrBeforeNumbers + "</p>";
        }

        protected void LoadLiturgyColors (string color)
        {
            switch (color)
            {
                case "Branco":
                    NavLiturgy.Attributes["style"] = "background-color: whitesmoke";
                    break;
                case "Roxo":
                    NavLiturgy.Attributes["style"] = "background-color: purple";
                    NavLiturgy.Attributes["data-bs-theme"] = "dark";
                    break;
                case "Rosa":
                    NavLiturgy.Attributes["style"] = "background-color: pink";
                    NavLiturgy.Attributes["data-bs-theme"] = "dark";
                    break;
                case "Preto":
                    NavLiturgy.Attributes["style"] = "background-color: black";
                    NavLiturgy.Attributes["data-bs-theme"] = "dark";
                    break;
                case "Verde":
                    NavLiturgy.Attributes["style"] = "background-color: green";
                    NavLiturgy.Attributes["data-bs-theme"] = "dark";
                    break;
                case "Vermelho":
                    NavLiturgy.Attributes["style"] = "background-color: red";
                    NavLiturgy.Attributes["data-bs-theme"] = "dark";
                    break;
            }
        }

        protected void SelectLecture_Click(object sender, EventArgs e)
        {
            HtmlButton btn = sender as HtmlButton;
            string btnValue = btn.InnerText;

            DivFirstLecture.Visible = false;
            DivSecondLecture.Visible = false;
            DivPsalm.Visible = false;
            DivGospel.Visible = false;

            if (btnValue == "1º Leitura")
                DivFirstLecture.Visible = true;
            else if (btnValue == "2º Leitura")
                DivSecondLecture.Visible = true;
            else if (btnValue == "Salmo")
                DivPsalm.Visible = true;
            else
                DivGospel.Visible = true;
        }

        protected string InsertTagBrBeforeNumbers(string text)
        {
            string textInsertTagBrBeforeNumbers = Regex.Replace(text, @"\s(?=\d)", "<br>");
            return textInsertTagBrBeforeNumbers;
        }

        protected string InsertTagBrBeforeUnderscore(string text)
        {
            string textInsertTagBrBeforeUnderscore = text.Replace("—", "<br>-");
            return textInsertTagBrBeforeUnderscore;
        }
    }
}
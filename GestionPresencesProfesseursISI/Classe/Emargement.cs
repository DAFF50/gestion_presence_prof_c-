using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace GestionPresencesProfesseursISI
{
    internal class Emargement
    {
        public Emargement()
        {
        }
        public int Id {  get; set; }
        public DateTime date { get; set; }
        public string statut { get; set; }
        public int IdProfesseur { get; set; }
        public int IdCours { get; set; }
        public Users Users { get; set; }
        public Cours Cours { get; set; }

        public static void ExportToExcel(List<Emargement> emargements, string filePath)
        {

            using (var package = new ExcelPackage())
            {
                
                var worksheet = package.Workbook.Worksheets.Add("Emargements");

                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Status";
                worksheet.Cells[1, 3].Value = "Date";
                worksheet.Cells[1, 4].Value = "Professeur";
                worksheet.Cells[1, 5].Value = "Cours";

                for (int i = 0; i < emargements.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = emargements[i].Id;
                    worksheet.Cells[i + 2, 2].Value = emargements[i].statut;
                    worksheet.Cells[i + 2, 3].Value = emargements[i].date.ToShortDateString();
                    worksheet.Cells[i + 2, 4].Value = emargements[i].Users.FullName.ToString();
                    worksheet.Cells[i + 2, 5].Value = emargements[i].Cours.Nom.ToString();
                }

                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }

        public static void ExportToPDF(List<Emargement> emargements, string filePath)
        {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont font = new XFont("Arial", 12);

                double x = 50; 
                double y = 50; 
                double lineHeight = 20; 

                gfx.DrawString("Liste des Émargements des professeurs de ISI", font, XBrushes.Black, x, y);
                y += lineHeight * 2; // Espace après le titre

                gfx.DrawString("ID", font, XBrushes.Black, x, y);
                gfx.DrawString("Statut", font, XBrushes.Black, x + 50, y);
                gfx.DrawString("Date", font, XBrushes.Black, x + 150, y);
                gfx.DrawString("Professeur", font, XBrushes.Black, x + 250, y);
                gfx.DrawString("Cours", font, XBrushes.Black, x + 400, y);
                y += lineHeight;

                foreach (var emargement in emargements)
                {
                    gfx.DrawString(emargement.Id.ToString(), font, XBrushes.Black, x, y);
                    gfx.DrawString(emargement.statut ?? "N/A", font, XBrushes.Black, x + 50, y);
                    gfx.DrawString(emargement.date.ToShortDateString(), font, XBrushes.Black, x + 150, y);
                    gfx.DrawString(emargement.Users?.FullName ?? "N/A", font, XBrushes.Black, x + 250, y);
                    gfx.DrawString(emargement.Cours?.Nom ?? "N/A", font, XBrushes.Black, x + 400, y);
                    y += lineHeight;

                    // Créer une nouvelle page si nécessaire
                    if (y > page.Height - 50)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        y = 50; // Réinitialiser la position Y
                    }
                }
                document.Save(filePath);
        }

       
    }
}
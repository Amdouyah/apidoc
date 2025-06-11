using System.ComponentModel;
using System.Diagnostics;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QPdfContainer = QuestPDF.Infrastructure.IContainer;

namespace Attestation;



//  public class AttestationCase
// {
//     public string? Annee { get; set; }
//     public string? DuVente { get; set; }
//     public string? DateAu { get; set; }
//     public string? Agence { get; set; }
//     public List<AttestationInfo>? Infos { get; set; }

// }

// public class administrationInfo
// {
//     public string? N_attestatation { get; set; }
//     public string? Immatriculation { get; set; }
//     public string? Nom { get; set; }
//     public string? Prenom { get; set; }
//     public string? Matricule { get; set; }
//     public string? Marque_Vehicule { get; set; }
//     public string? Date_Debut { get; set; }
//     public string? Date_Fin { get; set; }
//     public string? Montant_Total { get; set; }
// }


public class AttestationRemises : IDocument
{
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public void Compose(IDocumentContainer container)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        container.Page(page =>
        {
            page.Header().PaddingLeft(12).PaddingRight(12).MinHeight(60).AlignCenter().Element(BuildHeader);
            page.Content().Column(col =>
            {
                // col.Spacing(7);
                // foreach (var attCase in ListOfCases)
                // {
                col.Item().PaddingLeft(15).PaddingTop(10).Column(col =>
                {
                    col.Item().Column(col =>
                     {
                         col.Spacing(1);
                         col.Item().AlignLeft().PaddingLeft(15).Text(x =>
                         {
                             x.Span("Exercice  :  ").FontSize(8).FontFamily("Courie New").ExtraBold();
                             x.Span("2025").FontSize(8).FontFamily("Courie New").ExtraBold();

                         });
                         col.Item().AlignLeft().PaddingLeft(15).Text(x =>
                         {
                             x.Span("Agnece  :  ").FontSize(8).FontFamily("Courie New").ExtraBold();
                             x.Span("904").FontSize(7).FontFamily("Courie New").ExtraBold();
                             x.Span("        SNTL").FontSize(9).FontFamily("Courie New").ExtraBold();

                         });
                     });
                });

                col.Item().PaddingLeft(15).PaddingRight(12).PaddingTop(2).Border(1).BorderColor(Colors.Black).Table(table =>
                {
                    table.ColumnsDefinition(table =>
                    {
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(2);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                    });

                    table.Cell().Border(1).Padding(3).Text("N° Attentation").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Immatriculation").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Nom et Prénom").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Matricule").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("marque Véhicule").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Date Début").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Date Fin").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Montant Total").FontSize(7).ExtraBold().AlignCenter();

                    // cell content
                    table.Cell().BorderTop(1).BorderLeft(1).BorderRight(1).Padding(3).Text("3124942").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("1954 - H / 1").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("HASSAN HASSAN").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("FORD FIESTA").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("01/01/01").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("01/01/01").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderBottom(1).BorderLeft(1).BorderRight(1).Padding(3).Text("3 400,00").FontSize(6).AlignCenter().ExtraBold();

                });

                col.Item().PaddingLeft(15).PaddingRight(12).Border(1).Padding(3).BorderColor(Colors.Black).Row(row =>
                {
                    row.RelativeItem().AlignLeft().Text(text =>
                    {
                        text.Span("Total :   ").FontSize(8).ExtraBold();
                        text.Span("3").FontSize(8).ExtraBold();
                        text.Span("     Attestations").FontSize(8).ExtraBold();
                    });

                    row.ConstantItem(100).AlignRight().Text(text =>
                    {
                        text.Span("11 452,00").FontSize(8).ExtraBold();
                        text.Span(" Dhs").FontSize(8).ExtraBold();
                    });
                });
                // foreach (var case1 in listOfcases)
                // {
                //     //start workin on my table here 
                // }
                // }
            });
        });

        void BuildHeader(QPdfContainer cont)
        {
            cont.Column(col =>
            {
                col.Spacing(1);
                col.Item().Row(row =>
                {
                    row.RelativeItem(1).PaddingTop(8).PaddingLeft(5).Border(1).BorderColor(Colors.Black).AlignCenter().Padding(5).Image("/Users/amine/OneDrive/Desktop/testApi/depends/images/sntl.webp").FitWidth();
                    row.RelativeItem(2).PaddingTop(8).Border(1).BorderColor(Colors.Black).PaddingTop(5).Padding(9).Text("ATTESTATION REMISES AUX AGENCES").FontSize(12).FontFamily("Times New Roman").ExtraBold().AlignCenter();
                    row.RelativeItem(1).PaddingTop(8).PaddingRight(5).Border(1).BorderColor(Colors.Black).Column(col =>
                    {
                        col.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(4).Text("").FontSize(5);
                        col.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(4).Text("Version 4").FontSize(6).ExtraBold().AlignLeft();
                        col.Item().Padding(5).AlignLeft().Text(txt =>
                        {
                            txt.Span("Page : ").FontSize(6).ExtraBold();
                            txt.CurrentPageNumber().FontSize(6).ExtraBold();
                            txt.Span(" / ").FontSize(6).ExtraBold();
                            txt.TotalPages().FontSize(6).ExtraBold();
                        });
                    });
                });
                col.Item().Row(row =>
                {
                    row.RelativeItem(1)
                        .PaddingTop(2)
                        .PaddingLeft(20)
                        .Text("ASS_FONCT46V1")
                        .ExtraBold()
                        .FontSize(7)
                        .AlignLeft();

                    row.RelativeItem(1).PaddingTop(2).PaddingRight(20).AlignRight().Text(text =>
                    {
                        text.Span("Rabat Le : ").FontSize(7).ExtraBold();
                        text.Span("03/04/2025").FontSize(7).ExtraBold();
                    });
                });

            });
        }
    }
}
using System.ComponentModel;
using System.Diagnostics;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QPdfContainer = QuestPDF.Infrastructure.IContainer;

namespace Attestation;

// public class Caisses {
//     public int? id { get; set; }
//     public string? Agence { get; set; }
//     public List<AttestationInfo>? Infos { get; set; }
// }

//  public class AttestationCase
// {
//     public string? DuVente { get; set; }
//     public string? administration { get; set; }
//     public List<Caisses> Caisse { get; set; }
//     public string? Type_Credit { get; set; }

// }

// public class administrationInfo
// {
//     public string? Agence { get; set; }
//     public string? Code { get; set; }
//     public string? DateDeVente { get; set; }
//     public string? Numero { get; set; }
//     public string? Immatriculation { get; set; }

//     public string? N_Repertoire { get; set; }
//     public string? Montant { get; set; }
//     public string? NomDeLassure { get; set; }
// }


public class ParAdministration : IDocument
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
                col.Spacing(7);
                // foreach (var attCase in ListOfCases)
                // {
                col.Item().PaddingLeft(15).PaddingTop(10).Column(col =>
                {
                    col.Item().Row(row =>
                {
                    row.Spacing(5);
                    row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                    {
                        column.Item().Text(x =>
                        {
                            x.Span("Exercice  :  ").FontSize(7).FontFamily("Courie New").ExtraBold();
                            x.Span("2025").FontSize(7).FontFamily("Courie New").ExtraBold();
                        });
                    });
                    row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                    {
                        column.Item().Text(x =>
                        {
                            x.Span("Administration  :  ").FontSize(7).FontFamily("Courie New").ExtraBold();
                            x.Span("122      BARID CASH").FontSize(7).FontFamily("Courie New").ExtraBold();
                        });
                    });
                    row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                    {
                        column.Item().Text(x =>
                        {
                            x.Span("Date début  :  ").FontFamily("Courie New").FontSize(7).ExtraBold();
                            x.Span("01/01/01").FontSize(7).FontFamily("Courie New").ExtraBold();
                        });
                    });
                    row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                    {
                        column.Item().Text(x =>
                        {
                            x.Span("Date fin  :  ").FontFamily("Courie New").FontSize(7).ExtraBold();
                            x.Span("01/01/01").FontSize(7).FontFamily("Courie New").ExtraBold();
                        });
                    });

                });
                });

                col.Item().PaddingLeft(15).PaddingRight(12).PaddingTop(5).Border(1).BorderColor(Colors.Black).Table(table =>
                {
                    table.ColumnsDefinition(table =>
                    {
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(2);
                    });
                    table.Cell().Border(1).Padding(3).Text("Agence").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Code").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Date\n de Vente").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Numéro").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Immatriculation").FontSize(6).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("N° Repertoire").FontSize(6).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Montant").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Nom de la L'Assuré").FontSize(7).ExtraBold().AlignCenter();



                    // cell content
                    table.Cell().Border(1).Padding(3).Text("531").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("2").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("01/01/01").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("185423428").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("1702-A/49").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("1 733,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("EL ALAMI RAJAE").FontSize(6).AlignCenter().ExtraBold();


                });
                col.Item().PaddingLeft(25).Column(col =>
                {
                    col.Spacing(5);
                    col.Item().Text(text =>
                    {
                        text.Span("Nbr Attestation    :    ").FontSize(8).ExtraBold();
                        text.Span("19").FontSize(8).ExtraBold();
                    });
                    col.Item().Text(text =>
                    {
                        text.Span("montant Total    :    ").FontSize(8).ExtraBold();
                        text.Span("24569").FontSize(8).ExtraBold();
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
                    row.RelativeItem(2).PaddingTop(8).Border(1).BorderColor(Colors.Black).PaddingTop(5).Padding(9).Text("ETAT DES VENTES PAR ADMINISTRATION CONVENTIONNEES\n ANNEE 2025").FontSize(8).FontFamily("Times New Roman").ExtraBold().AlignCenter();
                    row.RelativeItem(1).PaddingTop(8).PaddingRight(5).Border(1).BorderColor(Colors.Black).Column(col =>
                    {
                        col.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(4).Text("").FontSize(5);
                        col.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(4).Text("Version 1").FontSize(6).ExtraBold().AlignLeft();
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
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QPdfContainer = QuestPDF.Infrastructure.IContainer;

namespace Attestation;

// public class Caisses {
//     public int? id { get; set; }
//     public int? Matricule { get; set; }
//     public string? Agence { get; set; }
//     public List<AttestationInfo>? Infos { get; set; }
// }

//  public class AttestationCase
// {
//     public string? DateDU { get; set; }
//     public string? DateAU { get; set; }
//     public string? Agence { get; set; }
//     publci List<Caisses> Caisse { get; set; }
// }

// public class AttestationInfo
// {
//     public string? NumeroAttestation { get; set; }
//     public string? Numero { get; set; }
//     public string? NomPrenomAssure { get; set; }
//     public string? Ref_Recu_TPE  { get; set; }
//     public string? Banque  { get; set; }
//     public string? Type  { get; set; }
//     public string? Montant { get; set; }
//     public string? Total_TTC_G_C { get; set; }
//     public string? Taxe_Parafiscale { get; set; }
//     public string? Montant_Total { get; set; }
// }

public class ParTPE : IDocument
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
                // foreach (var attCase in ListOfCases)
                // {
                col.Item().PaddingTop(10).Column(col =>
                {
                    col.Item().Row(row =>
                    {
                        row.Spacing(5);
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Matricule  :   ").FontSize(8).FontFamily("Courie New").ExtraBold();
                                x.Span("2971").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Agence  :  ").FontFamily("Courie New").FontSize(8).ExtraBold();
                                x.Span("751").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Caisse  :  ").FontSize(8).FontFamily("Courie New").ExtraBold();
                                x.Span("23").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        row.RelativeItem(2);

                    });
                    col.Item().Row(row =>
                    {
                        row.Spacing(5);
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Date du   :   ").FontFamily("Courie New").FontSize(8).ExtraBold();
                                x.Span(" 01/01/01  ").FontFamily("Courie New").FontSize(8).ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Au   :   ").FontSize(8).FontFamily("Courie New").ExtraBold();
                                x.Span(" 01/01/01  ").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Text("VF").FontSize(8).ExtraBold();
                        row.RelativeItem(2);
                    });
                });
                col.Item().PaddingLeft(15).PaddingRight(12).Border(1).BorderColor(Colors.Black).Table(table =>
                {
                    table.ColumnsDefinition(table =>
                    {
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(2);
                        table.RelativeColumn(1);
                        table.RelativeColumn(2);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                    });
                    // headers 
                    table.Cell().Border(1).Padding(2).Text("Numéro\nAttentation").FontSize(6).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Numéro").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Nom et Prénom\n de la L'Assuré").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Réf.Reçu\nTPE").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Banque").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Type").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Montant").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Total TTC\ndes G C").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Taxe\nParafiscale").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Montant\nTotal").FontSize(7).ExtraBold().AlignCenter();

                    // cell content
                    table.Cell().Border(1).Padding(3).Text("185423428").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("6418 B1").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("EL ALAMI").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("STAN 5117").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("BMCE").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("RC\nGC").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("4 645,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("1 465,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("11,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("5 328,00").FontSize(6).AlignCenter().ExtraBold();

                    // last cell
                    table.Cell().ColumnSpan(6).Border(1).Padding(3).AlignCenter().Text(text =>
                    {
                        text.Span("Nombre de reçu TPE =  ").FontSize(6).ExtraBold();
                        text.Span("1").FontSize(6).ExtraBold();
                    });
                    table.Cell().Border(1).Padding(3).Text("1 645,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("4 485,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("11 789,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("13 957,00").FontSize(6).AlignCenter().ExtraBold();
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
                col.Item().Row(row =>
                {
                    row.RelativeItem(1).PaddingTop(8).PaddingLeft(5).Border(1).BorderColor(Colors.Black).AlignCenter().Padding(5).Image("/Users/amine/OneDrive/Desktop/testApi/depends/images/sntl.webp").FitWidth();
                    row.RelativeItem(2).PaddingTop(8).Border(1).BorderColor(Colors.Black).Padding(8).Text("ATTESTATIONS DELIVREES PAR TPE\n ANNEE 2025").FontSize(12).FontFamily("Times New Roman").ExtraBold().AlignCenter();
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
                    // row.Spacing(2);
                    row.RelativeItem(1)
                        .PaddingLeft(20)
                        .Text("ASS_FONCT83V1")
                        .ExtraBold()
                        .FontSize(7)
                        .AlignLeft();

                    row.RelativeItem(1).PaddingRight(20).AlignRight().Text(text =>
                    {
                        text.Span("Rabat Le : ").FontSize(7).ExtraBold();
                        text.Span("03/04/2025").FontSize(7).ExtraBold();
                    });
                });

            });
        }
    }
}
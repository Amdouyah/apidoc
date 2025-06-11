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
//     public string? Au { get; set; }
//     public string? Agence { get; set; }
//     public List<Caisses> Caisse { get; set; }
//     public string? Type_Credit { get; set; }

// }

// public class AttestationInfo
// {
//     public string? NumeroAttestation { get; set; }
//     public string? Date { get; set; }
//     public string? NomPrenomAssure { get; set; }
//     public string? Numero_Credit { get; set; }
//     public string? Montant { get; set; }

//    // Garanties Complementaires

//     public string? TotalHT { get; set; }
//     public string? Taxe { get; set; }
//     public string? Taxe_Parafiscal { get; set; }
//     public string? TotalTTC { get; set; }

//     public string? TypeGarantie { get; set; }
// }

public class CreditPPRDay : IDocument
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
                                x.Span("Date   :  ").FontFamily("Courie New").FontSize(8).ExtraBold();
                                x.Span("01/01/01").FontSize(8).FontFamily("Courie New").ExtraBold();
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
                                x.Span("37").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        row.RelativeItem(2);

                    });
                });

                col.Item().PaddingLeft(15).PaddingRight(12).PaddingTop(5).Border(1).BorderColor(Colors.Black).Table(table =>
                {
                    table.ColumnsDefinition(table =>
                    {
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(2);
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(5);
                        table.RelativeColumn(2);
                    });
                    table.Cell().Border(1).Padding(2).Text("Numéro\nAttentation").FontSize(6).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Date").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Nom et Prénom\n de la L'Assuré").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Numéro Crédit").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Montant").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).PaddingTop(3).Column(col =>
                    {
                        col.Item().BorderBottom(1).BorderColor(Colors.Black).Text("Garanties Complémentaires").FontSize(7).ExtraBold().AlignCenter();
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().BorderRight(1).Padding(1).Text("Total HT").FontSize(7).ExtraBold().AlignCenter();
                            row.RelativeItem().BorderRight(1).Padding(1).Text("Taxe").FontSize(7).ExtraBold().AlignCenter();
                            row.RelativeItem().BorderRight(1).Padding(1).Text("Taxe Parafiscal").FontSize(6).ExtraBold().AlignCenter();
                            row.RelativeItem().BorderRight(1).Padding(1).Text("Totatl TTC").FontSize(7).ExtraBold().AlignCenter();
                        });
                    });
                    table.Cell().Border(1).Padding(3).Text("Type\nGarantie").FontSize(7).ExtraBold().AlignCenter();

                    // cell content
                    table.Cell().Border(1).Padding(3).Text("185423428").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("01/01/01").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("EL ALAMI EL AROUSSI RAJAE").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("1702255").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("2 733,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Row(col =>
                    {
                        col.RelativeItem().Border(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();
                        col.RelativeItem().Border(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();
                        col.RelativeItem().Border(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();
                        col.RelativeItem().Border(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();
                    });
                    table.Cell().Border(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();


                    table.Cell().Border(1).Padding(3).Text("185423428").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("01/01/01").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("EL ALAMI EL AROUSSI RAJAE").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("1702255").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("2 733,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Row(col =>
                    {
                        col.RelativeItem().Border(1).Padding(3).Text("900,00").FontSize(6).AlignCenter().ExtraBold();
                        col.RelativeItem().Border(1).Padding(3).Text("**********").FontSize(6).AlignCenter().ExtraBold();
                        col.RelativeItem().Border(1).Padding(3).Text("**********").FontSize(6).AlignCenter().ExtraBold();
                        col.RelativeItem().Border(1).Padding(3).Text("100,00").FontSize(6).AlignCenter().ExtraBold();
                    });
                    table.Cell().Border(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();

                    // last cell
                    table.Cell().ColumnSpan(4).Border(1).Padding(3).Text("10").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("647,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Row(col =>
                    {
                        col.RelativeItem().Border(1).Padding(3).Text("69,49").FontSize(6).AlignCenter().ExtraBold();
                        col.RelativeItem().Border(1).Padding(3).Text("9,73").FontSize(6).AlignCenter().ExtraBold();
                        col.RelativeItem().Border(1).Padding(3).Text("6,15").FontSize(6).AlignCenter().ExtraBold();
                        col.RelativeItem().Border(1).Padding(3).Text("86,00").FontSize(6).AlignCenter().ExtraBold();
                    });
                    table.Cell().ColumnSpan(1).Border(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();
                });
                col.Item().PaddingVertical(2).AlignCenter().Width(400).PaddingLeft(20).Text(text =>
                {
                    text.Span("Total montant des attestations délivrées au crédit  =  ").FontSize(10).ExtraBold();
                    text.Span("2").FontSize(10).ExtraBold();
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
                    row.RelativeItem(2).PaddingTop(8).Border(1).BorderColor(Colors.Black).Padding(8).Text("ATTESTATION DELIVREES A CREDIT PPR\n ANNEE 2025").FontSize(12).FontFamily("Times New Roman").ExtraBold().AlignCenter();
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
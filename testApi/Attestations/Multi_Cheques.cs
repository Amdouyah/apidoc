using System.ComponentModel;
using System.Diagnostics;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QPdfContainer = QuestPDF.Infrastructure.IContainer;

namespace Attestation;


// QuestPDF.Settings.EnableDebugging = true;


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


public class MultiCheques : IDocument
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
                col.Spacing(4);
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
                                x.Span("Date début   :   ").FontFamily("Courie New").FontSize(8).ExtraBold();
                                x.Span(" 01/01/01  ").FontFamily("Courie New").FontSize(8).ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Date fin   :   ").FontSize(8).FontFamily("Courie New").ExtraBold();
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
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(3);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(1);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);

                    });
                    // headers 
                    table.Cell().Border(1).Padding(3).Text("Agence").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Caisse").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Numéro\nAttentation").FontSize(6).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Date\nVente").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Nom et Prénom\n de la L'Assuré").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Montant\nAttentation").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Total TTC\ndes G C").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Montant\nTotal").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Numéro du\nChèque").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Banque").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Montant Chèque").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Date Echéance").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Sit").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Livraison").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Ville").FontSize(7).ExtraBold().AlignCenter();

                    // cell content
                    table.Cell().Border(1).Padding(3).Text("751").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("23").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("185426427").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("01/01/01").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("HASSAN").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("3 657,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("645,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("465,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("2 211,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("BMCI").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("2 211,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("01/01/01").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().ColumnSpan(3).Border(1).Padding(3).Text("E").FontSize(6).AlignLeft().ExtraBold();

                    // last cell
                    table.Cell().ColumnSpan(2).Border(1).Padding(3).AlignCenter().Text("");
                    table.Cell().ColumnSpan(10).Border(1).Padding(3).Text("Total Montante Chèques Attestation  :  ").FontSize(9).AlignLeft().ExtraBold();
                    table.Cell().ColumnSpan(3).Border(1).Padding(3).Text("").FontSize(6).AlignLeft().ExtraBold();

                });
                col.Item().PaddingVertical(2).AlignCenter().Border(1).BorderColor(Colors.Black).Width(300).Row(row =>
                {
                    row.Spacing(2);
                    row.ConstantItem(90).AlignLeft().Padding(3).Text("Total Par agence :").FontSize(8).ExtraBold();
                    row.ConstantItem(30).AlignCenter().Padding(3).Text("0").FontSize(8).ExtraBold();
                    row.ConstantItem(50).AlignCenter().Padding(3).Text("3 419,00").FontSize(8).ExtraBold();
                    row.ConstantItem(50).AlignCenter().Padding(3).Text("827,00").FontSize(8).ExtraBold();
                    row.ConstantItem(50).AlignCenter().Padding(3).Text("4 246,00").FontSize(8).ExtraBold();
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
                    row.RelativeItem(2).PaddingTop(8).Border(1).BorderColor(Colors.Black).Padding(8).Text("ATTESTATIONS DELIVREES PAR CHEQUES M (Sit E)\n ANNEE 2025").FontSize(10).FontFamily("Times New Roman").ExtraBold().AlignCenter();
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
                        .Text("ASS_FONCT72V7")
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
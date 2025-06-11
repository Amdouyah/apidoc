using System.Diagnostics;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Attestation;


// ------list needed

// public class Caisses {
//     public int? id { get; set; }
//     public int? Matricule { get; set; }
//     public string? Agence { get; set; }
//     public List<AttestationInfo>? Infos { get; set; }
// }

//  public class AttestationCase
// {
//     public string? Du { get; set; }
//     public string? Au { get; set; }
//     public string? Agence { get; set; }
//     publci List<Caisses> Caisse { get; set; }
// }

// public class AttestationInfo
// {
//     public string? NumeroAttestation { get; set; }
//     public string? Numero { get; set; }
//     public string? NomPrenomAssure { get; set; }
//     public string? Numero du  { get; set; }
//     public string? Banque  { get; set; }
//     public string? Type { get; set; }
//     public string? Montant_Attestation { get; set; }
//     public string? Total_TTC_G_C { get; set; }
//     public string? Total_Taxe_Parafiscale { get; set; }
//     public string? Montant_Total { get; set; }
//     public string? Livraison { get; set; }
// }

public class ChequeUnique : IDocument
{
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    public void Compose(IDocumentContainer container)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        container.Page(page =>
        {
            page.Header().PaddingLeft(15).PaddingRight(15).Height(60).AlignCenter().Element(Header);
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
                                x.Span("Matricule  :   ").FontSize(8).ExtraBold();
                                x.Span("2971").FontSize(8).ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Agence  :  ").FontSize(8).ExtraBold();
                                x.Span("751").FontSize(8).ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Caisse  :  ").FontSize(8).ExtraBold();
                                x.Span("23").FontSize(8).ExtraBold();
                            });
                        });
                    });
                    col.Item().Row(row =>
                    {
                        row.Spacing(5);
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Date du   :   ").FontSize(8).ExtraBold();
                                x.Span(" 01/01/01  ").FontSize(8).ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Au   :   ").FontSize(8).ExtraBold();
                                x.Span(" 01/01/01  ").FontSize(8).ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Text("VF").FontSize(8).ExtraBold();
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
                        table.RelativeColumn();
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
                    table.Cell().Border(1).Padding(3).Text("Numéro du ").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Banque").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Type").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Montant\nAttentation").FontSize(6).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Total TTC\ndes G C").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Total Taxe\nparafiscale").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(2).Text("Montant\nTotal").FontSize(6).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Livraison").FontSize(7).ExtraBold().AlignCenter();

                    // cell content
                    table.Cell().Border(1).Padding(3).Text("185423428").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("6418 B1").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("EL ALAMI").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("AWR 919042").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("ATTIJARIWAFA BANK").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("RC\nGC").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("1645,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("45,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("11,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("1357,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("").FontSize(6).AlignCenter();

                    // last cell
                    table.Cell().ColumnSpan(6).Border(1).Padding(3).AlignCenter().Text(text =>
                    {
                        text.Span("Nombre de chéques  =  ").FontSize(6).ExtraBold();
                        text.Span("1").FontSize(6).ExtraBold();
                    });
                    table.Cell().Border(1).Padding(3).Text("1645,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("45,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("11,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("1357,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderBottom(0).BorderLeft(1).BorderRight(0).BorderTop(0).Padding(3).Text("").FontSize(6).AlignCenter();
                });
                // foreach (var case1 in listOfcases)
                // {
                //     //start workin on my table here 
                // }
                // }
            });
        });
    }
    public void Header(IContainer cont)
    {
        cont.Column(col =>
        {
            col.Spacing(1);
            col.Item().Row(row =>
            {
                //path of image also
                row.RelativeItem(1).PaddingTop(5).Border(1).BorderColor(Colors.Black).AlignCenter();
                row.RelativeItem(2).PaddingTop(5).Border(1).BorderColor(Colors.Black).PaddingVertical(5).PaddingHorizontal(2).Text("ATTESTATIONS DELIVREES PAR CHEQUE UNIQUE\n ANNEE 2025").FontSize(10).FontFamily("Times New Roman").ExtraBold().AlignCenter();
                row.RelativeItem(1).PaddingTop(5).Border(1).BorderColor(Colors.Black).Padding(2).Column(col =>
                {
                    col.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(2).Text("").FontSize(5);
                    col.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(3).Text("Version 4").FontSize(6).ExtraBold().AlignLeft();
                    col.Item().Padding(2).AlignLeft().Text(txt =>
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
                    .Text("ASS_FONCT72V5")
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
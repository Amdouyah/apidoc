using System.Diagnostics;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Attestation;

//what should iget first 

// public class Caisses {
//     public int? id { get; set; }
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
//     public string? Montant { get; set; }

//     //Garanties Complementaires

//     public string? TotalHT { get; set; }
//     public string? Taxe { get; set; }
//     public string? Parafiscale { get; set; }
//     public string? TotalTTC { get; set; }

//     public string? MontantTTC { get; set; }
//     public string? TypeGarantie { get; set; }
//     public string? Livraison { get; set; }
// }


public class EnEspece : IDocument
{
    public void Compose(IDocumentContainer container)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        container.Page(page =>
        {
            page.Header().PaddingLeft(15).PaddingRight(15).Height(60).AlignCenter().Element(Head);
            page.Content().Column(col =>
            {
                col.Spacing(5);
                // foreach (var attCase in ListOfCases)
                // {
                col.Item().PaddingTop(10).Row(row =>
                {
                    row.Spacing(20);
                    row.RelativeItem().AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                    {
                        column.Item().Text(x =>
                        {
                            x.Span("Du   :   ").FontSize(8).ExtraBold();
                            x.Span(" 01/01/01  ").FontSize(8).ExtraBold();
                        });
                    });
                    row.RelativeItem().AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                    {
                        column.Item().Text(x =>
                        {
                            x.Span("Au   :   ").FontSize(8).ExtraBold();
                            x.Span(" 01/01/01  ").FontSize(8).ExtraBold();
                        });
                    });
                    row.RelativeItem().AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                    {
                        column.Item().PaddingTop(10).Text(x =>
                        {
                            x.Span("Agence" + "   :   " + " 751 ").FontSize(8).ExtraBold();
                            x.Span("\nVF").FontSize(8).ExtraBold();
                        });
                    });
                    row.RelativeItem().AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                    {
                        column.Item().Text(x =>
                        {
                            x.Span("Caisse   :   ").FontSize(8).ExtraBold();
                            x.Span(" 23  ").FontSize(8).ExtraBold();
                        });
                    });
                });
                col.Item().PaddingLeft(10).PaddingRight(12).Border(1).BorderColor(Colors.Black).Table(table =>
                {
                    table.ColumnsDefinition(table =>
                    {
                        table.RelativeColumn(1);
                        table.RelativeColumn(1);
                        table.RelativeColumn(2);
                        table.RelativeColumn(1);
                        // table.RelativeColumn(5);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(1);
                    });
                    table.Cell().Border(1).Padding(2).Text("Numéro\nAttentation").FontSize(6).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Numéro").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Nom et Prénom\n de la L'Assuré").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Montant").FontSize(7).ExtraBold().AlignCenter();
                    // table.Cell().Border(1).PaddingTop(3).Column(col =>
                    // {
                    //     col.Item().BorderBottom(1).BorderColor(Colors.Black).Text("Garanties Complémentaires").FontSize(7).ExtraBold().AlignCenter();
                    //     col.Item().Row(row =>
                    //     {
                    //         row.RelativeItem().BorderRight(1).Padding(1).Text("Total HT").FontSize(7).ExtraBold().AlignCenter();
                    //         row.RelativeItem().BorderRight(1).Padding(1).Text("Taxe").FontSize(7).ExtraBold().AlignCenter();
                    //         row.RelativeItem().BorderRight(1).Padding(1).Text("Montant").FontSize(7).ExtraBold().AlignCenter();
                    //         row.RelativeItem().BorderRight(1).Padding(1).Text("Parafi").FontSize(7).ExtraBold().AlignCenter();
                    //     });
                    // });
                    table.Cell().Border(1).Padding(3).PaddingTop(3).Text("Montant TTC").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Type\nGarantie").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Livraison").FontSize(7).ExtraBold().AlignCenter();

                    table.Cell().Border(1).Padding(3).Text("185423428").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("6418 B1").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("EL ALAMI EL AROUSSI RAJAE").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("647,00").FontSize(6).AlignCenter().ExtraBold();
                    // table.Cell().Border(1).Row(col =>
                    // {
                    //     col.RelativeItem().Border(1).Padding(3).Text("69,49").FontSize(6).AlignCenter().ExtraBold();
                    //     col.RelativeItem().Border(1).Padding(3).Text("9,73").FontSize(6).AlignCenter().ExtraBold();
                    //     col.RelativeItem().Border(1).Padding(3).Text("6,15").FontSize(6).AlignCenter().ExtraBold();
                    //     col.RelativeItem().Border(1).Padding(3).Text("86,00").FontSize(6).AlignCenter().ExtraBold();
                    // });
                    table.Cell().Border(1).Padding(3).Text("733,00").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("Normal").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text($"122").FontSize(6).AlignCenter().ExtraBold();

                    table.Cell().ColumnSpan(3).Border(1).Padding(3).Text("test").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("647,00").FontSize(6).AlignCenter().ExtraBold();
                    // table.Cell().Border(1).Row(col =>
                    // {
                    //     col.RelativeItem().Border(1).Padding(3).Text("69,49").FontSize(6).AlignCenter().ExtraBold();
                    //     col.RelativeItem().Border(1).Padding(3).Text("9,73").FontSize(6).AlignCenter().ExtraBold();
                    //     col.RelativeItem().Border(1).Padding(3).Text("6,15").FontSize(6).AlignCenter().ExtraBold();
                    //     col.RelativeItem().Border(1).Padding(3).Text("86,00").FontSize(6).AlignCenter().ExtraBold();
                    // });
                    table.Cell().ColumnSpan(2).Border(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().Border(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();

                });
                col.Item().PaddingLeft(17).PaddingRight(12).AlignCenter().Text(x =>
                {
                    x.Span("Total montant des attestations delivrees en espece  = ").FontSize(8).ExtraBold();
                    x.Span(" 733,00").FontSize(8).ExtraBold();
                });
                // foreach (var case1 in listOfcases)
                // {
                //     //start workin on my table here 
                // }
                // }
            });
        });
    }
    public void Head(IContainer cont)
    {
        cont.Column(col =>
        {
            col.Spacing(1);
            col.Item().Row(row =>
            {
                row.RelativeItem(1).PaddingTop(5).Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                row.RelativeItem(2).PaddingTop(5).Border(1).BorderColor(Colors.Black).PaddingVertical(8).PaddingHorizontal(5).Text("ATTESTATIONS DELIVREES EN ESPECE\n ANNEE 2025").FontSize(10).ExtraBold().AlignCenter();
                row.RelativeItem(1).PaddingTop(5).Border(1).BorderColor(Colors.Black).Column(col2 =>
                {
                    col2.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(2).Text("").FontSize(2);
                    col2.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(2).Text("Version  :   4").FontSize(6).ExtraBold().AlignLeft();
                    col2.Item().Padding(2).AlignLeft().Text(txt =>
                    {
                        txt.Span("Page : ").FontSize(7).ExtraBold();
                        txt.CurrentPageNumber().FontSize(7).ExtraBold();
                        txt.Span("   /   ").FontSize(7).ExtraBold();
                        txt.TotalPages().FontSize(7).ExtraBold();
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
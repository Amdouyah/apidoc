using System.ComponentModel;
using System.Diagnostics;
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
//     public string? ModeReglement { get; set; }
//     publci List<Caisses> Caisse { get; set; }
// }

// public class AttestationInfo
// {
//     public string? NumeroCarte { get; set; }
//     public string? NumeroAttestation { get; set; }
//     public string? NomPrenom{ get; set; }
//     public string? NumeroVehicule  { get; set; }
//     public string? DateDeffet  { get; set; }
//     public string? DateDecheance  { get; set; }
//     public string? ReferenceDeReglement { get; set; }
//     public string? Montant { get; set; }
// }

public class CarteVertes : IDocument
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
                                x.Span("").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("VF    Année  :  ").FontSize(8).FontFamily("Courie New").ExtraBold();
                                x.Span("2025").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        // row.RelativeItem(2);

                    });
                    col.Item().Row(row =>
                    {
                        row.Spacing(5);
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Date vente du   :   ").FontFamily("Courie New").FontSize(8).ExtraBold();
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
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Mode de Règlement : ").FontSize(8).FontFamily("Courie New").ExtraBold();
                                x.Span("ESPECE").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        row.RelativeItem(1);
                    });
                });
                col.Item().PaddingLeft(15).PaddingRight(12).Border(1).BorderColor(Colors.Black).Table(table =>
                {
                    table.ColumnsDefinition(table =>
                    {
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(3);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);
                        table.RelativeColumn(2);

                    });
                    // headers 
                    table.Cell().Border(1).Padding(3).Text("Numéro\nCarte").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Numéro\nAttentation").FontSize(6).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Nom et Prénom").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Numéro \nVéhicule").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Date\nd'effet").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Date\nd'echéance").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Réfèrence de\nRèglement").FontSize(7).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(3).Text("Montant").FontSize(7).ExtraBold().AlignCenter();

                    // cell content
                    table.Cell().BorderTop(1).BorderLeft(1).BorderRight(1).Padding(3).Text("3124942").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("195409968").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("HASSAN HASSAN").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("1854-B/72").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("01/01/01").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("01/01/01").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(3).Text("").FontSize(6).AlignCenter().ExtraBold();
                    table.Cell().BorderBottom(1).BorderLeft(1).BorderRight(1).Padding(3).Text("450,00").FontSize(6).AlignCenter().ExtraBold();

                });
                col.Item().PaddingVertical(2).PaddingTop(6).AlignCenter().Width(300).Text(text =>
                {
                    text.Span("NOMBRE TOTAL DES CARTES  :  ").FontSize(10).ExtraBold();
                    text.Span("5").FontSize(10).ExtraBold();
                });
                col.Item().PaddingVertical(2).AlignCenter().Width(300).Text(text =>
                {
                    text.Span("TOTAL DES MONTANTS  :  ").FontSize(10).ExtraBold();
                    text.Span("2 250,00").FontSize(10).ExtraBold();
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
                    row.RelativeItem(2).PaddingTop(8).Border(1).BorderColor(Colors.Black).Padding(8).Text("LISTE DES CARTES VERTES\n ANNEE 2025").FontSize(10).FontFamily("Times New Roman").ExtraBold().AlignCenter();
                    row.RelativeItem(1).PaddingTop(8).PaddingRight(5).Border(1).BorderColor(Colors.Black).Column(col =>
                    {
                        col.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(4).Text("").FontSize(5);
                        col.Item().BorderBottom(1).BorderColor(Colors.Black).Padding(4).Text("Version 3").FontSize(6).ExtraBold().AlignLeft();
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
                        .Text("ASS_FONCT46V1")
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
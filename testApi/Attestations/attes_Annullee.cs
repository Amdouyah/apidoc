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
//     public string? NumeroCaisse { get; set; }
//     public string? NumeroAttestation { get; set; }
// }

// 7 one about caisses and total 


public class AttestatioAnnullee : IDocument
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
                                x.Span("Agence  :  ").FontFamily("Courie New").FontSize(8).ExtraBold();
                                x.Span("751").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Date début  :  ").FontSize(8).FontFamily("Courie New").ExtraBold();
                                x.Span("01/01/01").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        row.RelativeItem(1).AlignBottom().AlignLeft().PaddingLeft(15).Column(column =>
                        {
                            column.Item().Text(x =>
                            {
                                x.Span("Date fin  :  ").FontSize(8).FontFamily("Courie New").ExtraBold();
                                x.Span("01/01/01").FontSize(8).FontFamily("Courie New").ExtraBold();
                            });
                        });
                        row.RelativeItem(2);

                    });
                });
                col.Item().PaddingVertical(2).AlignCenter().Width(200).PaddingTop(10).Border(1).BorderColor(Colors.Black).Table(table =>
                {
                    table.ColumnsDefinition(table =>
                    {
                        table.RelativeColumn();
                        table.RelativeColumn();
                    });
                    // headers 
                    table.Cell().Border(1).Padding(6).Text("N° Caisse").FontSize(8).ExtraBold().AlignCenter();
                    table.Cell().Border(1).Padding(6).Text("Num.Attentation").FontSize(8).ExtraBold().AlignCenter();

                    // cell content
                    table.Cell().BorderTop(1).BorderLeft(1).BorderRight(1).Padding(6).Text("42").FontSize(8).AlignCenter().ExtraBold();
                    table.Cell().BorderLeft(1).BorderRight(1).Padding(6).Text("195409968").FontSize(8).AlignCenter().ExtraBold();

                });
                col.Item().PaddingVertical(2).AlignCenter().Width(200).PaddingLeft(20).Text(text =>
                {
                    text.Span("TOTAL  :  ").FontSize(8).ExtraBold();
                    text.Span("2").FontSize(8).ExtraBold();
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
                    row.RelativeItem(2).PaddingTop(8).Border(1).BorderColor(Colors.Black).Padding(8).Text("ETAT ATTESTATION ANNULEE\n ANNEE 2025").FontSize(13).FontFamily("Times New Roman").ExtraBold().AlignCenter();
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
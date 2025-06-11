// using FastEndpoints;
// using QuestPDF.Fluent;
// using QuestPDF.Infrastructure;
// using Microsoft.AspNetCore.Http;
// using QuestPDF.Helpers;

// namespace FastEndpointsTutorial;


// // public class AssureData
// // {
// //     public string? Nom { get; set; }
// //     public string? Prenom { get; set; }
// //     public string? NoCIN { get; set; }
// //     public string? NoRC { get; set; }
// //     public string? Adresse { get; set; }
// //     public string? NoPermis { get; set; }
// //     public string? Ville { get; set; }
// //     public string? DateDelivrance { get; set; }
// //     public string? Marque { get; set; }
// //     public string? Type { get; set; }
// //     public string? PoidsTotal { get; set; }
// //     public string? ValeurVenale { get; set; }
// //     public string? Immatriculation { get; set; }
// //     public string? MiseEnCirculation { get; set; }
// //     public string? Puiss_Fiscale { get; set; }
// //     public string? Combustion { get; set; }
// //     public string? Usage { get; set; }
// //     public string? NbrePlaces { get; set; }
// //     public string? Matricule { get; set; }
// //     public string? ValeurNeuf { get; set; }
// //     public string? POLE { get; set; }
// //     public string? AttestationNo { get; set; }
// //     public string? CRM { get; set; }
// //     public string? Duree { get; set; }
// //     public string? DateEffet { get; set; }
// //     public string? DateEcheance { get; set; }
// //     public string? EcheanceAnniversaire { get; set; }

// //     //Garanties
// //     public List<Garantie>? RESPONSABILITE_CIVILE { get; set; }
// //     public List<Garantie>? DEFENSE_ET_RECOURS { get; set; }
// //     public List<Garantie>? PERSONNES_TRANSPORTEES { get; set; }
// //     public List<Garantie>? DOMMAGES_COLLISION { get; set; }
// //     public List<Garantie>? INCENDIE { get; set; }
// //     public List<Garantie>? VOL { get; set; }
// //     public List<Garantie>? VOL_DE_REMORQUEUR { get; set; }
// //     public List<Garantie>? BRIS_DE_GLACES_1ER_RISQUE { get; set; }
// //     public List<Garantie>? DOMMAGES_COLLISION_DEPLAFONNEE { get; set; }
// //     public List<Garantie>? TIERCE { get; set; }
// //     public List<Garantie>? TIERCE_OPTIMALE { get; set; }
// //     public List<Garantie>? TIERCE_ECO { get; set; }
// //     public List<Garantie>? TIERCE_OPTIMALE_ECO { get; set; }
// //     public List<Garantie>? RACHAT_DE_FRANCHISE_DCD_DC { get; set; }
// //     public List<Garantie>? RACHAT_DE_LA_VETUSTE_RC { get; set; }
// //     public List<Garantie>? RACHAT_DE_LA_VETUSTE_RC_DCD { get; set; }
// //     public List<Garantie>? EVENEMENTS_CATASTROPHIQUES { get; set; }
// //     public double? ASSISTANCE_RMA_MERTAH { get; set; }


// //     // Décompte de primes
// //     public List<DecomptePrimes>? PrimeNette { get; set; }
// //     public List<DecomptePrimes>? Taxes { get; set; }
// //     public double? AccessoiresEtTimbre_PTA_PC { get; set; }
// //     public double? S_Total { get; set; }
// //     public double? EvenementsCatastrophiques_PTA_PC { get; set; }
// //     public double? TaxeEvenementsCatastrophiques_PTA_PC { get; set; }
// //     public double? TaxeParafiscale_PTA_PC { get; set; }
// //     public double? PrimeTotaleAPayer { get; set; }
    
// // }
// // public class Garantie
// // {
// //     public string? CapitalAssureEnDirhams { get; set; }
// //     public string? Franchise { get; set; }
// //     public string? PrimeNetteHT { get; set; }
// // }

// // public class DecomptePrimes
// // {
// //     public string? Automobile { get; set; }
// //     public string? PTA_PC { get; set; }
// // }   


// public class ExamplEndpoint : EndpointWithoutRequest
// {
//     public override void Configure()
//     {
//         Get("/pdf");
//         AllowAnonymous();
//     }

//     public override async Task HandleAsync(CancellationToken ct)
//     {
//         //REPR Design Pattern = defines web API endpoints as having three components:
//         // a Request, an Endpoint and a Response.

//         byte[] pdfBytes = Document.Create(container =>
//         {
//             container.Page(page =>
//             {
//                 page.Header().Element(Head);
//                 page.Content().Element(Content);
//                 page.Footer().Element(Footer);

//                 void Head(IContainer cont)
//                 {
//                     cont.Row(row =>
//                     {
//                         row.Spacing(10);
//                         row.RelativeItem().AlignBottom().AlignCenter().PaddingBottom(10).Column(colu =>
//                         {
//                             colu.Spacing(3);
//                             colu.Item().PaddingLeft(10).Text(x =>
//                             {
//                                 x.Span("Intermédiare  :  ").ExtraBold().FontSize(9);
//                                 x.Span(" SNTL ASSURANCES SA").FontSize(9);
//                             });
//                             colu.Item().PaddingLeft(10).Text(x =>
//                             {
//                                 x.Span("Code de l'intermédiare  : ").ExtraBold().FontSize(9);
//                                 x.Span(" A5991 ").FontSize(9);
//                             });
//                         });

//                         row.RelativeItem().PaddingBottom(5).Column(column =>
//                         {
//                             column.Spacing(10);
//                             column.Item().PaddingVertical(10).AlignTop().Column(colu =>
//                             {
//                                 colu.Item().AlignCenter().Text(x =>
//                                 {
//                                     x.Span("CONDITIONS PARTICULIERES ").ExtraBold().FontSize(10);
//                                     x.Span("(1)").ExtraBold().FontSize(5);

//                                 });

//                                 colu.Item().Text("Contrat d'Assurances Automobile").ExtraBold().FontSize(10).AlignCenter();
//                                 colu.Item().Text("HIFAD").ExtraBold().FontSize(10).AlignCenter();
//                             });

//                             column.Item().AlignBottom().AlignCenter().Column(colu =>
//                             {
//                                 colu.Spacing(3);
//                                 colu.Item().Text(x =>
//                                 {
//                                     x.Span("Police  n°  :  ").ExtraBold().FontSize(9);
//                                     x.Span("599170124064595").FontSize(9);
//                                 });
//                                 colu.Item().Text(x =>
//                                 {
//                                     x.Span("Libellé de l'avenant  :  ").ExtraBold().FontSize(9);
//                                     x.Span(" ").FontSize(9);
//                                 });
//                             });
//                         });

//                         row.ConstantItem(200).PaddingTop(10).PaddingRight(10).PaddingBottom(5)
//                             .Column(column =>
//                             {
//                                 column.Spacing(5);
//                                 column.Item().AlignCenter().Image("depends/images/royale-marocaine-dassurance-seeklogo.png").FitWidth();
//                                 column.Item().AlignBottom().Text(text =>
//                                 {
//                                     text.Span("     Numéro d'assistance  : 05 22 46 46 46\n").ExtraBold().FontColor(Colors.Black).FontSize(10);
//                                     text.Span("Les contrats d'assurance ayant pour échéance le 31 Décembre sont valables jusqu'au 31 Janvier de l’année qui suit, à condition de leur renouvellement.").Bold().FontSize(8);
//                                 });
//                             });
//                     });
//                 }
//                 void Content(IContainer cont)
//                 {
//                     cont.Extend().PaddingLeft(15).PaddingRight(15).Column(mainColumn =>
//                     {
//                         // Souscripteur section
//                         mainColumn.Spacing(2);
//                         mainColumn.Item().Column(sectionColumn =>
//                         {
//                             sectionColumn.Item().Padding(3).Text("Souscripteur").ExtraBold().FontSize(9);
//                             sectionColumn.Item().Border(1).BorderColor(Colors.Black).Padding(5).Column(infoColumn =>
//                             {
//                                 infoColumn.Spacing(4);
//                                 infoColumn.Item().Row(row =>
//                                 {
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Nom et Prénom (s) ou Raison sociale  :  ").ExtraBold().FontSize(8);
//                                         x.Span("MALAK MASROUR").FontSize(8);
//                                     });
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("N° de C.I.N. ou R.C.  :  ").ExtraBold().FontSize(8);
//                                         x.Span("MAA120532").FontSize(8);
//                                     });

//                                 });
//                                 infoColumn.Item().Row(row =>
//                                 {
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Adresse  :  ").ExtraBold().FontSize(8);
//                                         x.Span("SECT 4 BLOC H N 3 AV AL JACARANDA HAY RIAD RABAT").FontSize(8);
//                                     });
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("N° de permis  :  ").ExtraBold().FontSize(8);
//                                         x.Span(" ").FontSize(8);
//                                     });
//                                 });
//                                 infoColumn.Item().Row(row =>
//                                 {
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Ville  :  ").ExtraBold().FontSize(8);
//                                         x.Span(" ").FontSize(8);
//                                     });
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Date de délivrance  :  ").ExtraBold().FontSize(8);
//                                         x.Span(" ").FontSize(8);
//                                     }); ;
//                                 });
//                             });
//                         });

//                         // Véhicule assuré section
//                         mainColumn.Item().Column(sectionColumn =>
//                         {
//                             sectionColumn.Item().Padding(3).Text("Véhicule assuré").ExtraBold().FontSize(9);
//                             sectionColumn.Item().Border(1).BorderColor(Colors.Black).Padding(5).Column(infoColumn =>
//                             {
//                                 infoColumn.Spacing(4);
//                                 infoColumn.Item().Row(row =>
//                                 {
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Marque et Type  :  ").ExtraBold().FontSize(8);
//                                         x.Span("HONDA").FontSize(8);
//                                     });
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Immatriculation  :  ").ExtraBold().FontSize(8);
//                                         x.Span("88944-D/1").FontSize(8);
//                                     }); ;
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Mise en circulation  :  ").ExtraBold().FontSize(8);
//                                         x.Span("10/10/2013").FontSize(8);
//                                     }); ;

//                                 });
//                                 infoColumn.Item().Row(row =>
//                                 {
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Puiss. fiscale  : ").ExtraBold().FontSize(8);
//                                         x.Span("9").FontSize(8);
//                                     });
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Combustion  :  ").ExtraBold().FontSize(8);
//                                         x.Span("Diesel").FontSize(8);
//                                     });

//                                     row.RelativeItem().Text("").FontSize(8);

//                                 });
//                                 infoColumn.Item().Row(row =>
//                                 {
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Usage  :  ").ExtraBold().FontSize(8);
//                                         x.Span("CI").FontSize(8);
//                                     });
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Nbre de places  :  ").ExtraBold().FontSize(8);
//                                         x.Span("5").FontSize(8);
//                                     }); ;
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Matricule  :  ").ExtraBold().FontSize(8);
//                                         x.Span("").FontSize(8);
//                                     });

//                                 });
//                                 infoColumn.Item().Row(row =>
//                                 {
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Valeur à neuf  :  ").ExtraBold().FontSize(8);
//                                         x.Span("").FontSize(8);
//                                     });
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Valeur vénale  :  ").ExtraBold().FontSize(8);
//                                         x.Span("140 000,00").FontSize(8);
//                                     }); ;
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("POLE  :  ").ExtraBold().FontSize(8);
//                                         x.Span("").FontSize(8);
//                                     });

//                                 });
//                             });
//                         });

//                         // Remorque section
//                         mainColumn.Item().Column(sectionColumn =>
//                         {
//                             sectionColumn.Item().Padding(3).Text("Remorque (s)").ExtraBold().FontSize(9);
//                             sectionColumn.Item().Table(table =>
//                             {
//                                 table.ColumnsDefinition(columns =>
//                                 {
//                                     columns.RelativeColumn();
//                                     columns.RelativeColumn();
//                                     columns.RelativeColumn();
//                                     columns.RelativeColumn();
//                                     columns.RelativeColumn();
//                                     columns.RelativeColumn();
//                                 });

//                                 // Header
//                                 table.Cell().Border(1).Padding(2).Text("Type").AlignCenter().ExtraBold().FontSize(9);
//                                 table.Cell().Border(1).Padding(2).Text("Marque").AlignCenter().ExtraBold().FontSize(9);
//                                 table.Cell().Border(1).Padding(2).Text("Poids total").AlignCenter().ExtraBold().FontSize(9);
//                                 table.Cell().Border(1).Padding(2).Text("Valeur à neuf").AlignCenter().ExtraBold().FontSize(9);
//                                 table.Cell().Border(1).Padding(2).Text("Valeur vénale").AlignCenter().ExtraBold().FontSize(9);
//                                 table.Cell().Border(1).Padding(2).Text("Immatriculation").AlignCenter().ExtraBold().FontSize(9);

//                                 // Empty row
//                                 table.Cell().Border(1).Padding(5).Text("");
//                                 table.Cell().Border(1).Padding(5).Text("");
//                                 table.Cell().Border(1).Padding(5).Text("");
//                                 table.Cell().Border(1).Padding(5).Text("");
//                                 table.Cell().Border(1).Padding(5).Text("");
//                                 table.Cell().Border(1).Padding(5).Text("");
//                             });
//                         });

//                         // Caractéristiques de la police section
//                         mainColumn.Item().Column(sectionColumn =>
//                         {
//                             sectionColumn.Item().Padding(3).Text("Caractéristiques de la police").ExtraBold().FontSize(9);
//                             sectionColumn.Item().Border(1).BorderColor(Colors.Black).Padding(4).AlignLeft().Column(infoColumn =>
//                             {
//                                 infoColumn.Item().Padding(2).Row(row =>
//                                 {
//                                     // row.Spacing(3);
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Attestation n°  :  ").ExtraBold().FontSize(8);
//                                         x.Span("185410671").FontSize(8);
//                                     });
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("CRM  :  ").ExtraBold().FontSize(8);
//                                         x.Span("1,00").FontSize(8);
//                                     }); ;
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Durée  :  ").ExtraBold().FontSize(8);
//                                         x.Span("").FontSize(8);
//                                     });
//                                 });
//                                 infoColumn.Item().Row(row =>
//                                 {
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Date d'effet  :  ").ExtraBold().FontSize(8);
//                                         x.Span("01/01/2025 à 00H 0").FontSize(8);
//                                     });
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Date d'échéance  :  ").ExtraBold().FontSize(8);
//                                         x.Span("31/12/2025 à 24H 00").FontSize(8);
//                                     }); ;
//                                     row.RelativeItem().Text(x =>
//                                     {
//                                         x.Span("Echéance anniversaire  :  ").ExtraBold().FontSize(8);
//                                         x.Span("").FontSize(8);
//                                     });
//                                 });

//                             });
//                         });

//                         // Two column section for Risques assurés and other tables
//                         mainColumn.Item().Padding(5).Text("Risques assurés et primes à payer").ExtraBold().FontSize(9);

//                         mainColumn.Item().Row(mainRow =>
//                         {
//                             // Left column - Risques assurés et primes à payer
//                             mainRow.RelativeItem(2).PaddingRight(10).ExtendVertical().Column(leftColumn =>
//                             {
//                                 // leftColumn.Item().Padding(3).Text("Risques assurés et primes à payer").ExtraBold().FontSize(9);
//                                 leftColumn.Item().PaddingBottom(1).Table(table =>
//                                 {
//                                     table.ColumnsDefinition(columns =>
//                                     {
//                                         columns.RelativeColumn(2);
//                                         columns.RelativeColumn(1);
//                                         columns.RelativeColumn(1);
//                                         columns.RelativeColumn(1);
//                                     });

//                                     // Headers
//                                     table.Cell().Border(1).Padding(4).Text("Garanties \nVéhicule").ExtraBold().AlignCenter().FontSize(10);
//                                     table.Cell().Border(1).Padding(4).Text("Capital assuré \nen dirhams").ExtraBold().AlignCenter().FontSize(10);
//                                     table.Cell().Border(1).Padding(4).Text("Franchise \n(*)").ExtraBold().AlignCenter().FontSize(10);
//                                     table.Cell().Border(1).Padding(4).Text("Prime nette \nH.T").ExtraBold().AlignCenter().FontSize(10);

//                                     // RESPONSABILITE CIVILE
//                                     table.Cell().Border(1).Padding(5).Text("RESPONSABILITE CIVILE").ExtraBold().FontSize(7);
//                                     table.Cell().BorderLeft(1).BorderBottom(1).BorderTop(1).Padding(2).Text("50 000 000,00").ExtraBold().FontSize(7);
//                                     table.Cell().BorderRight(1).BorderBottom(1).BorderTop(1).Padding(2).Text("-----------------").AlignCenter().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("3 490.00").ExtraBold().FontSize(8).AlignRight();

//                                     // DEFENSE ET RECOURS
//                                     table.Cell().Border(1).Padding(5).Text("DEFENSE ET RECOURS").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("20 000.00").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("-----------------").AlignCenter().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("").FontSize(7);

//                                     // PERSONNES TRANSPORTEES
//                                     table.Cell().Border(1).Padding(5).Text("PERSONNES TRANSPORTEES").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("50 000.00").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("-----------------").AlignCenter().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("OFFERTE").ExtraBold().FontSize(8).AlignRight();

//                                     // DOMMAGES COLLISION
//                                     table.Cell().Border(1).Padding(4).Text("DOMMAGES COLLISION").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("17 500.00").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("3 %\nmin 500DH").ExtraBold().AlignCenter().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("").FontSize(7);

//                                     // INCENDIE
//                                     table.Cell().Border(1).Padding(5).Text("INCENDIE").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("140 000.00").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("0 %").ExtraBold().AlignCenter().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("").FontSize(7);

//                                     // VOL
//                                     table.Cell().Border(1).Padding(5).Text("VOL").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("140 000.00").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("3 %").ExtraBold().AlignCenter().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("").FontSize(7);

//                                     // VOL DE REMORQUEUR
//                                     table.Cell().Border(1).Padding(5).Text("VOL DE REMORQUEUR").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("").FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("").FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("INCLUS").ExtraBold().FontSize(8).AlignRight();

//                                     // BRIS DE GLACES 1ER RISQUE
//                                     table.Cell().Border(1).Padding(5).Text("BRIS DE GLACES 1ER RISQUE").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("7 500.00").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("3 %").ExtraBold().AlignCenter().FontSize(7);
//                                     table.Cell().Border(1).Padding(2).Text("").FontSize(7);
//                                     //Dommages
//                                     table.Cell().Border(1).Padding(5).Text("DOMMAGES COLLISION DEPLAFONNEE (1)").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(3).Background(Colors.Grey.Lighten2);
//                                     table.Cell().Border(1);
//                                     table.Cell().Border(1);

//                                     //TIERCE
//                                     table.Cell().Border(1).Padding(5).Text("TIERCE (2)").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(3).Background(Colors.Grey.Lighten2);
//                                     table.Cell().Border(1);
//                                     table.Cell().Border(1);

//                                     // TIERCE OPTIMALE
//                                     table.Cell().Border(1).Padding(5).Text("TIERCE OPTIMALE(3) ou (4)").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(3).Background(Colors.Grey.Lighten2);
//                                     table.Cell().Border(1);
//                                     table.Cell().Border(1);

//                                     //TIERCE ECO
//                                     table.Cell().Border(1).Padding(5).Text("TIERCE ECO(3) et (5)").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(3).Background(Colors.Grey.Lighten2);
//                                     table.Cell().Border(1);
//                                     table.Cell().Border(1);

//                                     //TIERCE OPTIMALE ECO (3) (4) (5)
//                                     table.Cell().Border(1).Padding(5).Text("TIERCE OPTIMALE ECO (3) (4) (5)").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(3).Background(Colors.Grey.Lighten2);
//                                     table.Cell().Border(1);
//                                     table.Cell().Border(1);

//                                     //RACHAT DE FRANCHISE
//                                     table.Cell().Border(1).Padding(4).Text("RACHAT DE FRANCHISE:Tierce,DCD,DC,Vol,Incendie (6)").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(3).Background(Colors.Grey.Lighten2);
//                                     table.Cell().Border(1);
//                                     table.Cell().Border(1);

//                                     //RACHAT DE LA VETUSTE RC
//                                     table.Cell().Border(1).Padding(4).Text("RACHAT DE LA VETUSTE RC").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(3).Background(Colors.Grey.Lighten2);
//                                     table.Cell().Border(1);
//                                     table.Cell().Border(1).Padding(3).Background(Colors.Grey.Lighten2);

//                                     //RACHAT DE LA VETUSTE
//                                     table.Cell().Border(1).Padding(3).Text("RACHAT DE LA VETUSTE RC, DCD,TIERCE,TIERCE OPTIMALE").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(3).Background(Colors.Grey.Lighten2);
//                                     table.Cell().Border(1);
//                                     table.Cell().Border(1).Padding(3).Background(Colors.Grey.Lighten2);

//                                     //EVENEMENTS CATASTROPHIQUES
//                                     table.Cell().Border(1).Padding(5).Text("EVENEMENTS CATASTROPHIQUES").ExtraBold().FontSize(7);
//                                     table.Cell().ColumnSpan(2).BorderLeft(1).BorderBottom(1).BorderTop(1).Padding(2).Text("Pour l'application de cette garantie se référer à l'article 13 (décrét N° 2-9-244)").FontSize(6);
//                                     // table.Cell().BorderRight(1).BorderBottom(1).BorderTop(1);
//                                     table.Cell().Border(1).Padding(2).Text("126,60").ExtraBold().FontSize(8).AlignRight();

//                                     table.Cell().BorderLeft(1).BorderBottom(1).BorderTop(1).Padding(3).Text("ASSISTANCE\nRMA MERTAH").ExtraBold().FontSize(7);
//                                     table.Cell().BorderBottom(1).BorderTop(1);
//                                     table.Cell().BorderRight(1).BorderBottom(1).BorderTop(1);
//                                     table.Cell().Border(1).Padding(2).Text("207,90").ExtraBold().FontSize(8).AlignRight();

//                                 });
//                             });

//                             // Right column - Décompte de primes
//                             mainRow.RelativeItem(1).ExtendVertical().Column(rightColumn =>
//                             {
//                                 rightColumn.Item().Border(1).BorderColor(Colors.Black).Padding(4).Text("Décompte de primes en dirhams").ExtraBold().FontSize(9).AlignCenter();
//                                 rightColumn.Item().Border(1).BorderColor(Colors.Black).Table(table =>
//                                 {
//                                     table.ColumnsDefinition(columns =>
//                                     {
//                                         columns.RelativeColumn(1);
//                                         columns.RelativeColumn(1);
//                                         columns.RelativeColumn(1);
//                                     });

//                                     // Headers
//                                     table.Cell().Border(1).Text("");
//                                     table.Cell().Border(1).Padding(4).Text("Automobile").ExtraBold().FontSize(7).AlignCenter();
//                                     table.Cell().Border(1).Padding(4).Text("PTA / PC").ExtraBold().FontSize(7).AlignCenter();

//                                     // Prime nette
//                                     table.Cell().Border(1).Padding(5).Text("Prime nette").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(5).Text("3 490,00").Bold().FontSize(7).AlignRight();
//                                     table.Cell().Border(1).Padding(5).Text("504,88").Bold().FontSize(7).AlignRight();

//                                     // Taxes
//                                     table.Cell().Border(1).Padding(5).Text("Taxes").ExtraBold().FontSize(7).AlignCenter();
//                                     table.Cell().Border(1).Padding(5).Text("540,95").FontSize(7).AlignRight();
//                                     table.Cell().Border(1).Padding(5).Text("70,68").FontSize(7).AlignRight();

//                                     // Accessoires et timbre
//                                     table.Cell().ColumnSpan(2).Border(1).Padding(4).Text("Accessoires & timbre :").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(4).Text("17,00").FontSize(7).AlignRight();

//                                     // S/Total
//                                     table.Cell().Border(1).Padding(5).Text("").FontSize(7);
//                                     table.Cell().ColumnSpan(2).Border(1).Padding(5).Element(x =>
//                                     {
//                                         x.Row(row =>
//                                         {
//                                             row.RelativeItem().AlignLeft().Text("S/Total :").ExtraBold().FontSize(7);
//                                             row.RelativeItem().AlignRight().Text("4 623,59").FontSize(7);

//                                         });
//                                     });
//                                     // Évènements catastrophiques
//                                     table.Cell().ColumnSpan(2).Border(1).Padding(4).Text("Evénements catastrophiques").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(4).Text("126,60").FontSize(7).AlignRight();

//                                     // Taxe Évè. catastrophiques
//                                     table.Cell().ColumnSpan(2).Border(1).Padding(4).Text("Taxe Eve. catastrophiques").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(4).Text("17,72").FontSize(7).AlignRight();

//                                     // Taxe Parafiscale
//                                     table.Cell().ColumnSpan(2).Border(1).Padding(4).Text("Taxe Parafiscale").ExtraBold().FontSize(7);
//                                     table.Cell().Border(1).Padding(4).Text("41,21").FontSize(7).AlignRight();

//                                     table.Cell().ColumnSpan(2).BorderLeft(1).BorderBottom(1).BorderTop(1).Padding(5).Text("Prime totale à payer :").ExtraBold().FontSize(7);
//                                     table.Cell().BorderRight(1).BorderBottom(1).BorderTop(1).Padding(5).Text("4 810,00").ExtraBold().FontSize(7).AlignRight();
//                                 });

//                                 // Clauses particulières section
//                                 rightColumn.Item().Column(clausesColumn =>
//                                 {
//                                     clausesColumn.Item().Border(1).BorderColor(Colors.Black).Padding(4).Text(x =>
//                                     {
//                                         x.Span("Clauses particulières en cas de sinistre\n").FontSize(8).ExtraBold();
//                                         x.Span("1) Une franchise de 1000DH supplémentaire sera ajoutée à partir du deuxième sinistre.\n" +
//                                             "(2) Une franchise de 500DH suplémentaire sera ajoutée à partir du deuxième sinistre.\n" +
//                                             "(3) En cas d'un tiers identifié, une franchise de 1000DH sera appliquée et un suplémentaire de 1000DH sera ajoutée à partir du deuxième sinistre.\n" +
//                                             "(4) En cas d'un tiers non identifié, une franchise de 2500DH sera appliquée et un supplémentaire de 500DH sera ajoutée à partir du deuxième sinistre.\n" +
//                                             "(5) En cas de sinistre l assuré s'engage à effectuer les réparations avec des pièces ou éléments de carrosserie de récupération recyclées. A défaut de disponibilité desdites pièces, les réparations pourraient être effectuées avec des pièces d origine et il sera fait application dans ce cas de la vétusté à dire d experts\n" +
//                                             " (6 )Le plafond de l'engagement total de l'Assureur par sinistre est de 2 500 MAD maximum et 2 sinistres pris en charge par année de contrat.\n "
//                                             ).FontSize(7).ExtraBold();
//                                         x.Span(" à l'exclusion :\n").FontSize(8).ExtraBold();
//                                         x.Span("Les rayures et les frottements avec un corps fixe ou mobile lors de l'entrée ou de la sortie de stationnement, ou en cours de stationnement").FontSize(7).Bold();
//                                     });
//                                 });
//                             });
//                         });
//                     });
//                 }
//                 void Footer(IContainer cont)
//                 {
//                     cont.MinHeight(50).PaddingBottom(7).Column(col =>
//                     {
//                         col.Spacing(7);

//                         col.Item().PaddingRight(15).PaddingLeft(15).AlignMiddle().Text("Je soussigné(e) certifie exactes et sincères les déclarations ci-dessus. Je déclare avoir reçu un exemplaire des conditions générales et les accepter sans réserve. Je consens à recevoir des messages m'informant des événements liés à mon contrat d'assurance.")
//                             .FontSize(8)
//                             .Bold();
//                         col.Item().Row(row =>
//                         {
//                             row.Spacing(20);
//                             row.RelativeItem().AlignBottom().AlignLeft().PaddingBottom(10).PaddingLeft(15).Column(column =>
//                             {
//                                 column.Item().Text(x =>
//                                 {
//                                     x.Span("Fait à ...........................,").FontSize(8).Bold();
//                                     x.Span(" le ........................... ").FontSize(8).Bold();
//                                     x.Span("à .........................").FontSize(8).Bold();
//                                 });
//                             });
//                             row.ConstantItem(150).PaddingBottom(10).Text("Le Souscripteur").ExtraBold().FontSize(8);
//                             row.ConstantItem(150).PaddingBottom(10).Text("Pour la compagnie").ExtraBold().FontSize(8);
//                         });
//                         col.Item().PaddingRight(15).PaddingLeft(15).AlignMiddle().Text("(1) ces conditions particulières sont régies par la loi n° 17/99 portant code des assurances et par les conditions générales du contrat multirisque automobile Siége social : 83, avenue de l'Armée Royale - Casablanca- Maroc - Tél.: 022 31 21 63 - 022 31 01 69 - Fax : 022 31 38 84 S.A au capital de 1.796.170.830 de DH - RC. 15.207 - CNSS : 111.6666 - PATENTE : 35101950 - I.F : D1084830 Entreperise régie par la loi 17/99")
//                             .FontSize(6)
//                             .Bold();
//                     });
//                 }
//             });
//         }).GeneratePdf();

//         if (pdfBytes.Length == 0 || pdfBytes == null)
//         {
//             await SendStringAsync("PDF generation failed", statusCode: 500, cancellation: ct);
//             return;
//         }
//         HttpContext.Response.Headers.Append("Content-Disposition", "attachment; filename=example.pdf");
//         await SendBytesAsync(
//             bytes: pdfBytes,
//             contentType: "application/pdf",
//             cancellation: ct
//         );
//     }
// }
// //curl http://localhost:5000/pdf -o example.pdf
using FastEndpoints;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Microsoft.AspNetCore.Http;
using QuestPDF.Helpers;

namespace FastEndpointsTutorial;


// public class AssureData
// {
//     public string? Nom { get; set; }
//     public string? Prenom { get; set; }
//     public string? NoCIN { get; set; }
//     public string? NoRC { get; set; }
//     public string? Adresse { get; set; }
//     public string? NoPermis { get; set; }
//     public string? Ville { get; set; }
//     public string? DateDelivrance { get; set; }
//     public string? Marque { get; set; }
//     public string? Type { get; set; }
//     public string? PoidsTotal { get; set; }
//     public string? ValeurVenale { get; set; }
//     public string? Immatriculation { get; set; }
//     public string? MiseEnCirculation { get; set; }
//     public string? Puiss_Fiscale { get; set; }
//     public string? Combustion { get; set; }
//     public string? Usage { get; set; }
//     public string? NbrePlaces { get; set; }
//     public string? Matricule { get; set; }
//     public string? ValeurNeuf { get; set; }
//     public string? POLE { get; set; }
//     public string? AttestationNo { get; set; }
//     public string? CRM { get; set; }
//     public string? Duree { get; set; }
//     public string? DateEffet { get; set; }
//     public string? DateEcheance { get; set; }
//     public string? EcheanceAnniversaire { get; set; }

//     //Garanties
//     public List<Garantie>? RESPONSABILITE_CIVILE { get; set; }
//     public List<Garantie>? DEFENSE_ET_RECOURS { get; set; }
//     public List<Garantie>? PERSONNES_TRANSPORTEES { get; set; }
//     public List<Garantie>? DOMMAGES_COLLISION { get; set; }
//     public List<Garantie>? INCENDIE { get; set; }
//     public List<Garantie>? VOL { get; set; }
//     public List<Garantie>? VOL_DE_REMORQUEUR { get; set; }
//     public List<Garantie>? BRIS_DE_GLACES_1ER_RISQUE { get; set; }
//     public List<Garantie>? DOMMAGES_COLLISION_DEPLAFONNEE { get; set; }
//     public List<Garantie>? TIERCE { get; set; }
//     public List<Garantie>? TIERCE_OPTIMALE { get; set; }
//     public List<Garantie>? TIERCE_ECO { get; set; }
//     public List<Garantie>? TIERCE_OPTIMALE_ECO { get; set; }
//     public List<Garantie>? RACHAT_DE_FRANCHISE_DCD_DC { get; set; }
//     public List<Garantie>? RACHAT_DE_LA_VETUSTE_RC { get; set; }
//     public List<Garantie>? RACHAT_DE_LA_VETUSTE_RC_DCD { get; set; }
//     public List<Garantie>? EVENEMENTS_CATASTROPHIQUES { get; set; }
//     public double? ASSISTANCE_RMA_MERTAH { get; set; }


//     // Décompte de primes
//     public List<DecomptePrimes>? PrimeNette { get; set; }
//     public List<DecomptePrimes>? Taxes { get; set; }
//     public double? AccessoiresEtTimbre_PTA_PC { get; set; }
//     public double? S_Total { get; set; }
//     public double? EvenementsCatastrophiques_PTA_PC { get; set; }
//     public double? TaxeEvenementsCatastrophiques_PTA_PC { get; set; }
//     public double? TaxeParafiscale_PTA_PC { get; set; }
//     public double? PrimeTotaleAPayer { get; set; }
    
// }
// public class Garantie
// {
//     public string? CapitalAssureEnDirhams { get; set; }
//     public string? Franchise { get; set; }
//     public string? PrimeNetteHT { get; set; }
// }

// public class DecomptePrimes
// {
//     public string? Automobile { get; set; }
//     public string? PTA_PC { get; set; }
// }   


public class ExamplEndpoint : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("/pdf/{docName}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        //REPR Design Pattern = defines web API endpoints as having three components:
        // a Request, an Endpoint and a Response.

        var docName = Route<string>("docName");

        var document = PDFDocumentFactory.Create(docName);
        if (document == null)
        {
            await SendStringAsync("Document not found", statusCode: 404, cancellation: ct);
            return;
        }
        var pdfBytes = document.GeneratePdf();

        if (pdfBytes.Length == 0 || pdfBytes == null)
        {
            await SendStringAsync("PDF generation failed", statusCode: 500, cancellation: ct);
            return;
        }
        HttpContext.Response.Headers.Append("Content-Disposition", $"attachment; filename={docName}.pdf");
        await SendBytesAsync(
            bytes: pdfBytes,
            contentType: "application/pdf",
            cancellation: ct
        );
    }
}
//curl http://localhost:5000/pdf -o example.pdf
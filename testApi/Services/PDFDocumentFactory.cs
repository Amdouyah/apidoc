using QuestPDF.Infrastructure;
using Attestation;
using System.Net.Http.Headers;

public static class PDFDocumentFactory
{
    public static IDocument? Create(string name)
    {
        switch (name.ToLower())
        {
            case "enespece":
                return new EnEspece();
            case "attestationannullee":
                return new AttestatioAnnullee();
            case "attestationremises":
                return new AttestationRemises();
            case "cartevertes":
                return new CarteVertes();
            case "chequem":
                return new ChequeM();
            case "chequeunique":
                return new ChequeUnique();
            case "creditppr":
                return new CreditPPR();
            case "creditpprday":
                return new CreditPPRDay();
            case "multicheques":
                return new MultiCheques();
            case "paradministration":
                return new ParAdministration();
            case "partpe":
                return new ParTPE();
            default:
                return null;
        }
    }
}

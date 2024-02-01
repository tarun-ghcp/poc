namespace DocumentManagement.Models
{
    public class DocumentModel
    {
        // Add few properties to the Document
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; } = null;
        public string? Location { get; set; } = null;

       


    }
    public interface IDocumentService
    {
        // Add methods to add, update and delete a document
        
        // AddDocument to accept a document object and add it to the database
        
        void AddDocument(DocumentModel document);
        //void UpdateDocument(DocumentModel document);
        string DeleteDocument(int documentId);

        // Add a method to get a document by Id
        DocumentModel? GetDocumentById(int id);

        // Add a method to get a count of documents
        int GetDocumentCount();

    }
}

using DocumentManagement.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DocumentManagement.Service
{
    public class DocumentService : IDocumentService
    {
        private readonly int _id;
        private readonly string? _name;
        private readonly string? _description;

        // create a list object to store the documents
        private List<DocumentModel> documentList = new List<DocumentModel>();

        // add a memory cache object
        private IMemoryCache _memoryCache;
        // Add a constructor to initialize the properties
        
        
        public DocumentService(IMemoryCache memoryCache)
        {
        //    // initialize class properties with document
        //    _id = document.Id;
        //    _name = document.Name;
        //    _description = document.Description;
        // initialize the memory cache object
               _memoryCache = memoryCache; 
        }
        
        // Add a definition for the AddDocument method
        public void AddDocument(DocumentModel document)
        {
            // get the documentList from the memory cache
            var documentList = _memoryCache.Get("documentList") as List<DocumentModel>;
            if (documentList != null)
            {
                // check if the documentList have any items
                if (documentList.Count > 0)
                {
                    // if the documentList have items, then get the max Id from the list
                    document.Id = documentList.Max(x => x.Id) + 1;
                }
                else
                {
                    // if the documentList does not have any items, then set the Id to 1
                    document.Id = 1;
                }
                // add the new document to the list
                documentList.Add(document);
            }
            else
            {
                // if the documentList is null, then create a new list
                documentList = new List<DocumentModel>();
                // set the Id to 1
                document.Id = 1;
                // add the new document to the list
                documentList.Add(document);
            }
            // set the documentList to the memory cache
            _memoryCache.Set("documentList", documentList);
            
        }
        
        // add a method to delete the document
        public string DeleteDocument(int documentId)
        {
            // get the document from the list
            DocumentModel? document = documentList.FirstOrDefault(x => x.Id == documentId);
            if (document != null)
            {
                // remove the document from the list
                documentList.Remove(document);

                // return a message
                return "Document deleted successfully";
            }
            else
            {
                // return a message
                return "Document not found";
            }

        }

        

        // add a method to get the document by Id
        public DocumentModel? GetDocumentById(int id)
        {
            // get the document from the list
            DocumentModel? document = documentList.FirstOrDefault(x => x.Id == id);
            if (document != null)
            {
                // return the document
                return document;
            }
            else
            {
                // return null if the document is not found
                return null;
            }
        }

        // add a method to get the count of documents
        public int GetDocumentCount()
        {
            //get the documentList from the memory cache

            var documentList = _memoryCache.Get("documentList") as List<DocumentModel>;

            // check if the documentList is null
            if (documentList == null)
            {
                // if the documentList is null, then return 0
                return 0;

            }
            else
            {
                // if the documentList is not null, then get the count of documents
                return documentList.Count;
            }
            
        }

        // add a method to update the document
       

    }
}

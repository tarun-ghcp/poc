using DocumentManagement.Models;
using DocumentManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        // add a constructor to initialize the service
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        //add a method to create a new document
        [HttpPost]
        [Route("add")]
        public void AddDocument(string name, string description)
        {
            DocumentModel model = new DocumentModel();
            model.Name = name;
            model.Description = description;

            _documentService.AddDocument(model);
        }

        [HttpPost]
        [Route("remove")]
        public string DeleteDocument(int id)
        {
            // check if the id is a postive number
            if (id <= 0)
            {
                // return a message
                return "Invalid Id";                
            }

            return _documentService.DeleteDocument(id);
        }

        // add a method to update the document
        [HttpPost]
        [Route("update")]
        public void UpdateDocument(int id, string name, string description)
        {
            DocumentModel model = new DocumentModel();
            model.Id = id;
            model.Name = name;
            model.Description = description;

            //_documentService.UpdateDocument(model);
        }

        // add a method to get the count of documents
        [HttpGet]
        [Route("count")]
        public int GetDocumentCount()
        {
            return _documentService.GetDocumentCount();
        }
        
    }
}

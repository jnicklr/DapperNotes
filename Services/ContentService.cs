using DapperNotes.Models;
using DapperNotes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.Services
{
    public class ContentService
    {
        public ContentRepository _contentRepository;

        public ContentService(ContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }

        public int AddContent(Content content)
        {
            return _contentRepository.Add(content);
        }

        public int UpdateContent(Content content, int id)
        {
            return _contentRepository.Update(content, id);
        }

        public int DeleteContent(int id)
        {
            return _contentRepository.Delete(id);
        }

        public IEnumerable<Content> GetAllContents()
        {
            return _contentRepository.Get();
        }

        public IEnumerable<Content> GetContentById(int id)
        {
            return _contentRepository.GetById(id);
        }
    }
}

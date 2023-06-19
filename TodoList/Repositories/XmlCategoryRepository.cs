using TodoList.Interfaces;
using TodoList.Models;
using TodoList.Utils;

namespace TodoList.Repositories;

public class XmlCategoryRepository: ICategoryRepository
{
    private readonly string _path = Directory.GetCurrentDirectory() + "/Categories.xml";
    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await Task.Run(() =>
            {
                var streamReader = new StreamReader(_path);
        
                var categories = streamReader.Deserialize<Category>();

                return categories.ToList();
            });
    }

    public async Task<Category> CreateAsync(Category category)
    {
        var doc = await XmlDocumentExtension.LoadDocumentAsync(_path);
        category.Id = new Random().Next();
        var xmlCategory = XmlModelSerializer.EntityToXmlElement(category);
        
        doc.Root?.Add(xmlCategory);

        await doc.SaveDocumentAsync(_path);

        return category;
    }

    public async Task<Category?> GetCategoryById(int id)
    {
        var doc = await XmlDocumentExtension.LoadDocumentAsync(_path);

        return doc.DeserializeFirstOfDefault<Category>(e => e.Element("Id")?.Value == id.ToString());
    }

    public async Task UpdateCategory(Category category)
    {
        var doc = await XmlDocumentExtension.LoadDocumentAsync(_path);

        var element = doc.GetElementBy("Id", category.Id.ToString());
        
        element.ReplaceWith(XmlModelSerializer.EntityToXmlElement(category));

        await doc.SaveDocumentAsync(_path);
    }

    public async Task DeleteCategory(int id)
    {
        var doc = await XmlDocumentExtension.LoadDocumentAsync(_path);

        var element = doc.GetElementBy("Id", id.ToString());
        
        element.Remove();

        await doc.SaveDocumentAsync(_path);
    }
}
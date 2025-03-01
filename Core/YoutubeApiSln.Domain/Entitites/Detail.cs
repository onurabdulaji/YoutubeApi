using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiSln.Domain.Common;

namespace YoutubeApiSln.Domain.Entitites;

public class Detail : EntityBase
{
    public Detail(string title, string description, int categoryID)
    {
        Title = title;
        Description = description;
        CategoryId = categoryID;
    }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}

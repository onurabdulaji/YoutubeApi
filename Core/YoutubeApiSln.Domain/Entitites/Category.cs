using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeApiSln.Domain.Common;

namespace YoutubeApiSln.Domain.Entitites;

public class Category : EntityBase
{
    public Category(int parentId, string name, int priorty)
    {
        ParentId = parentId;
        Name = name;
        Priorty = priorty;
    }
    public int ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Priorty { get; set; }
    public ICollection<Detail> Details { get; set; }
    public ICollection<Product> Products { get; set; }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstCoreApp.Models
{
    public class News
    {
        public int Id { get; set; }
        [DisplayName("Title Of the New")]
        public string Title { get; set; }
        public string Topic { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }


        public Category Category { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}

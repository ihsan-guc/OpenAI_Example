namespace OpenAI_Assistants_Example.Model
{
    public class AnswerModel
    {
        public List<Datum> data { get; set; }
        public string first_id { get; set; }
        public string last_id { get; set; }
    }
    public class Content
    {
        public Text text { get; set; }
    }
    public class Datum
    {
        public string id { get; set; }
        public List<Content> content { get; set; }
    }
    public class Text
    {
        public string value { get; set; }
    }
    public class StatusModel
    {
        public string status { get; set; }
    }
}

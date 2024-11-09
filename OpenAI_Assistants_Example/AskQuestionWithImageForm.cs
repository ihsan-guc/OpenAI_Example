using OpenAI_Assistants_Example.Model;
using System.Text.Json;

namespace OpenAI_Assistants_Example
{
    public partial class AskQuestionWithImageForm : Form
    {
        public string _openAIKey = "";
        public string _assistant_id = "";
        public string threadsId = "";
        public string runId = "";
        public string fileId = "";

        public AskQuestionWithImageForm()
        {
            InitializeComponent();
        }

        private async void Chose_Image_Btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Select Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var response = await UploadFile(openFileDialog.FileName);
                    fileId = response.id;
                }
                if (!string.IsNullOrEmpty(fileId))
                {
                    var threadResponse = await CreateThread(fileId);
                    threadsId = threadResponse.id;
                }
                if (!string.IsNullOrEmpty(threadsId))
                {
                    var response = await AskQuestion(threadsId, "What kind of bird is this?");
                    if (response is true)
                    {
                        Thread.Sleep(1000);
                        var runResponse = await CreateRuns(threadsId);
                        runId = runResponse.id;
                    }
                }
            }
        }
        private async Task<IdModel?> UploadFile(string path)
        {
            var content = new MultipartFormDataContent();
            using (var stream = File.OpenRead(path))
            {
                var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                content.Add(new StreamContent(memoryStream), "file", stream.Name);
            }
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/files");
                request.Headers.Add("Authorization", "Bearer " + _openAIKey);
                content.Add(new StringContent("user_data"), "purpose"); // user_data is the purpose of the file
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<IdModel>(await response.Content.ReadAsStringAsync());
            }
        }
        private async Task<IdModel?> CreateThread(string? fileId)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/threads");
                request.Headers.Add("Authorization", "Bearer " + _openAIKey);
                request.Headers.Add("OpenAI-Beta", "assistants=v2");

                var detail = "What kind of bird is this?";
                var content = new StringContent("{\n    \"messages\": [\n      {\n        \"role\": \"user\",\n        \"content\": [\n          {\n            \"type\": \"text\",\n            \"text\": \"" + detail + "\"\n          } \n        ],\n        \"attachments\": [\n        {\n            \"file_id\": \"" + fileId + "\",\n            \"tools\": [{\"type\": \"code_interpreter\"}]\n        }\n        ]\n      }\n    ]\n  }", null, "application/json"); ;

                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                return JsonSerializer.Deserialize<IdModel>(await response.Content.ReadAsStringAsync());
            }
        }
        private async Task<bool?> AskQuestion(string threadId, string detail)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.openai.com/v1/threads/{threadId}/messages");
                request.Headers.Add("Authorization", "Bearer " + _openAIKey);
                request.Headers.Add("OpenAI-Beta", "assistants=v2");

                var requestModel = new
                {
                    role = "user",
                    content = detail
                };

                var content = new StringContent(JsonSerializer.Serialize(requestModel), null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return true;
            }
        }
        private async Task<IdModel?> CreateRuns(string threadId)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.openai.com/v1/threads/{threadId}/runs");
                request.Headers.Add("Authorization", "Bearer " + _openAIKey);
                request.Headers.Add("OpenAI-Beta", "assistants=v2");
                var requestModel = new
                {
                    assistant_id = _assistant_id
                };

                var content = new StringContent(JsonSerializer.Serialize(requestModel), null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return JsonSerializer.Deserialize<IdModel>(await response.Content.ReadAsStringAsync());
            }
        }
        private async Task<StatusModel> CheckStatus()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.openai.com/v1/threads/{threadsId}/runs/{runId}");
                request.Headers.Add("Authorization", "Bearer " + _openAIKey);
                request.Headers.Add("OpenAI-Beta", "assistants=v2");

                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<StatusModel>(responseContent);
            }
        }
        private async Task<string> GetAnswer()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.openai.com/v1/threads/{threadsId}/messages");
                request.Headers.Add("Authorization", "Bearer " + _openAIKey);
                request.Headers.Add("OpenAI-Beta", "assistants=v2");

                var response = await client.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Serialize<string>(responseContent);
            }
        }
        private async void Get_Answer_Btn_Click(object sender, EventArgs e)
        {
            var status = await CheckStatus();
            if (status.status == "running")
            {
                MessageBox.Show("Please wait for the answer");
            }
            else if (string.IsNullOrEmpty(threadsId))
            {
                MessageBox.Show("Please ask a question first");
            }
            else
            { 
                Answer_Listbox.Items.Add(JsonSerializer.Serialize(await GetAnswer()));
            }
        }
    }
}

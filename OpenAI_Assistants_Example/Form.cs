using OpenAI_Assistants_Example.Model;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace OpenAI_Assistants_Example
{
    public partial class Form : System.Windows.Forms.Form
    {
        public string _openAIKey = "";
        public string _assistant_id = "";
        public static HttpClient _httpClient = new HttpClient();
        public string threadsId = "";
        public string runId = "";

        public Form()
        {
            _openAIKey = "YOUR_OPENAI_KEY";
            _assistant_id = "YOUR_ASSISTANT_ID_KEY";
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAIKey);
            _httpClient.DefaultRequestHeaders.Add("OpenAI-Beta", "assistants=v1");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
        }
        private async void Ask_Question_Btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Ask_Question_Txt.Text))
            {
                MessageBox.Show("Please enter a question");
            }
            else
            {
                await CreateThread();
                await AskQuestion(Ask_Question_Txt.Text);
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
                var answerResponse = await GetAnswer(threadsId);
                if (answerResponse.data.Count != 2)
                {
                    MessageBox.Show("Please try again");
                }
                else
                {
                    var answer = answerResponse.data[0].content[0].text.value;
                    Answer_Listbox.Items.Add(answer);
                }
            }
        }
        public async Task CreateThread()
        {
            var requestData = new
            {
                assistant_id = _assistant_id
            };
            var content = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/threads", null);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IdModel>(responseContent);
            threadsId = result.id;
        }
        public async Task AskQuestion(string txt)
        {
            var messageData = new
            {
                role = "user",
                content = txt
            };
            var content = new StringContent(JsonSerializer.Serialize(messageData), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://api.openai.com/v1/threads/{threadsId}/messages", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            var runData = new
            {
                assistant_id = _assistant_id
            };

            content = new StringContent(JsonSerializer.Serialize(runData), Encoding.UTF8, "application/json");
            response = await _httpClient.PostAsync($"https://api.openai.com/v1/threads/{threadsId}/runs", content);
            responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<IdModel>(responseContent);
            runId = result.id;
        }
        public async Task<StatusModel> CheckStatus()
        {
            var response = await _httpClient.GetAsync($"https://api.openai.com/v1/threads/thread_tAI74y30rdBc5Cnw4ZkEk6zG/runs/run_VWO6NwXApYwmwfw02sIbi4UY");
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<StatusModel>(responseContent);
            return result;
        }
        public static async Task<AnswerModel> GetAnswer(string id)
        {
            var response = await _httpClient.GetAsync($"https://api.openai.com/v1/threads/{id}/messages");
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AnswerModel>(responseContent);
        }
        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            Answer_Listbox.Items.Clear();
        }
    }
}

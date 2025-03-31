namespace Лаб2_2ТП
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.textBox1.ToString();
            textBox2.Text = Properties.Settings.Default.textBox2.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string word1, word2;
            try
            {
                word1 = textBox1.Text;
                word2 = textBox2.Text;
            }
            catch(FormatException)
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.textBox1 = word1;
            Properties.Settings.Default.textBox2 = word2;
            Properties.Settings.Default.Save();
            MessageBox.Show(Logic.CheckForLettersInAWord(word1, word2));
        }
    }
    public class Logic
    {
        public static string CheckForLettersInAWord(string word1, string word2)
        {
            List<string> list = new List<string>();
            List<char> lettersWithoutRepeats = new List<char>();
            string results;
            if (word1 == "" && word2 == "")
            {
                list.Add("Оба слова не были набраны");
                return "Оба слова не были набраны";
            }
            else if (word1 == "")
            {
                list.Add("Первое слово не было набрано");
                return "Первое слово не было набрано";
            }
            else if (word2 == "")
            {
                list.Add("Второе слово не было набрано");
                return "Второе слово не было набрано";
            }
            for (int i = 0; i < word1.Length; i++)
            {
                if (!lettersWithoutRepeats.Contains(word1[i]))
                {
                    lettersWithoutRepeats.Add(word1[i]);
                }
            }
            for (int i = 0; i < lettersWithoutRepeats.Count; i++)
            {
                if (word2.Contains(lettersWithoutRepeats[i]))
                    list.Add("да");
                else
                    list.Add("нет");
            }
            results = String.Join(" ", list);
            return results;
        }
    }
}
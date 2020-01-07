using ProducerConsumer.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProducerConsumer.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Producer _producer;
        private Consumer _consumer;
        private Queue<Task> _queue;

        public MainWindow()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Producer, Consumer und Queue erzeugen. Observer anmelden und 
        /// Simulation starten
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            TextBlockLog.Text = "";
            _queue=new Queue<Task>();
            int min = Convert.ToInt32(TextBoxProducerMinimum.Text);
            int max = Convert.ToInt32(TextBoxProducerMaximum.Text);
            //_producer = new Producer(min, max, LogTask, _queue);
            min = Convert.ToInt32(TextBoxConsumerMinimum.Text);
            max = Convert.ToInt32(TextBoxConsumerMaximum.Text);
            //_consumer = new Consumer(min, max, _queue);
            CheckBoxIsRunning.IsChecked = true;
        }

        /// <summary>
        /// Fügt eine Zeile zur Textbox hinzu.
        /// Da Timer in eigenem Thread läuft ist ein Threadwechsel mittels Invoke
        /// notwendig
        /// </summary>
        /// <param name="line"></param>
        void AddLineToTextBox(string line)
        {
            StringBuilder text = new StringBuilder(TextBlockLog.Text);
            text.Append(FastClock.Instance.Time.ToShortTimeString() + "\t");
            text.Append(line + "\n");
            TextBlockLog.Text = text.ToString();
        }

        private void CheckBoxIsRunning_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}

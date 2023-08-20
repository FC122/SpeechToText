using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace SpeechApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new SpeechSynthesizer instance
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Create a new SpeechRecognitionEngine instance with English-US culture
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));

            // Load the default English-US grammar
            recognizer.LoadGrammar(new DictationGrammar());

            // Attach the SpeechRecognized event handler
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

            // Set the audio input to the default audio device and start recognition
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            // Synthesize speech
            synth.Speak("Hello, how can I help you?");

            // Wait for user input to exit
            Console.ReadLine();
        }

        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Recognized: " + e.Result.Text);
        }
    }
}

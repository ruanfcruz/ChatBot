public class WhatsApp : ChannelBase
{
    public override string Name => "WhatsApp";

    public override void SendMessage(string numero, MessageBase message)
    {
        Console.WriteLine($"[WhatsApp] Enviando mensagem para {numero}");

        if (message is TextMessage txt)
            Console.WriteLine($"Texto: {txt.Message}");
        else if (message is PhotoMessage photo)
            Console.WriteLine($"Foto: {photo.File} ({photo.Format})");
        else if (message is VideoMessage video)
            Console.WriteLine($"Vídeo: {video.File} ({video.Format}) - {video.Duration}s");
        else if (message is FileMessage file)
            Console.WriteLine($"Arquivo: {file.File} ({file.Format})");

        Console.WriteLine($"Data de envio: {message.SendAt}\n");
    }
}
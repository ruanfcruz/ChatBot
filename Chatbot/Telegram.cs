public class Telegram : ChannelBase
{
    public override string Name => "Telegram";

    public override void SendMessage(string destino, MessageBase message)
    {
        Console.WriteLine($"[Telegram] Enviando mensagem para {destino}");

        if (message is VideoMessage video)
            Console.WriteLine($"Vídeo: {video.File} ({video.Format}) - {video.Duration}s");
        else if (message is PhotoMessage photo)
            Console.WriteLine($"Foto: {photo.File} ({photo.Format})");
        else if (message is FileMessage file)
            Console.WriteLine($"Arquivo: {file.File} ({file.Format})");
        else if (message is TextMessage text)
            Console.WriteLine($"Texto: {text.Message}");

        Console.WriteLine($"Data de envio: {message.SendAt}\n");
    }
}
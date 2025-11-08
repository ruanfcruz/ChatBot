public class Facebook : ChannelBase
{
    public override string Name => "Facebook";

    public override void SendMessage(string usuario, MessageBase message)
    {
        Console.WriteLine($"[Facebook] Enviando mensagem para @{usuario}");
        Console.WriteLine($"Conteúdo: {message.Message}");
        Console.WriteLine($"Data de envio: {message.SendAt}\n");
    }
}
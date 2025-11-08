using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("==== Sistema de Envio de Mensagens ====");
        Console.WriteLine("Selecione o canal de envio:");
        Console.WriteLine("1. WhatsApp");
        Console.WriteLine("2. Telegram");
        Console.WriteLine("3. Instagram");
        Console.WriteLine("4. Facebook");

        int canal;
        string resposta = Console.ReadLine();

        if (!int.TryParse(resposta, out canal) || canal < 1 || canal > 4)
        {
            Console.WriteLine("❌ Opção inválida!");
            return;
        }

        Console.WriteLine("\nSelecione o tipo de mensagem:");
        Console.WriteLine("1. Texto");
        Console.WriteLine("2. Foto");
        Console.WriteLine("3. Vídeo");
        Console.WriteLine("4. Arquivo");

        int tipoMsg;
        string respostaMsg = Console.ReadLine();

        if (!int.TryParse(respostaMsg, out tipoMsg) || tipoMsg < 1 || tipoMsg > 4)
        {
            Console.WriteLine("❌ Tipo de mensagem inválido!");
            return;
        }

        Console.Write("\nDigite o conteúdo da mensagem: ");
        string conteudo = Console.ReadLine();

        MessageBase mensagem = tipoMsg switch
        {
            1 => new TextMessage(conteudo),
            2 => new PhotoMessage(conteudo) { File = "foto.jpg", Format = "jpg" },
            3 => new VideoMessage(conteudo) { File = "video.mp4", Format = "mp4", Duration = 15 },
            4 => new FileMessage(conteudo) { File = "documento.pdf", Format = "pdf" },
            _ => new TextMessage("Mensagem padrão")
        };

        switch (canal)
        {
            case 1:
                var whats = new WhatsApp();
                Console.Write("Digite o número de telefone: ");
                string numWhats = Console.ReadLine();
                whats.SendMessage(numWhats, mensagem);
                break;

            case 2:
                var telegram = new Telegram();
                Console.Write("Digite o número ou usuário do Telegram: ");
                string userTel = Console.ReadLine();
                telegram.SendMessage(userTel, mensagem);
                break;

            case 3:
                var insta = new Instagram();
                Console.Write("Digite o usuário do Instagram: ");
                string userInsta = Console.ReadLine();
                insta.SendMessage(userInsta, mensagem);
                break;

            case 4:
                var face = new Facebook();
                Console.Write("Digite o usuário do Facebook: ");
                string userFace = Console.ReadLine();
                face.SendMessage(userFace, mensagem);
                break;
        }

        Console.WriteLine("\n✅ Mensagem enviada com sucesso!");
    }
}